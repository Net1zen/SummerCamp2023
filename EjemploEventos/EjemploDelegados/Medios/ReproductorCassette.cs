using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    public class ReproductorCassette
    {
   

        public bool ProbarCassette()
        {
            Console.WriteLine("Por favor, ponga el cassette en el reproductor y pulse play");
            Console.WriteLine("Indique a continuación si ha escuchado algo S/N");
            var result = Console.ReadLine();

            // Equivale a if (result=="S")/else
            return result == "S";
        }



    }
}
