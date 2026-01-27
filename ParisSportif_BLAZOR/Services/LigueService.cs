using System.Net.Http.Json;
using ProjectFootAPI.Model;

namespace ParisSportif_BLAZOR.Services
{
    public class LigueService
    {
        private readonly HttpClient _http;

        public LigueService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Ligue>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Ligue>>("api/Ligues") ?? new List<Ligue>();
        }

        public async Task<Ligue?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Ligue>($"api/Ligues/{id}");
        }

        public async Task<bool> AddAsync(Ligue ligue)
        {
            var response = await _http.PostAsJsonAsync("api/Ligues", ligue);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Ligue ligue)
        {
            var response = await _http.PutAsJsonAsync($"api/Ligues/{ligue.Id}", ligue);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Ligues/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
