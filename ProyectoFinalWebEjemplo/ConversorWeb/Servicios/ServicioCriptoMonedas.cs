using ConversorWeb.Models;

namespace ConversorWeb.Servicios
{
    public class ServicioCriptoMonedas : IServicioMoneda
    {
        public List<Moneda> Monedas { get; set; }

        public List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}
