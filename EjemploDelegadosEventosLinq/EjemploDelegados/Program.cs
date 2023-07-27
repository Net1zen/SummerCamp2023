using EjemploDelegados.Medios;
using static EjemploDelegados.InventarioMedios;

namespace EjemploDelegados
{

    // Hay que crear una aplicación para 
    // el archivo de medios de una biblioteca publica
    // de modo que:
    // A-Segun el tipo de medio indique al usuario los pasos
    //   a dar para reproducir ese medio y verificar 
    //   si está en buen estado para archivarlo
    //   o bien desecharlo si está en mal estado
    // B-Crear una aplicación que permita indicar
    //   los pasos a dar independientemente del medio
    // C-Mostrar el contenido del medio segun el tipo de medio
    //   CDs - Mostrar lista de canciones
    //   Vinilo - Mostrar lista de canciones en la contraportada
    //   VHS - Mostrar información de la pelicula

    internal class Program
    {
        static void Main(string[] args)
        {

            //++ 1-Crear instancias 

            // Crear la instancia del inventario de medios
            var inventarioMedios = new InventarioMedios();

            // Crear instancia reproductor de cassette
            var reproductorCassette = new ReproductorCassette();

            // Crear instancia reproductor de Cd
            var reproductorCd = new ReproductorCds();

            // Crear instancia Tocadiscos
            var tocaDiscos = new Tocadiscos();

            // Crear instancia reproductor VHS
            var videoVhs = new VideoVhs();


            //++ 2-Crear instancias de delegados
            // Crear instancia del delegado para probar discos de vinilo
            ProbarMediosDelegado probarDiscosDelegado =
                                 new ProbarMediosDelegado(tocaDiscos.ProbarVinilo);
            // Crear instancia del delegado para probar cintas vhs
            ProbarMediosDelegado probarCintasVhsDelegado =
                                 new ProbarMediosDelegado(videoVhs.ProbarVideoVhs);

            // Crear instancia del delegado para mostrar información de discos de vinilo
            InfoMedioDelegado infoDiscoDelegado =
                                new InfoMedioDelegado(tocaDiscos.ObtenerCancionesDisco);

            // Crear instancia del delegado para mostrar información de cintas vhs
            InfoMedioDelegado infoCintasVhsDelegado =
                                new InfoMedioDelegado(videoVhs.ObtenerInfoCintaVhs);



            //++ 3-Utilizar delegados

            // Probar un vinilo
            //inventarioMedios.ResultadoProbarMedios(probarDiscosDelegado); // Recibe un metodo como parametro en el constructor

            // Probar una cinta VHS
            //inventarioMedios.ResultadoProbarMedios(probarCintasVhsDelegado);

            // Información de un vinilo
            string codigoBarras = "";
            while (codigoBarras == "")
            {
                Console.WriteLine("Escriba el codigo de barras del disco: ");
                codigoBarras = Console.ReadLine();
            }
            inventarioMedios.ResultadoInfoMedio(infoDiscoDelegado,codigoBarras);

            // Información de una cinta vhs
            /*Console.WriteLine("Escriba el codigo de barras de la cinta vhs: ");
            string codigoBarras = Console.ReadLine();
            inventarioMedios.ResultadoInfoMedio(infoDiscoDelegado, codigoBarras);*/


        }
    }
}