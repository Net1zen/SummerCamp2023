namespace ConversorWeb.Utils
{
    public interface IDataCollector
    {
        //Task CallApiFactores();
        //Task<string> CallApiMonedas();

        //List<FactorBaseDolarJson> LeerFactoresConversionJson();

        List<MonedaJson> LeerMonedas();
    }
}