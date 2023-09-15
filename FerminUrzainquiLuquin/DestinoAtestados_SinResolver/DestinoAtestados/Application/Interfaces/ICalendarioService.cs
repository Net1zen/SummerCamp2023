using DestinoAtestados.Domain;

namespace DestinoAtestados.Application.Interfaces
{
    public interface ICalendarioService
    {
        string ObtenerOrganoJudicialGuardia(TipoOrganoJudicial tipoOrganoJudicial, DateTime fecha);
    }
}