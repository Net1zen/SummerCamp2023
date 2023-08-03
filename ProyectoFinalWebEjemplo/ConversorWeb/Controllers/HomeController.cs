using ConversorWeb.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalConsola;
using System.Diagnostics;

namespace ConversorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.saludo = "Hola mundo desde C#";
            ViewBag.fecha = DateTime.Now;

            //ViewBag.Euro = new Moneda
            //{
            //    Codigo = "EUR",
            //    Nombre = "Euro",
            //    ValorEnDolares = 1.113
            //};

            Conversor conversor = new Conversor();
            foreach (var moneda in conversor.Monedas)
            {

                ViewBag.Moneda += $"\t{moneda.Codigo} - {moneda.Nombre}";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}