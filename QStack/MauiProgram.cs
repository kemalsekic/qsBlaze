using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Plugin.LocalNotification;
using QStack.Auth;
using QStack.Components.Pages;
using QStack.DataAccess;
using QStack.DataAccess.Azure;
using QStack.DataAccess.Data;
using QStack.DataAccess.Interfaces;
using QStack.DataAccess.WF;
using QStack.MsalClient;
using QStack.Shared.States;
using System.Reflection;
using System.Security.Claims;
//using QStack.Shared.Hubs;
using static ExternalAuthStateProvider;

namespace QStack
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            var connectionString = builder.Configuration.GetConnectionString("AzureConnection");

            var executingAssembly = Assembly.GetExecutingAssembly();
            using var stream = executingAssembly.GetManifestResourceStream("QStack.appsettings.json");
            var configuration = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddTransient<IPeopleData, PeopleData>();
            builder.Services.AddTransient<ITeamData, TeamData>();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IPCAWrapper, PCAWrapper>();
            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddSingleton<PlayersState>();
            builder.Services.AddSingleton<App>();
            builder.Services.AddSingleton<HomeTab>();
            builder.Services.AddBlazorBootstrap();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<ExternalAuthService>();
            builder.Services.AddSingleton<IPublicClientApplication>(sp =>
            {
                var pca = PublicClientApplicationBuilder
                    .Create("[ClientId]")
                    .WithAuthority(AzureCloudInstance.AzurePublic, "common")
                    .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                    .WithRedirectUri("[ClientId]://auth")
                    .Build();

                return pca;
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            //return builder.Build();
            builder.Services.AddSingleton<AuthenticatedUser>();
            var host = builder.Build();
            var authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var authService = host.Services.GetRequiredService<ExternalAuthService>();
            authenticatedUser.Principal = user;

            return host;

        }
    }
}
