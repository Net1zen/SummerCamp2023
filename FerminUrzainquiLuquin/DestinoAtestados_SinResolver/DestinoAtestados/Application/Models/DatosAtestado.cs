namespace DestinoAtestados.Application.Models
{
    public class DatosAtestado
    {
        public DateTime FechaPresentacion { get; set; }

        public string CodigoClaseRegistro { get; set; }

        public string CodigoPartidoJudicialDestino { get; set; }

        public bool IncluyeDetenido { get; set; }

        public bool IncluyeOrdenProteccion { get; set; }

        public DatosAtestado(DateTime fechaPresentacion, string codigoClaseRegistro, string codigoPartidoJudicialDestino, bool incluyeDetenido, bool incluyeOrdenProteccion)
        {
            FechaPresentacion = fechaPresentacion;
            CodigoClaseRegistro = codigoClaseRegistro;
            CodigoPartidoJudicialDestino = codigoPartidoJudicialDestino;
            IncluyeDetenido = incluyeDetenido;
            IncluyeOrdenProteccion = incluyeOrdenProteccion;
        }

    }
}
