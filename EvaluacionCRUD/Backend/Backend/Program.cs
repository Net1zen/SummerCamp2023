using Contexto;
using Microsoft.EntityFrameworkCore;
using Perfiles;
using Repositorios;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

using Backend;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextoPersonas>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConexionDatos"]);
});

builder.Services.AddScoped<IRepositorioPersonas, RepositorioPersonas>();
builder.Services.AddAutoMapper(typeof(PersonaPerfil));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //PREPARA LA DOCUMENTACION
    app.UseSwaggerUI(); //LA GENERA     
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => //los mapea
{
    endpoints.MapControllers();
});

app.Run();
