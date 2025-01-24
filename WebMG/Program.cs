using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebMG.Data;
using MG.Models;
using MG.DataAccess.Repository.IRepository;
using MG.DataAccess.Repository;
using ICenterRepository = MG.DataAccess.Repository.IRepository.ICenterRepository;
using MGWeb.Interfaces;
using MGWeb.Repository;
using Microsoft.AspNetCore.Identity;
using MGWeb.Areas.Public.Interfaces;
using MGWeb.Areas.Public.Repository;
using MG.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IFamRepository, FamRepository>();
builder.Services.AddScoped<IStuRepository, StuRepository>();
builder.Services.AddDbContext<MGDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MGConnectionString"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MGDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Public}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
