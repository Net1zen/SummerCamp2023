using Newtonsoft.Json;
using ProyectoFinalConsola;
using ProyectoFinalConsola.Entidades;

namespace Entidades
{
    internal class LectorJSON
    {
        public LectorJSON()
        {

        }
        public List<FactorConversion> LeerFactoresConversion()
        {
            //List<FactorConversion> factores = JsonConvert.DeserializeObject<List<FactorConversion>>(json);
            //string directorioActual = new DirectoryInfo(path: Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            //string factoresConversionJson = File.ReadAllText($"{directorioActual}\\JSONS\\FactoresConversion.json");

            // *Cambio* C:\Curso\Proyecto\ProyectoFinalConsola\ProyectoFinalConsola\JSONS\

            string directorioActual = new DirectoryInfo(path: Directory.GetCurrentDirectory()).Parent.FullName;
            string factoresConversionJson = File.ReadAllText($"{directorioActual}\\ProyectoFinalConsola\\JSONS\\FactoresConversion.json");
            Dictionary<string, List<FactorConversion>> factores = JsonConvert.DeserializeObject<Dictionary<string, List<FactorConversion>>>(factoresConversionJson);
            return factores["factores"];
        }

        public List<Moneda> LeerMonedas()
        {
            //string directorioActual = new DirectoryInfo(path: Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            //string monedasJson = File.ReadAllText($"{directorioActual}\\JSONS\\Monedas.json");
            string directorioActual = new DirectoryInfo(path: Directory.GetCurrentDirectory()).Parent.FullName;
            string monedasJson = File.ReadAllText($"{directorioActual}\\ProyectoFinalConsola\\JSONS\\Monedas.json");
            List<Moneda> monedas = JsonConvert.DeserializeObject<List<Moneda>>(monedasJson);
            return monedas;
        }

    }
}
