namespace ConversorWeb.Servicios
{
    public class MailProduccion : IMail
    {
        public string Mail { get; set; }

        public string EnviarCorreo()
        {
            return Mail;
        }
    }
}
