using ConversorWeb.Utils;

namespace ConversorWeb.Models
{
    public class RepositorioMonedas : IRepositorioMonedas
    {

        private ContextoConversor _context;
        public RepositorioMonedas(ContextoConversor context)
        {
            _context = context;
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
