using ConversorWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConversorWeb.Controllers
{
    public class MonedasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioMonedas repositorioMonedas;

        public MonedasController(ILogger<HomeController> logger, IRepositorioMonedas repositorioMonedas)
        {
            _logger = logger;
            this.repositorioMonedas = repositorioMonedas;
        }

        public IActionResult Index()
        {
            IEnumerable<Moneda> lista = repositorioMonedas.ObtenerMonedas();

            return View(lista);
        }
    }
}
