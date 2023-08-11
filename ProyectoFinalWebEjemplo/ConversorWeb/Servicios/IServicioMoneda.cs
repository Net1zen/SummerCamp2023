using ConversorWeb.Models;

namespace ConversorWeb.Servicios
{
    public interface IServicioMoneda
    {
        List<Moneda> Monedas { get; set; }

        List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}
