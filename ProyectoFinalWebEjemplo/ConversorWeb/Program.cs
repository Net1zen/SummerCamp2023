using ConversorWeb.Models;
using ConversorWeb.Servicios;

var builder = WebApplication.CreateBuilder(args);

// 1-Crear interfaz IMail
// 2-Crear dos clases MailDesarrollo y MailProduccion
// 3-Configurar el servicio 
// 4-Agregar interfaz en el constructor
// 5-Enviar un correo en el momento que va a la pagina Privacy

//++ Add services to the container.
builder.Services.AddControllersWithViews(); // MVC
builder.Services.AddScoped<IServicioMoneda, ServicioMoneda>(); // En toda apliacion cuando yo pida un IServicioMoneda recibire instanciado un ServicioMoneda
builder.Services.AddScoped<IRepositorioMonedas, RepositorioMonedasMemoria>();

var app = builder.Build();

//++ Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
