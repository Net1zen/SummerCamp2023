using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploHerencia
{
    public class Administrador : Empleado
    {
        public Administrador(string nombre, bool tieneParking) : base(nombre)
        {
            TieneParking = tieneParking;
            NumPlaza = "";
        }

        public string NumPlaza { get; set; }
        public bool TieneParking { get; set; }

        public string PlazaParking()
        {
            // TODO: Conectar a BBDD
            throw new ErrorBaseDatosExcepcion("Error al conectar a BBDD", DateTime.Now);
            return TieneParking ? "Plaza A-1" : "No tiene plaza";
        }

        public override string ToString()
        {
            return $"Administrador \tNombre: {Nombre} " + 
                $"\tDias vacaciones: {diasVacaciones} \t{PlazaParking()}";
        }

        public override void CalculoVacaciones()
        {
            base.CalculoVacaciones();
            diasVacaciones += 15;
        }
    }
}