using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Application;
using ECommerce.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

builder.Services.AddMvc().AddRazorRuntimeCompilation();

//bkz: https://learn.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacCoreModule()));
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
