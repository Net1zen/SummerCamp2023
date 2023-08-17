using ContextoDB;
using DataSource;
using freecurrencyapi;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Repositorios;

namespace CityInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //+ 1-Add services to the container.

            builder.Services.AddControllers();

            // Documentador de la API    
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ContextoConversor>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:ConexionDatos"]);
            });

            //builder.Services.AddScoped<IServicioMoneda, ServicioMoneda>(); // En toda apliacion cuando yo pida un IServicioMoneda recibire instanciado un ServicioMoneda
            builder.Services.AddScoped<IRepositorioMonedas, RepositorioMonedas>();
            builder.Services.AddScoped<IDataCollector, DataCollector>();
            builder.Services.AddScoped<Freecurrencyapi>();

            var app = builder.Build();

            //+ 2-Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Preapara la documentación
                app.UseSwaggerUI(); // Genera la documentación
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}