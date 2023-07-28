using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    public class ReproductorCds
    {

        //     bool          ()
        public bool ProbarCd()
        {
            Console.WriteLine("Por favor, ponga el cd en el reproductor");
            Console.WriteLine("Pulsa el boton de reproducción");
            Console.WriteLine("Indique a continuación si ha escuchado algo");
            var result = Console.ReadLine();

            // Equivale a if (result=="S")/else
            return result == "S";
        }
    }
}
