using ConversorWeb.Models;

namespace ConversorWeb.Servicios
{
    public class ServicioMoneda : IServicioMoneda
    {
        private readonly ILogger<ServicioMoneda> logger;
        public ServicioMoneda(ILogger<ServicioMoneda> logger)
        {
            this.logger = logger;
        }
        public List<Moneda> Monedas { get; set; }

        public List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}
