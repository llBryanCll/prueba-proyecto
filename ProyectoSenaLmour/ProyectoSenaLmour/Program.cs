using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProyectoSenaLmour.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LmourContext>(options=>
        options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(option =>
  {
      option.LoginPath = "/acceso/Index";
      option.ExpireTimeSpan = TimeSpan.FromMinutes(3);
      option.AccessDeniedPath = "/Home/Privacy";


  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=acceso}/{action=Index}/{id?}");

app.Run();
