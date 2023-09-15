using DestinoAtestados.Application;
using DestinoAtestados.Application.Interfaces;
using DestinoAtestados.Application.Models;
using DestinoAtestados.Domain;
using FluentAssertions;
using Moq;

namespace DestinoAtestados.Tests
{
    public class CalculoDestinoAtestadoTests
    {
        private const string CodigoPartidoJudicialDestinoParaPruebas = "4804";
        private const string JuzgadoInstrucionDeGuardiaParaPruebas = "4802043001";
        private const string JuzgadoViolenciaParaPruebas = "4802048001";
        private readonly Mock<ICalendarioService> _calendarioGuardiaServicioMock;

        public CalculoDestinoAtestadoTests()
        {
            _calendarioGuardiaServicioMock = new Mock<ICalendarioService>();
            _calendarioGuardiaServicioMock
                .Setup(mock => mock.ObtenerOrganoJudicialGuardia(TipoOrganoJudicial.JuzgadoIntruccion, It.IsAny<DateTime>()))
                    .Returns(JuzgadoInstrucionDeGuardiaParaPruebas);
            _calendarioGuardiaServicioMock
                .Setup(mock => mock.ObtenerOrganoJudicialGuardia(TipoOrganoJudicial.JuzgadoViolenciaSobreLaMujer, It.IsAny<DateTime>()))
                    .Returns(JuzgadoViolenciaParaPruebas);

        }


        [Theory]
        [InlineData("50101")]
        [InlineData("80101")]
        public void CalculoDestinoAtestado_Debe_DevolverCodigoDestinoYFechaRecepcion(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Now, 
                codigoClaseRegistro: codigoClaseRegistro, 
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas, 
                incluyeDetenido: false, 
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.Should().NotBeNull();
            destinoAtestado.CodigoOrganoJudicialDestino.Should().NotBeNullOrEmpty();
            destinoAtestado.FechaRecepcion.Should().BeOnOrAfter(DateTime.Today);
        }

        [Theory]
        [InlineData("50101")]
        [InlineData("50102")]
        public void CalculoDestinoAtestadoSinClaseViolencia_Debe_DevolverJuzgadoInstruccion(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Now,
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoInstrucionDeGuardiaParaPruebas);

        }

        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaSinDetenidoYSinOrdenProteccion_Debe_DevolverJuzgadoViolencia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Now,
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoViolenciaParaPruebas);

        }


        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaSinDetenidoYSinOrdenProteccionEnHorarioInhabil_Debe_DevolverJuzgadoViolencia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Today.AddHours(21),
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoViolenciaParaPruebas);

        }

        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaConDetenidoEnHorarioHabil_Debe_DevolverJuzgadoViolencia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Today.AddHours(10),
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: true,
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoViolenciaParaPruebas);

        }

        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaConOrdenProteccionEnHorarioHabil_Debe_DevolverJuzgadoViolencia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Today.AddHours(10),
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: true);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoViolenciaParaPruebas);

        }

        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaConOrdenProteccionEnHorarioInhabil_Debe_DevolverJuzgadoInstruccionDeGuardia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Today.AddHours(14),
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: true);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoInstrucionDeGuardiaParaPruebas);

        }

        [Theory]
        [InlineData("80101")]
        [InlineData("80102")]
        [InlineData("802")]
        [InlineData("803")]
        [InlineData("804")]
        [InlineData("805")]
        public void CalculoDestinoAtestadoConClaseViolenciaConDetenidoEnHorarioInhabil_Debe_DevolverJuzgadoInstruccionDeGuardia(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Today.AddHours(14),
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: true,
                incluyeOrdenProteccion: false);

            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);

            //Act
            var destinoAtestado = calculoDestinoAtestado.CalcularDestino(datosAtestado);


            //Assert
            destinoAtestado.CodigoOrganoJudicialDestino.Should().Be(JuzgadoInstrucionDeGuardiaParaPruebas);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CalculoDestinoAtestadoSinClaseRegistro_Debe_LanzarExcepcion(string codigoClaseRegistro)
        {
            //Arrange
            var datosAtestado = new DatosAtestado(
                fechaPresentacion: DateTime.Now,
                codigoClaseRegistro: codigoClaseRegistro,
                codigoPartidoJudicialDestino: CodigoPartidoJudicialDestinoParaPruebas,
                incluyeDetenido: false,
                incluyeOrdenProteccion: false);

            //Act
            var calculoDestinoAtestado = new CalculoDestinoAtestado(_calendarioGuardiaServicioMock.Object);
            Action action = () => { calculoDestinoAtestado.CalcularDestino(datosAtestado); };

            //Assert
            action.Should().ThrowExactly<ArgumentException>().Where(e => e.ParamName == "CodigoClaseRegistro");
        }

    }
}