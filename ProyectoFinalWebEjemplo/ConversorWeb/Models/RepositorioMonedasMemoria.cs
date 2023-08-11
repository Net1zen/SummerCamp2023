namespace ConversorWeb.Models
{
    public class RepositorioMonedasMemoria : IRepositorioMonedas
    {
        public List<Moneda> Lista { get; set; }

        //public RepositorioMonedas()
        //{
        //    Lista = new List<Moneda>() {
        //    new Moneda { Id = 1, CodigoMoneda = "EUR",Descripcion = "Euro"},
        //    new Moneda { Id = 2, CodigoMoneda = "USD",Descripcion = "Dolar"},
        //    new Moneda { Id = 3, CodigoMoneda = "GBP",Descripcion = "Libra Esterlina"},
        //    };
        //}
        public RepositorioMonedasMemoria()
        {
            Lista = new List<Moneda>() {
            new Moneda {Codigo = "EUR", Nombre = "Euro"},
            new Moneda {Codigo = "USD", Nombre = "Dolar"},
            new Moneda {Codigo = "GBP", Nombre = "Libra esterlina"},
            };
        }
        public Moneda ObtenerMoneda(string codigo)
        {
            return Lista.FirstOrDefault(m => m.Codigo == codigo);
        }

        public IEnumerable<Moneda> ObtenerMonedas()
        {
            return Lista;
        }
    }
}
