namespace EjemploHerencia
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Empleado juan = new Empleado("Juan");

            Administrador maria = new Administrador("Maria");

            juan.Jefe = maria;

            Trabajador jose = new Trabajador("Jose");

            List<Empleado> empleados = new List<Empleado>();
            empleados.Add(juan);
            empleados.Add(maria);
            empleados.Add(jose);

            Console.WriteLine("-------------------------------------------");
            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine("\n"+empleado.ToString());
            }
            Console.WriteLine("-------------------------------------------");

        }
    }
}