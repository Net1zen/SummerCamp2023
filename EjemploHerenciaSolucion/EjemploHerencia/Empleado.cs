using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploHerencia
{
    public partial class Empleado
    {
        public string Nombre
        {
            get;set;
        }

        /*public Empleado()
        {
            Nombre = "";
        }*/

        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        protected double diasVacaciones;

        public override string ToString()
        {
            return $"\t Empleado \tNombre: {Nombre} " + $" \tDias Vacaciones: {diasVacaciones} ";
        }
    }
}