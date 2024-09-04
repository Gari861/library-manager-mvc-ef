using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Globalization;
using WebAppLibros.Models;

namespace WebAppLibros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // inyección de dependencia SQL
            builder.Services.AddDbContext<AppDBcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cadena")));


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

            //probandoagregarruta
            app.MapControllerRoute(
                name: "detailsLibroCategoria",
                pattern: "LibrosCategorias/Details/{idLibro}/{idCategoria}",
                defaults: new { controller = "LibrosCategorias", action = "Edit" });

            app.Run();
        }
    }
}
