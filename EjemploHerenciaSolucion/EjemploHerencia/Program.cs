namespace EjemploHerencia
{
    public class Program
    {

        // 5 - Crear un excpecion peronsalizada ErrorBaseDatos que lmacena la fecha y hora de la excepcion y un mensaje personalizado
        // 6 - Ocurre al pedir la plaza de parking de un administrativo
        // 7 - Identificar mediante reflexión los diferentes tipos de empleados de modo que si
        //      a) Es trabajador muestra el turno
        //      b) Es administrativo y tiene plaza de parking, mostrar plaza de parking
        //      c) Es externo mostrar nombre de empresa de la que viene
        static void Main(string[] args)
        {
            // Crear empresas
            Empresa acciona = new Empresa("Acciona", "848 693 741");

            // Crear empleados
            Empleado maria = new Empleado("Maria");
            Administrador juan = new Administrador("Juan", true);
            Trabajador jose = new Trabajador("Jose", "mañana");
            Externo julian = new Externo("Julian", acciona);
            Administrador jhon = new Administrador("Jhon", false);
            Externo jesus = new Externo("Jesus", null);
            juan.NumPlaza = "B-4";

            // Asignar jefes (instancia)
            maria.Jefe = juan;
            julian.Jefe = juan;
            jose.Jefe = juan;

            // Crear lista de empleados
            List<Empleado> empleados = new List<Empleado>();
            empleados.Add(maria);
            empleados.Add(juan);
            empleados.Add(jose);
            empleados.Add(julian);
            empleados.Add(jhon);
            empleados.Add(jesus);


            // Prueba control de excepcion
            /*try
            {
                if (juan.TieneParking)
                {
                    Console.WriteLine(jhon.PlazaParking());
                }
            }
            catch (ErrorBaseDatosExcepcion errorBaseDatosExcepcion)
            {
                Console.WriteLine(errorBaseDatosExcepcion.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*/

            // Mostrar dias de vacaciones de los empleados que empiezen por J
            /*try
            {
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre.StartsWith("J"))
                {
                    empleado.CalculoVacaciones();
                    Console.WriteLine("\n" + empleado.ToString());
                }
            }
            } catch(ErrorBaseDatosExcepcion errorBaseDatosExcepcion) {
                Console.WriteLine(errorBaseDatosExcepcion.ToString());
            }*/

            // SELECT * FROM empleados where empleados.Nombre.StartsWith("J")
            IEnumerable<Empleado> listaEmpleadosJ = from empleado in empleados
                                                    where empleado.Nombre.StartsWith("J")
                                                    orderby empleado.Nombre
                                                    select empleado;

            // Mostrar lista de empleados
            Console.WriteLine("-------------------------------------------");
            foreach (Empleado empleado in empleados)
            {
                //Console.WriteLine("\n"+empleado.ToString());
                var tipo = empleado.GetType().Name;
                //Console.WriteLine(tipo);

                try
                {
                    switch (tipo)
                    {
                        case "Trabajador":
                            // TODO: Mostrar turno #1250
                            Trabajador trabajador = (Trabajador)empleado;
                            Console.WriteLine($"{trabajador.Nombre} - Turno: {trabajador.Turno}");
                            //Console.WriteLine(trabajador.ToString());
                            break;
                        case "Administrador":
                            // TODO: Mostrar plaza de parking
                            Administrador administrador = (Administrador)empleado;
                            if (administrador.TieneParking)
                            {
                                try
                                {
                                    Console.WriteLine($"{administrador.Nombre} - Plaza parking: {administrador.PlazaParking()}");
                                }
                                catch (ErrorBaseDatosExcepcion errorBaseDatosExcepcion)
                                {
                                    Console.WriteLine(errorBaseDatosExcepcion.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{administrador.Nombre} - Plaza parking: No tiene");
                            }
                            break;
                        case "Externo":
                            // TODO: Mostrar nombre de empresa
                            Externo externo = (Externo)empleado;
                            if (externo.Empresa == null)
                            {
                                Console.WriteLine($"{externo.Nombre} - Empresa: No tiene empresa");
                                
                            }
                            else
                            {
                                Console.WriteLine($"{externo.Nombre} - Empresa: {externo.Empresa?.Nombre}");
                            }
                            // Pregunta si tiene Empresa y luego si tiene nombre y si no (si es nulo) muestra el mensaje
                            //Console.WriteLine($"{externo.Nombre} - Empresa: " + externo.Empresa==null?"No tiene empresa":externo.Empresa?.Nombre);
                            //Console.WriteLine($"{externo.Nombre} - Empresa: " + externo.Empresa?.Nombre??"No tiene empresa");

                            break;
                            //empleado.CalculoVacaciones();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("-------------------------------------------");




        }
    }
}