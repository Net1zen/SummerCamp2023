using Entidades;
using DataSource;
using ContextoDB;

namespace Repositorios
{
    public class RepositorioMonedas : IRepositorioMonedas
    {
        private readonly string ApiKey = "fca_live_cV1mDh79gHYunHYxMEIeuL6CIINDyjmpDPXUvCBf";
        private ContextoConversor _context;
        private readonly IDataCollector _dataCollector;

        public RepositorioMonedas(ContextoConversor context, IDataCollector dataCollector)
        {
            
            _context = context;
            this._dataCollector = dataCollector;
            // Actualiza la tabla
            _dataCollector.LeerMonedas();
        }

        public void AgregarMoneda(Moneda moneda)
        {
            _context.Moneda.Add(moneda);
            _context.SaveChanges();
        }

        public Moneda ObtenerMoneda(string codigo)
        {
            var moneda = _context.Moneda.FirstOrDefault(x => x.Code == codigo);
            return moneda;
        }

        public IEnumerable<Moneda> ObtenerMonedas()
        {
            return _context.Moneda;
        }
    }
}
