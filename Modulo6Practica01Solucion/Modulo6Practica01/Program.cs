using Entidades;

namespace Modulo6Practica01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                mostrarMenu();
                Console.WriteLine("Elija una opción: ");
                opcion = Int32.Parse(Console.ReadLine());
                accionMenu(opcion);
            } while (opcion != 4);

        }

        private static void mostrarMenu()
        {
            Console.WriteLine("------------- Menu -------------");
            Console.WriteLine("1. Crear vehiculo especificando año de compra y color");
            Console.WriteLine("2. Crear vehiculo especificando marca y modelo");
            Console.WriteLine("3. Crear vehiculo especificando todo");
            Console.WriteLine("4. Salir");
        }
        private static void accionMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    opcion1();
                    break;
                case 2:
                    opcion2();
                    break;
                case 3:
                    opcion3();
                    break;
                default:
                    Console.WriteLine("*Opción no válida*");
                    break;
            }
        }
        private static void opcion1()
        {
            Console.WriteLine("\n- Información vehiculo -");
            Console.WriteLine("Año de compra:");
            int anioCompra = int.Parse(Console.ReadLine());
            Console.WriteLine("Color:");
            string color = Console.ReadLine();
            var vehiculo = new Vehiculo(anioCompra, color);
            Console.WriteLine("Vehiculo creado: " + vehiculo.AnioCompra + vehiculo.Color);
        }

        private static void opcion2()
        {
            Console.WriteLine("\n- Información vehiculo -");
            Console.WriteLine("Marca:");
            string marca = Console.ReadLine();
            Console.WriteLine("Modelo:");
            string modelo = Console.ReadLine();
            var vehiculo = new Vehiculo(marca, modelo);
            Console.WriteLine("Vehiculo creado: " + vehiculo.Marca + vehiculo.Modelo);
        }

        private static void opcion3()
        {
            Console.WriteLine("\n- Información vehiculo -");
            Console.WriteLine("Año de compra:");
            int anioCompra = int.Parse(Console.ReadLine());
            Console.WriteLine("Marca:");
            string marca = Console.ReadLine();
            Console.WriteLine("Modelo:");
            string modelo = Console.ReadLine();
            Console.WriteLine("Color:");
            string color = Console.ReadLine();
            var vehiculo = new Vehiculo(anioCompra, marca, modelo, color);
            Console.WriteLine("Vehiculo creado: " + vehiculo.AnioCompra + vehiculo.Marca + vehiculo.Modelo + vehiculo.Color);
        }

    }
}