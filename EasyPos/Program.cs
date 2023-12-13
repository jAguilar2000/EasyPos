using EasyPos.Models;
using EasyPos.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); // Agrega el IHttpContextAccessor

builder.Services.AddScoped<SessionHelper>();

builder.Services.AddDbContext<EasyPosDb>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("EasyPOS")));
//builder.Services.AddDbContext<EasyPosDb>();

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

app.UseAuthorization();

app.MapRazorPages();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
