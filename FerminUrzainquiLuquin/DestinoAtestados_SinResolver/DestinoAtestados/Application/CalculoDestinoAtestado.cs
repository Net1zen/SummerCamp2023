using DestinoAtestados.Application.Interfaces;
using DestinoAtestados.Application.Models;
using System.Collections;

namespace DestinoAtestados.Application
{
    public class CalculoDestinoAtestado
    {
        private ICalendarioService _calendarioGuardiaService;

        public CalculoDestinoAtestado(ICalendarioService calendarioGuardiaService)
        {
            _calendarioGuardiaService = calendarioGuardiaService;
        }

        public DestinoAtestado CalcularDestino(DatosAtestado datosAtestado)
        {
            var juzgadoViolencia = _calendarioGuardiaService.ObtenerOrganoJudicialGuardia(Domain.TipoOrganoJudicial.JuzgadoViolenciaSobreLaMujer, datosAtestado.FechaPresentacion);
            var juzgadoInstruccion = _calendarioGuardiaService.ObtenerOrganoJudicialGuardia(Domain.TipoOrganoJudicial.JuzgadoIntruccion, datosAtestado.FechaPresentacion);
            DestinoAtestado destinoAtestado = null;

            if (string.IsNullOrEmpty(datosAtestado.CodigoClaseRegistro))
            {
                throw new ArgumentException(paramName: "CodigoClaseRegistro", message: datosAtestado.CodigoClaseRegistro);
            }

            if (EsAtestadoViolencia(datosAtestado))
            {
                if (datosAtestado.IncluyeDetenido)
                {
                    if (EsDiaInhabil(datosAtestado))
                    {
                        destinoAtestado = new DestinoAtestado(juzgadoInstruccion, DateTime.Now);
                    }
                    else
                    {
                        destinoAtestado = new DestinoAtestado(juzgadoViolencia, DateTime.Now);
                    }
                }
                else if (datosAtestado.IncluyeOrdenProteccion)
                {
                    if (EsDiaInhabil(datosAtestado))
                    {
                        destinoAtestado = new DestinoAtestado(juzgadoInstruccion, DateTime.Now);
                    }
                    else
                    {
                        destinoAtestado = new DestinoAtestado(juzgadoViolencia, DateTime.Now);
                    }
                }
                else if (!datosAtestado.IncluyeDetenido && !datosAtestado.IncluyeOrdenProteccion)
                {
                    destinoAtestado = new DestinoAtestado(juzgadoViolencia, DateTime.Now);
                }
            }
            else
            {
                destinoAtestado = new DestinoAtestado(juzgadoInstruccion, DateTime.Now);
            }

            return destinoAtestado;
        }

        private bool EsAtestadoViolencia(DatosAtestado datosAtestado)
        {
            return datosAtestado.CodigoClaseRegistro.StartsWith('8');
        }

        //private bool EsDiaInhabil(DatosAtestado datosAtestado)
        //{
        //    var diasInhabiles = new ArrayList() {
        //        DayOfWeek.Saturday, DayOfWeek.Sunday
        //    };

        //    return diasInhabiles.Contains(datosAtestado.FechaPresentacion.DayOfWeek);
        //}
        private bool EsDiaInhabil(DatosAtestado datosAtestado)
        {

            if (datosAtestado.FechaPresentacion.Equals(DateTime.Today.AddHours(14)))
            {
                return true;
            }

            return false;
        }
    }
}