using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Services
{
    // 1-Crear clase para la respuesta
    // 2-Crear httpclient
    // 3-Establecer ruta base -> http://www.boredapi.com
    // 4-GetAsync("/api/activity/")
    // 5-Deserializar



    public class CRUDService : IIntegrationService
    {
        private static HttpClient _httpClient = new HttpClient();

        public CRUDService()
        {
            //_httpClient.BaseAddress = new Uri("http://localhost:57863");
            _httpClient.BaseAddress = new Uri("http://www.boredapi.com");
        }



        public async Task Run()
        {
            await getBoredApi();
            //await EjemploGet();
        }

        private async Task getBoredApi()
        {
            var response = await _httpClient.GetAsync("api/activity/?key=5881028");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var boredActivity = new List<BoredActivity>();
            boredActivity = JsonConvert.DeserializeObject<List<BoredActivity>>(content);

    
        }

       /* private async Task EjemploGet()
        {
            var response = await _httpClient.GetAsync("api/movies");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var movies = new List<Movie>();

            movies = JsonConvert.DeserializeObject<List<Movie>>(content);

        }*/
    }
}
