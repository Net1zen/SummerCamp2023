namespace Modelo
{
    public interface IArchivosJson : IAlmacenamiento
    {

        object Deserializar(string json);

        void Serializar(object json);
    }
}
