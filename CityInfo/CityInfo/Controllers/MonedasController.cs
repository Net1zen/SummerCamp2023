using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorios;

namespace CityInfo.API.Controllers
{
    
    //+ 1-Ruta
    // [Route("api/[controller]")] - la ruta es fija (no se cambia)
    [Route("api/Monedas")]
    // 2-Controlador API
    [ApiController]
    public class MonedasController : ControllerBase //+ 3-Hereda de controlador API
    {
        private readonly IRepositorioMonedas repositorioMonedas;

        public MonedasController(IRepositorioMonedas repositorioMonedas)
        {
            this.repositorioMonedas = repositorioMonedas;
        }

        // A-Verbo Http
        [HttpGet]
        public ActionResult<IEnumerable<Moneda>> ObtenerMonedas()
        {


            var lista = repositorioMonedas.ObtenerMonedas();
            //+ C-Devolver resultado y codigo de estado
            return Ok(lista);
        }
    }
}
