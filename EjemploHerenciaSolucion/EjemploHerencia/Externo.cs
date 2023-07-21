using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploHerencia
{
    public class Externo : Empleado
    {
        public Externo(string nombre, Empresa empresa) : base(nombre)
        {
            Empresa = empresa;
        }

        public Empresa Empresa { get; set; }

        public override string ToString()
        {
            return $"\t Externo \tNombre: {Nombre} " + 
                $"\tDias Vacaciones: {diasVacaciones} \tJefe: {Jefe.Nombre} \tEmpresa: {Empresa.Nombre}";
        }

        public override void CalculoVacaciones()
        {
            base.CalculoVacaciones();
            diasVacaciones += 10;
        }
    }
}