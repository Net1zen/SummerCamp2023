using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {

        public Conversor conversor { get; set; }

        private Dictionary<int, Action> Opciones { get; set; }

        public Menu() { 
        
            conversor = new Conversor();

            Opciones = new Dictionary<int, Action>
            {
                { 1, () => { Console.WriteLine("Has elegido la opción 1"); } },
                { 2, () => { Console.WriteLine("Has elegido la opción 2"); } },
                { 3, () => { HacerConversion(); } },
                { 4, () => { MostrarMonedas(); } },
                { 5, () => { Console.WriteLine("Vuelva pronto!!!"); } }
            };
        }
        public void Ejecutar()
        {
            try
            {
                int opcion = 0;
                do
                {
                    MostrarMenu();
                    while (!Int32.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.Write("*El valor ingresado no es válido.\nIngrese un número: ");
                    }
                    AccionMenu(opcion);
                } while (opcion != 5);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }

        public void MostrarMenu()
        {
            Console.WriteLine("\n================= MENU =================\n");
            Console.WriteLine("1. Registrarse");
            Console.WriteLine("2. Iniciar Sesión");
            Console.WriteLine("3. Conversor de moneda");
            Console.WriteLine("4. Mostrar lista de monedas");
            Console.WriteLine("5. Salir");
            Console.Write("\nElige una opción: ");
        }

        private void AccionMenu(int numOpcion)
        {
            try
            {
                var accion = Opciones[numOpcion];
                accion();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("*Elija una opción válida*");
            }
        }

        public void HacerConversion()
        {
            Console.WriteLine("\n=============== CONVERSOR ===============");
            //Console.WriteLine("Euro - EUR \tDolar Estadounidense - USD \tLibra Esterlina - GBP");
            MostrarMonedas();
            Console.WriteLine("\n*Escriba el código por favor*");
            Console.Write("\nDe: ");
            string codigoMonedaOrigen = Console.ReadLine();
            Console.Write("A: ");
            string codigoMonedaDestino = Console.ReadLine();

            Console.Write("Importe: ");
            double importe;
            while (!Double.TryParse(Console.ReadLine(), out importe))
            {
                Console.Write("*El valor ingresado no es válido.\nIngrese un número: ");
            }

            conversor.ObtenerFactor( codigoMonedaOrigen, codigoMonedaDestino);
            conversor.Convertir(importe);

            Console.WriteLine($"---------------------------------\nResultado conversion: {conversor.Conversion} {codigoMonedaDestino}");


        }

        public void MostrarMonedas()
        {
            Console.WriteLine("\n\tLista de monedas disponibles:\n");
            foreach (var moneda in conversor.Monedas)
            {
                Console.WriteLine($"\t{moneda.Codigo} - {moneda.Nombre}");
            }
        }

    }
}
