using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace QStack.MsalClient
{
    /// <summary>
    /// This is a wrapper for PCA. It is singleton and can be utilized by both application and the MAM callback
    /// </summary>
    public class PCAWrapper : IPCAWrapper
    {
        private readonly IConfiguration _configuration;
        private readonly Settings _settings;
        private string authMessage;

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        internal IPublicClientApplication PCA { get; }

        internal bool UseEmbedded { get; set; } = false;
        public string[] Scopes { get; set; }

        // public constructor
        public PCAWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _settings = _configuration.GetRequiredSection("Settings").Get<Settings>();

            if (_settings?.Scopes == null)
                return;

            Scopes = _settings.Scopes.ToStringArray();
            // Create PCA once. Make sure that all the config parameters below are passed
            PCA = PublicClientApplicationBuilder
                                        .Create(_settings?.ClientId)
                                        .WithB2CAuthority(_settings?.Authority)
#if !ANDROID
                                        .WithRedirectUri("[ClientId]://auth")
#endif
                                        .Build();
        }

        /// <summary>
        /// Acquire the token silently
        /// </summary>
        /// <param name="scopes">desired scopes</param>
        /// <returns>Authentication result</returns>
        public async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes)
        {
            System.Diagnostics.Debug.WriteLine($"QSDebug - AcquireTokenSilentAsync - Started");
            if (PCA == null)
            {
                System.Diagnostics.Debug.WriteLine($"QSDebug - PCA = null");
                System.Diagnostics.Debug.WriteLine($"QSDebug - Returning");
                return null;
            }
            System.Diagnostics.Debug.WriteLine($"QSDebug - PCA = NOT NULL");
            System.Diagnostics.Debug.WriteLine($"QSDebug - PCA.Authority = {PCA.Authority}");

            var accounts = await PCA.GetAccountsAsync(_settings?.PolicySignUpSignIn);
            System.Diagnostics.Debug.WriteLine($"QSDebug - accounts = {accounts}");
            var account = accounts.FirstOrDefault();

            System.Diagnostics.Debug.WriteLine($"QSDebug - account = {account}");
            var authResult = await PCA.AcquireTokenSilent(scopes, account)
                                        .ExecuteAsync().ConfigureAwait(false);

            System.Diagnostics.Debug.WriteLine($"QSDebug - account = {authResult}");

            return authResult;

        }

        /// <summary>
        /// Perform the interactive acquisition of the token for the given scope
        /// </summary>
        /// <param name="scopes">desired scopes</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes)
        {
            System.Diagnostics.Debug.WriteLine($"QSDebug - AcquireTokenInteractiveAsync - Started");
            if (PCA == null)
            {
                System.Diagnostics.Debug.WriteLine($"QSDebug - PCA = null");
                System.Diagnostics.Debug.WriteLine($"QSDebug - Returning");
                return null;
            }
            System.Diagnostics.Debug.WriteLine($"QSDebug - PCA = NOT NULL");
            System.Diagnostics.Debug.WriteLine($"QSDebug - PCA.Authority = {PCA.Authority}");

            var accounts = await PCA.GetAccountsAsync(_settings?.PolicySignUpSignIn).ConfigureAwait(false);
            System.Diagnostics.Debug.WriteLine($"QSDebug - accounts = {accounts}");

            var account = accounts.FirstOrDefault();
            System.Diagnostics.Debug.WriteLine($"QSDebug - account = {account}");

            //.WithAuthority(_settings?.Authority)
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                var user = authState?.User;

                if (user?.Identity is not null && user.Identity.IsAuthenticated)
                {
                    authMessage = $"{user.Identity.Name} is authenticated.";
                }
            }
#if IOS
            var systemWebViewOptions = new SystemWebViewOptions();
            systemWebViewOptions.iOSHidePrivacyPrompt = true;

            return await PCA.AcquireTokenInteractive(scopes)
                                    .WithB2CAuthority(_settings?.Authority)
                                    .WithTenantId(_settings?.TenantId)
                                    .WithAccount(account)
                                    .WithParentActivityOrWindow(PlatformConfig.Instance.ParentWindow)
                                    .WithUseEmbeddedWebView(UseEmbedded)
                                    .WithSystemWebViewOptions(systemWebViewOptions)
                                    .ExecuteAsync()
                                    .ConfigureAwait(false);
#else

            return await PCA.AcquireTokenInteractive(scopes)
                                    .WithB2CAuthority(_settings?.Authority)
                                    .WithAccount(account)
                                    .WithParentActivityOrWindow(PlatformConfig.Instance.ParentWindow)
                                    .WithUseEmbeddedWebView(false)
                                    .ExecuteAsync()
                                    .ConfigureAwait(false);
#endif
        }

        /// <summary>
        /// Sign out may not perform the complete sign out as company portal may hold
        /// the token.
        /// </summary>
        /// <returns></returns>
        public async Task SignOutAsync()
        {
            if (PCA == null)
                return;

            var accounts = await PCA.GetAccountsAsync().ConfigureAwait(false);
            foreach (var acct in accounts)
            {
                await PCA.RemoveAsync(acct).ConfigureAwait(false);
            }
        }
    }
}