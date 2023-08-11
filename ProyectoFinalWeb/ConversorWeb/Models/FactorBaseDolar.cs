namespace ConversorWeb.Models
{
    public class FactorBaseDolar
    {
        private static int nextId = 0;

        public int Id { get; set; } //Puesta manualmente?

        public const string MonedaOrigen = "USD";
        public string MonedaDestino { get; set; }

        public double Factor { get; set; }

        public FactorBaseDolar(string monedaDestino, double factor)
        {
            Id = nextId++;
            MonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}
