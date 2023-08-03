using System.Net.Http;

namespace Entidades
{
    public static class ClienteAPI
    {


        public static async Task GetApiResponse(string apiUrl)
        {

            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.freecurrencyapi.com");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl); //une _HttpClient.BaseAddress + resto
                response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta es un error (por ejemplo, código 404).

                string responseBody = await response.Content.ReadAsStringAsync();

                if (responseBody != null)
                {
                    // Procesa la información de la respuesta de la API aquí.
                    Console.WriteLine(responseBody);
                }

            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores en caso de que haya un problema con la solicitud.
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
            }
        }
    }
}

