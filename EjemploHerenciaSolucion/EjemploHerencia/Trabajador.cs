using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploHerencia
{
    public class Trabajador : Empleado
    {
        public Trabajador(string nombre, string turno) : base(nombre)
        {
            Turno = turno;
        }

        public string Turno { get; set; }

        public override string ToString()
        {
            try
            {
                return $"Trabajador \tNombre: {Nombre} " + 
                    $"\tDias Vacaciones: {diasVacaciones} \tTurno: {Turno} \tJefe: {Jefe.Nombre}";
            }
            catch (System.NullReferenceException nre)
            {
                // Jefe.Nombre = "Ninguno";
                return nre.Message;
            }
        }

        public override void CalculoVacaciones()
        {
            base.CalculoVacaciones();
            diasVacaciones += 15;
        }
    }
}