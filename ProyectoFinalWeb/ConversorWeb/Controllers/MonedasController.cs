using ConversorWeb.Models;
using ConversorWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ConversorWeb.Controllers
{
    public class MonedasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioMonedas repositorioMonedas;
        private readonly IDataCollector dataCollector;

        public MonedasController(ILogger<HomeController> logger, IRepositorioMonedas repositorioMonedas, IDataCollector dataCollector)
        {
            _logger = logger;
            this.repositorioMonedas = repositorioMonedas;
            this.dataCollector = dataCollector;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Estoy en el Index de Monedas");
            List<MonedaJson> listaMonedasJson = dataCollector.LeerMonedas();
            IEnumerable<Moneda> lista = repositorioMonedas.ObtenerMonedas();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Alta()
        {

            Moneda moneda = new Moneda { Code = "USE", Name = "Dolar ", Symbol = "$" };
            return View(moneda);
        }

        [HttpPost]
        public IActionResult Alta(Moneda moneda)
        {
            if (repositorioMonedas.ObtenerMoneda(moneda.Code) == null)
            {

                repositorioMonedas.AgregarMoneda(moneda);

            }
            return RedirectToAction("Index");
        }

    }
}
