using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    public class Tocadiscos 
    {

 
        //     bool              ()
        public bool ProbarVinilo()
        {
            Console.WriteLine("Por favor, ponga el disco en el tocadiscos");
            Console.WriteLine("Indique a continuación si ha escuchado algo S/N");
            var result = Console.ReadLine();

            // Equivale a if (result=="S")/else
            return result == "S";
        }

        public string ObtenerCancionesDisco(string codigoBarras)
        {
            // Buscar en BBDD codigoBarras
            // devolver resultado
            return $"Lista de canciones del disco {codigoBarras} estan en la contraportada";
        }


    }
}
