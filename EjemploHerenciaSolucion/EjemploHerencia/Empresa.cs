using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploHerencia
{
    public class Empresa
    {
        public string Nombre
        {
            get;set;
        }

        public string Telefono
        {
            get;set;
        }

        public Empresa(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}