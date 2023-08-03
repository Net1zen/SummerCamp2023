using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Entidades
{
    public class FactorConversion
    {
        //en todas las tablas hace falta id!! 
        public int Id { get; set; }   

        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }

        public double Factor { get; set; }

        public FactorConversion(int id, string monedaOrigen, string monedaDestino, double factor)
        {
            Id = id;
            MonedaOrigen = monedaOrigen;
            MonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}

