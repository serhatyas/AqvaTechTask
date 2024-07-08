using AqvaTechTask.Data;
using AqvaTechTask.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static AqvaTechTask.Service.NewsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add custom services
builder.Services.AddSingleton<NewsService>();
builder.Services.AddSingleton<CrawlerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
