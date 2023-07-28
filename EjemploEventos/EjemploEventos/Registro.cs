using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploEventos
{
    internal class Registro
    {
        public DateTime FechaControl { get; set; }
        public Registro()
        {
            FechaControl = DateTime.Now;
        }
        internal void Suscribir(Reloj reloj)
        {
            reloj.CambioSegundoEvento += Reloj_GuardaRegistro;
        }

        private void Reloj_GuardaRegistro(object reloj,
                                            InformacionTiempoEventArgs e)
        {

            DateTime fechaRecibida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, e.Hora, e.Minuto, e.Segundo);
            //var fechaDiff = fechaRecibida - FechaControl;

            //TimeSpan timeSpanDiff = GetTimeSpanDiff(fechaRecibida, FechaControl);
            //Console.WriteLine(timeSpanDiff.ToString());

            TimeSpan dateDiff = DateDiff(fechaRecibida, FechaControl);
            /*Console.WriteLine(dateDiff.ToString());
            Console.WriteLine(dateDiff.Seconds);
            */
            if (dateDiff.Seconds >= 10)
            {

                Console.WriteLine($"Fecha: {DateTime.Now} Hora guardada: {e.Hora.ToString()} " +
                                  $"{e.Minuto.ToString()} " +
                                  $"{e.Segundo.ToString()}");
                FechaControl = fechaRecibida;
            }
        }

        // Los dos metodos siguientes devuelven el mismo resultado
        public TimeSpan GetTimeSpanDiff(DateTime timeStart, DateTime timeEnd)
        {
            TimeSpan timeSpanStart = new TimeSpan(timeStart.Ticks);
            TimeSpan timeSpanEnd = new TimeSpan(timeEnd.Ticks);
            return timeSpanEnd.Subtract(timeSpanStart);
        }

        public TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
    }
}
