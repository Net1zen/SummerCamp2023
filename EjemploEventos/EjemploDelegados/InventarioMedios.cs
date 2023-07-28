using EjemploDelegados.Medios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados
{
    
    public class InventarioMedios
    {
        //         1                  2
        //        bool               ()
        // public bool ProbarCd      ()
        // public bool ProbarVinilo  ()
        // public bool ProbarVideoVhs()


        // Declarar el delegado probar medios
        //               1                      2
        public delegate bool ProbarMediosDelegado();


        // Delegado para mostrar info del medio
        public delegate string InfoMedioDelegado(string id);



        public void ResultadoProbarMedios(ProbarMediosDelegado 
                                            probarMediosDelegado)
        {

            // 1-Recibir el medio a probar
            // 2-Probar el medio
            // 3-Si el medio se ha podido reproducir
            //   indicar como archivarlo

            var resultadoPrueba = probarMediosDelegado();

            if (resultadoPrueba)
            {
                Console.WriteLine("El medio funciona, " +
                                  "hay que agregarlo al inventario");
            }
            else
            {
                Console.WriteLine("El medio no funciona, destruirlo");
            }



            //var tipo = medio.GetType().FullName;
            //if (tipo == "Tocadiscos")
            //{
            //    var obj = (Tocadiscos)medio;
            //    if (obj.ProbarVinilo())
            //    {
            //        Console.WriteLine("instrucciones para almacenar vinilo");
            //    }
            //}





        }


    }
}
