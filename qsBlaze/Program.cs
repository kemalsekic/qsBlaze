using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using qsBlaze.Areas.Identity;
using qsBlaze.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using DataAccessLibrary.Chat;
using Microsoft.AspNetCore.ResponseCompression;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Data;
using qsBlaze.Data.UserInfo;
using qsBlaze.Shared.HelperProcs;
using qsBlaze.Shared.GetInfo;
using qsBlaze.Shared.Hubs;
using DataAccessLibrary.Data.Games;
using DataAccessLibrary.Data.Teams;
using DataAccessLibrary.Interfaces.Games;

var builder = WebApplication.CreateBuilder(args);

//var conStrings = builder.Configuration

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AzureConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IPeopleData, PeopleData>();
builder.Services.AddTransient<ISkillsData, SkillsData>();
builder.Services.AddTransient<IChatData, ChatData>();
builder.Services.AddTransient<ITicketData, TicketData>();
builder.Services.AddTransient<IAppUserData, AppUserData>();
builder.Services.AddTransient<IHelperUserAdded, HelperUserAdded>();
builder.Services.AddTransient<IGetActiveUserClass, GetActiveUserClass>();
builder.Services.AddTransient<IGameData, GameData>();
builder.Services.AddTransient<ITeamData, TeamData>();
builder.Services.AddTransient<ISportData, SportData>();
builder.Services.AddTransient<IPlayerData, PlayerData>();
builder.Services.AddTransient<IVoteData, VoteData>();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapBlazorHub();
//    endpoints.MapFallbackToPage("/_Host");
//});

app.MapControllers();
app.MapBlazorHub();
app.MapHub<VoteHub>("/votehub");
app.MapFallbackToPage("/_Host");

app.Run();
