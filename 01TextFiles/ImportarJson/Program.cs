namespace ImportarJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string json = @"{
              'Name': 'Bad Boys',
              'ReleaseDate': '1995-4-7T00:00:00',
              'Genres': [
                'Action',
                'Comedy'
              ]
            }";
            */

            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string rootDirectoryPath = new DirectoryInfo(currentDirectory).Parent.Parent.Parent.FullName;
                string fileDirectoryPath = rootDirectoryPath + "\\monedas.json";

                //string rutaFichero = "C:\\Curso\\Repos\\SummerCamp2023\\01TextFiles\\ImportarJson";

                JsonFileProcessor jsonProcessor = new JsonFileProcessor(fileDirectoryPath);
                jsonProcessor.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Movie m = JsonConvert.DeserializeObject<Movie>(json);

            //string name = m.Name;
            // Bad Boys
        }
    }
}