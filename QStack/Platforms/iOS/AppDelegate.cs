using Firebase.CloudMessaging;
using Foundation;
using Microsoft.Identity.Client;
using UIKit;

namespace QStack
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate, IMessagingDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Set the redirect URI for authentication
            PublicClientApplicationBuilder
                .Create("[ClientId]")
                .WithAuthority(AzureCloudInstance.AzurePublic, "common")
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .WithRedirectUri("msal[ClientId]://auth")
                .Build();
            //.WithRedirectUri("msauth.com.companyname.qstack://auth")

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, NSDictionary options)
        {
            if (url.AbsoluteString.StartsWith($"msal[ClientId]://auth"))
            {
                AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
                return true;
            }
            return base.OpenUrl(application, url, options);
        }

        //public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        //{
        //    //Firebase.Core.App.Configure();

        //    if(UIDevice.CurrentDevice.CheckSystemVersion(10,0))
        //    {
        //        var authOption = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;

        //        UNUserNotificationCenter.Current.RequestAuthorization(authOption, (granted, error) =>
        //        {

        //        });

        //        //UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();

        //        Messaging.SharedInstance.AutoInitEnabled = true;
        //        Messaging.SharedInstance.Delegate = this;
        //    }
        //    UIApplication.SharedApplication.RegisterForRemoteNotifications();

        //    return base.FinishedLaunching(application, launchOptions);
        //}

        //[Export("messaging:didReceiveRegistrationToken:")]
        //public void DidReceiverRegistrationToken(Messaging message, string regToken)
        //{
        //    if (Preferences.ContainsKey("DeviceToken"))
        //    {
        //        Preferences.Remove("DeviceToken");
        //    }
        //    Preferences.Set("DeviceToken", regToken);
        //}
    }
}
