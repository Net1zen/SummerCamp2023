namespace ConversorWeb.Servicios
{
    public class MailDesarrollo : IMail
    {
        public string Mail { get; set; }

        public string EnviarMail()
        {
            return Mail;
        }
    }
}
