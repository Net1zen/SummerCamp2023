
namespace ConversorWeb.Utils
{
    public class Conversor
    {
        public List<FactorBaseDolarJson> FactoresConversion { get; set; }
        public double Factor { get; set; }
        public double Conversion { get; set; }

        public Conversor()
        {
            //DataCollector dataCollector = new DataCollector();
            //dataCollector.CallApiFactores().Wait();
            //FactoresConversion = dataCollector.LeerFactoresConversionJson();
        }

        public void ObtenerFactor(string monedaOrigen, string monedaDestino)
        {
            double factorMonedaOrigen = FactoresConversion.Where(e => (e.MonedaDestino == monedaOrigen))
                                          .Select(e => e.Factor).ToList().First();
            double factorMonedaDestino = FactoresConversion.Where(e => (e.MonedaDestino == monedaDestino))
                                          .Select(e => e.Factor).ToList().First();
            Factor = factorMonedaDestino / factorMonedaOrigen;

        }

        public void Convertir(double cantidad)
        {
            Conversion = cantidad * Factor;
        }
    }
}
