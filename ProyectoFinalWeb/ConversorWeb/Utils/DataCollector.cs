
using ConversorWeb.Models;
using freecurrencyapi;
using Newtonsoft.Json.Linq;

namespace ConversorWeb.Utils
{
    public class DataCollector : IDataCollector
    {
        private readonly string ApiKey = "fca_live_cV1mDh79gHYunHYxMEIeuL6CIINDyjmpDPXUvCBf";
        private readonly IRepositorioMonedas repositorioMonedas;

        public DataCollector(IRepositorioMonedas repositorioMonedas, Freecurrencyapi freecurrencyapi)
        {
            this.repositorioMonedas = repositorioMonedas;
        }

        //Meter info JSON en objetos leyendo directamente del archivo
        public List<MonedaJson> LeerMonedas()
        {
            var freecurrencyapi = new Freecurrencyapi(ApiKey);
            string monedasApi = freecurrencyapi.Currencies("EUR,USD,GBP,JPY,CAD,CNY,INR,KRW,RUB,PHP");
            //freecurrencyapi.Status();

            List<MonedaJson> monedas = new List<MonedaJson>();
            // Deserializar el JSON en un objeto JObject
            JObject jsonObject = JObject.Parse(monedasApi);
            JObject currencies = (JObject)jsonObject["data"];

            foreach (var moneda in currencies)
            {
                string code = moneda.Key;
                string name = moneda.Value["name"].ToString();
                string symbol = moneda.Value["symbol"].ToString();
                Moneda newMoneda = new Moneda { Code = code, Name = name, Symbol = symbol };

                if (repositorioMonedas.ObtenerMoneda(code) == null)
                {
                    // Añade en la base de datos las monedas que obtiene de la API
                    repositorioMonedas.AgregarMoneda(newMoneda);
                }
            }
            return monedas;
            // Guardar en base de datos
        }
    }
}
