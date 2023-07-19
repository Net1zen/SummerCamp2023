namespace Modulo6Practica02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int opcion = 0;
                do
                {
                    mostrarMenu();
                    while (!Int32.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.Write("*El valor ingresado no es válido.\nIngrese un número: ");
                    }
                    accionMenu(opcion);
                } while (opcion != 4);

            }
            catch (Exception)
            {
                Console.WriteLine("Error !!!!!");
                //throw;
            }
        }
        public static void mostrarMenu()
        {
            Console.WriteLine("\n================= MENU =================");
            Console.WriteLine("1. Registrarse");
            Console.WriteLine("2. Iniciar Sesión");
            Console.WriteLine("3. Conversor de moneda");
            Console.WriteLine("4. Salir");
            Console.WriteLine(" Elige una opción: ");
        }

        private static void accionMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Has elegido la opción 1");
                    break;
                case 2:
                    Console.WriteLine("Has elegido la opción 2");
                    break;
                case 3:
                    pedirDatosConversion();
                    break;
                case 4:
                    Console.Write("Vuelva pronto!!!");
                    break;
                default:
                    Console.WriteLine("*Elija una opción válida*");
                    break;

            }
        }

        public static void pedirDatosConversion()
        {
            Console.WriteLine("\n*Cambio de Moneda*");
            Console.WriteLine("Euro - EUR \tDolar Estadounidense - USD \tLibraEsterlina - GBP");
            Console.WriteLine("\n*Escriba el código por favor*");
            Console.WriteLine("\nDe: ");
            string codigoMonedaOrigen = Console.ReadLine();
            Console.WriteLine("A: ");
            string codigoMonedaDestino = Console.ReadLine();
    
            Console.WriteLine("Importe: ");
            double importe = 0;
            while (!Double.TryParse(Console.ReadLine(), out importe))
            {
                Console.Write("*El valor ingresado no es válido.\nIngrese un número: ");
            }

            double resultadoConversion = conversionMoneda(codigoMonedaOrigen, codigoMonedaDestino, importe);
            mostrarResultadoConversion(resultadoConversion, codigoMonedaDestino);
        }

        public static double conversionMoneda(string codigoMonedaOrigen, string codigoMonedaDestino, double importe)
        {
            double resultadoConversion = 0;
            switch (codigoMonedaOrigen, codigoMonedaDestino)
            {
                case ("EUR", "USD"):
                    resultadoConversion = importe * 1.12;
                    break;
                case ("EUR", "GBP"):
                    resultadoConversion = importe * 0.85;
                    break;
                case ("USD", "EUR"):
                    resultadoConversion = importe * 0.88;
                    break;
                case ("USD", "GBP"):
                    resultadoConversion = importe * 0.76;
                    break;
                case ("GBP", "EUR"):
                    resultadoConversion = importe * 1.16;
                    break;
                case ("GBP", "USD"):
                    resultadoConversion = importe * 1.30;
                    break;
                default:
                    Console.WriteLine("*Introduzca un código válido*");
                    break;
            }
            return resultadoConversion;
        }

        private static void mostrarResultadoConversion(double resultadoConversion, string codigoMonedaDestino)
        {
            Console.WriteLine($"---------------------------------\nResultado conversion: {resultadoConversion} {codigoMonedaDestino}");
        }
    }
}