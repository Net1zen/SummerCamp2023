using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    public class VideoVhs
    {

        //     bool                () 
        public bool ProbarVideoVhs()
        {
            Console.WriteLine("Por favor, ponga la cinta en el reproductor de video");
            Console.WriteLine("Indique a continuación si ha visto el video");
            var result = Console.ReadLine();

            // Equivale a if (result=="S")/else
            return result == "S";
        }


    }
}
