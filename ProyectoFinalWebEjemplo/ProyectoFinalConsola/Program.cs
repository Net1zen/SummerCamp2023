using Entidades;

namespace ProyectoFinalConsola
{
    public class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.Ejecutar();

            ClienteAPI.GetApiResponse("v1/latest?apikey=fca_live_cV1mDh79gHYunHYxMEIeuL6CIINDyjmpDPXUvCBf").Wait();




        }
    }
}