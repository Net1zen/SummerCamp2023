using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarJson
{
    public class JsonFileProcessor
    {
        public string InputFilePath { get; }
        public string OutputFilePath { get; }

        public JsonFileProcessor(string inputFilePath)
        {
            InputFilePath = inputFilePath;
        }

        public void Process()
        {
            // Using read all text
            string jsonMonedas = File.ReadAllText(InputFilePath);
            List<Moneda> monedas = JsonConvert.DeserializeObject<List<Moneda>>(jsonMonedas);
            foreach (Moneda moneda in monedas)
            {
                Console.WriteLine($"{moneda.codigo} \t{moneda.nombre}");
            }
        }
    }
}
