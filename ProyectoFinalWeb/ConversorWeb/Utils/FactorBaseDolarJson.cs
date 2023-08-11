namespace ConversorWeb.Utils
{
    public class FactorBaseDolarJson
    {
        private static int nextId = 0;

        public int Id { get; set; } //Puesta manualmente?

        public const string MonedaOrigen = "USD";
        public string MonedaDestino { get; set; }

        public double Factor { get; set; }

        public FactorBaseDolarJson(string monedaDestino, double factor)
        {
            Id = nextId++;
            MonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}
