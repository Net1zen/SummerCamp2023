using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorWeb.Utils
{
    public class MonedaJson
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public MonedaJson() { }
        public MonedaJson(string codigo, string nombre, string simbolo)
        {
            Code = codigo;
            Name = nombre;
            Symbol = simbolo;
        }
    }
}
