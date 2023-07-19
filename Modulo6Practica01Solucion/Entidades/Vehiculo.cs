using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vehiculo
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int AnioCompra { get; set; }

        public string Color { get; set; }

        public Vehiculo(int anioCompra, string color)
        {
            AnioCompra = anioCompra;
            Color = color;
        }
        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
        public Vehiculo(int anioCompra, string marca, string modelo, string color)
        {
            AnioCompra = anioCompra;
            Marca = marca;
            Modelo = modelo;    
            Color = color;
        }

    }
}
