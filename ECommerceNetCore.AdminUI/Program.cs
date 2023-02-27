using Autofac.Extensions.DependencyInjection;
using Autofac;
using ECommerceNetCore.Application.ServiceRegistrations;
using ECommerceNetCore.Persistance.ServiceRegistrations;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Persistance.Repositories;
using ECommerceNetCore.AdminUI.Helpers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

// Add services to the container.
builder.Services.AddSingleton<ISystemRepository, EfSystemRepository>();
builder.Services.AddSingleton<IFileHelper, FileHelper>();

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationService();

//bkz: https://learn.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacPersistanceModule()));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
