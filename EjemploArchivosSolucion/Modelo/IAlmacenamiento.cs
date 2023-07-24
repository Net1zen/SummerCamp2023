namespace Modelo
{
    public interface IAlmacenamiento : IArchivo
    {
        public void Leer(string fileName)
        {
            Console.WriteLine($"Reading {fileName} into this document");
        }

        public void Escribir(string fileName)
        {
            Console.WriteLine($"Writing {fileName} to disk...");
        }
    }
}
