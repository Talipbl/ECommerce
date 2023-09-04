using ECommerce.ImageAPI.Helpers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IFileHelper, FileHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath + "/source"),
    RequestPath = "",
    OnPrepareResponse =
        r =>
        {
            string path = r.File.PhysicalPath;
            if (path.EndsWith(".gif") || path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".svg") || path.EndsWith(".webp"))
            {
                TimeSpan maxAge = new TimeSpan(99, 0, 0, 0);
                r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
            }
        }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
