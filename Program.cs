using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AP1_AP_Oly.Data;
using AP1_AP_Oly.DAL;
using Microsoft.EntityFrameworkCore;
using AP1_AP_Oly.BLL;

var builder = WebApplication.CreateBuilder(args);


var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(ConStr)
);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<AportesBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
