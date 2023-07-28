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
    // C-Mostrar el contenido del medio segun el tipo de medio. 
    //   Pasar codigo de barras o identificador para localizar el medio
    //   en la BBDD
    //   CDs - Mostrar lista de canciones
    //   Vinilo - Mostrar lista de canciones en la contraportada
    //   VHS - Mostrar informacion de la pelicula

    internal class Program
    {
        static void Main(string[] args)
        {

            //++ 1-Crear instancias 

            // Crear la instancia del inventario de medios
            var inventarioMedios = new InventarioMedios();

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



            //++ 3-Utilizar delegados

            // Probar un vinilo
            inventarioMedios.ResultadoProbarMedios(probarDiscosDelegado);

            // Probar una cinta VHS
            inventarioMedios.ResultadoProbarMedios(probarCintasVhsDelegado);

        }
    }
}