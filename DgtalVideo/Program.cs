using DgtalVideo.Data;
using DgtalVideo.Data.Repository;
using DgtalVideo.Data.Repository.Interfaces;
using DgtalVideo.Hubs;
using DgtalVideo.Services;
using DgtalVideo.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DgtalVideo;Integrated Security=True;Connect Timeout=30;";
builder.Services.AddDbContext<WebContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddAuthentication(AuthService.AUTH_KEY)
    .AddCookie(AuthService.AUTH_KEY, option =>
    {
        option.LoginPath = "/Auth/Login";
        option.AccessDeniedPath = "/Auth/Deny";
    });

builder.Services.AddAuthorization();
builder.Services.AddLocalization(options => options.ResourcesPath = "Localizations");

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IReviewsService, ReviewsService> ();
builder.Services.AddScoped<IAdminPanelService, AdminPanelService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICostCalculatorService, CostCalculatorService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
builder.Services.AddScoped<IAdminPanelRepository, AdminPanelRepository>();
builder.Services.AddScoped<IContactFormRepository, ContactFormRepository>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<NoticeHub>("/hub/dgtal");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
