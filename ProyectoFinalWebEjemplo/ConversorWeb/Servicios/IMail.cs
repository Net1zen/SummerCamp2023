namespace ConversorWeb.Servicios
{
    public interface IMail
    {
        string Mail { get; set; }

        string EnviarCorreo()
        {
            return Mail;
        }
    }
}
