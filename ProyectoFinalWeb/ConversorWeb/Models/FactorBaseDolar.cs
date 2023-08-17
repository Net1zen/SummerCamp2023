namespace ConversorWeb.Models
{
    public class FactorBaseDolar
    {
        public int Id { get; set; }

        public const string MonedaOrigen = "USD";
        public string MonedaDestino { get; set; }

        public double Factor { get; set; }

        public FactorBaseDolar(string monedaDestino, double factor)
        {
            MonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}
