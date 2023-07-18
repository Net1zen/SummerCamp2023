using Entidades;

namespace ImpuestoCirculacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear vehiculos
            var vehiculo1 = new Vehiculo("Ford", "Focus", 2001, 5000);
            var vehiculo2 = new Vehiculo("Hyndai", "i3", 2020, 10000);
            var vehiculo3 = new Vehiculo("Seat", "Ibiza", 2015, 9000);
            vehiculo1.SetEtiqueta(Vehiculo.Etiqueta.ECO);
            vehiculo2.SetEtiqueta(Vehiculo.Etiqueta.B);
            vehiculo3.SetEtiqueta(Vehiculo.Etiqueta.CERO);


            // Crear lista vehiculos
            var listaVehiculos = new List<Vehiculo>();
            listaVehiculos.Add(vehiculo1);
            listaVehiculos.Add (vehiculo2);
            listaVehiculos.Add((vehiculo3));

            // Calcular importe de circulación por cada vehiculo
            foreach (var vehiculo in listaVehiculos)
            {
                vehiculo.CalcularImpuestoCirculacion();
            }
        }
    }
}