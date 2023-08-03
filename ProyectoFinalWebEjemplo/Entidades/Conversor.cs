using ProyectoFinalConsola;
using ProyectoFinalConsola.Entidades;

namespace Entidades
{
    public class Conversor
    {
        public List<FactorConversion> FactoresConversion { get; set; }
        public List<Moneda> Monedas { get; set; }
        public double Factor { get; set; }
        public double Conversion { get; set; }

        public Conversor()
        {

            LectorJSON lector = new LectorJSON();
            FactoresConversion = lector.LeerFactoresConversion();
            Monedas = lector.LeerMonedas();
        }

        public void ObtenerFactor(string monedaOrigen, string monedaDestino)
        {
            double consultaLinqFactor = FactoresConversion.Where(e => (e.MonedaOrigen == monedaOrigen &&
                                      e.MonedaDestino == monedaDestino)
                                      )
                                      .Select(e => e.Factor).ToList().First(); 

            Factor = consultaLinqFactor; //Refresca
        }

        public void Convertir(double cantidad)
        {
            Conversion = cantidad * Factor;
        }
    }
}
