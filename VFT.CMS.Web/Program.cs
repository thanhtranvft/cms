using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System.Reflection;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Menus;
using VFT.CMS.Application.Services;
using VFT.CMS.EntityFrameworkCore;
using VFT.CMS.Web.Areas.Admin.Common;
using VFT.CMS.Web.Areas.Admin.Data;
using VFT.CMS.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// For Entity Framework
var connectionString = builder.Configuration["ConnectionStrings:Database"];
builder.Services.AddDbContext<CMSDbContext>(o => o.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOption => { sqlOption.EnableRetryOnFailure(); }));

//Identity
builder.Services.AddIdentity<CMSIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CMSDbContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = $"/Admin/Account/Login";
    options.LogoutPath = $"/Admin/Account/Logout";
    options.AccessDeniedPath = $"/Admin/Account/AccessDenied";
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

GlobalHelper.RegisterServiceLifetimer(builder.Services);
GlobalHelper.RegisterAutoMapper(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Add middleware here
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Populate default user admin
DataSeed.Seed(app.Services).Wait();

app.Run();
