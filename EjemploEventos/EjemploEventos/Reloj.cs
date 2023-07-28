namespace EjemploEventos
{
    internal class Reloj
    {

        // Delegado
        public delegate void CambioSegundoDelegado(object reloj,
                        InformacionTiempoEventArgs informacionTiempo);



        // Evento
        public event CambioSegundoDelegado CambioSegundoEvento;



        public Reloj()
        {
        }

        private int segundo;
        public void IniciaReloj()
        {
            DateTime fechaHoraActual;
            for (; ; )
            {
                Thread.Sleep(100);


                fechaHoraActual = DateTime.Now;
                if (fechaHoraActual.Second != segundo)
                {
                    //Console.WriteLine(segundo);
                    // Guardar info tiempo cada segundo
                    var informacionTiempo = new InformacionTiempoEventArgs(
                                            fechaHoraActual.Hour,
                                            fechaHoraActual.Minute,
                                            fechaHoraActual.Second);


                    // Lanzar el evento
                    if (CambioSegundoEvento != null)
                    {
                        CambioSegundoEvento(this, informacionTiempo);
                    }
                }


                segundo = fechaHoraActual.Second;
            }

        }


    }
}