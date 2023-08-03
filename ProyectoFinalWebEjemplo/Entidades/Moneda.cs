using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola
{
    public class Moneda
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
       
        public double ValorEnDolares { get; set; } //TODO: Provisional!!!!

        public Moneda()
        {
            
        }
        public Moneda(string nombre, string codigo, double valorEnDolares)
        {
            Nombre = nombre;
            Codigo = codigo;
            ValorEnDolares = valorEnDolares;
        }
    }
}
