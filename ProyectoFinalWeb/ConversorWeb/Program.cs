using ConversorWeb.Models;
using ConversorWeb.Utils;
using freecurrencyapi;
using Microsoft.EntityFrameworkCore;

namespace ConversorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //+ 1-Add services to the container.
            builder.Services.AddControllersWithViews(); // MVC

            builder.Services.AddDbContext<ContextoConversor>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:ConexionDatos"]);
            });

            //builder.Services.AddScoped<IServicioMoneda, ServicioMoneda>(); // En toda apliacion cuando yo pida un IServicioMoneda recibire instanciado un ServicioMoneda
            builder.Services.AddScoped<IRepositorioMonedas, RepositorioMonedas>();
            builder.Services.AddScoped<IDataCollector, DataCollector>();
            builder.Services.AddScoped<Freecurrencyapi>();
            
            // Mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            //+ 2-Configure the HTTP request pipeline.
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
        }
    }
}