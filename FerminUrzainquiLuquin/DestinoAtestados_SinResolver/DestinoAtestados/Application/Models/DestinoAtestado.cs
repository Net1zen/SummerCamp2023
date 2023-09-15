namespace DestinoAtestados.Application.Models
{
    public class DestinoAtestado
    {
        public DestinoAtestado(string codigoOrganoJudicialDestino, DateTime fechaRecepcion)
        {
            CodigoOrganoJudicialDestino = codigoOrganoJudicialDestino;
            FechaRecepcion = fechaRecepcion;
        }

        public string CodigoOrganoJudicialDestino { get; set; }

        public DateTime FechaRecepcion { get; set; }
    }
}
