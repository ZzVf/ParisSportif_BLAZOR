using System.Net.Http.Json;
using ParisSportif_BLAZOR.Model;

namespace ParisSportif_BLAZOR.Services
{
    public class MatchService
    {
        private readonly HttpClient _http;

        public MatchService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Match>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Match>>("api/Matches") ?? new List<Match>();
        }

        public async Task<Match?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Match>($"api/Matches/{id}");
        }

        public async Task<List<Match>> GetByClubIdAsync(int clubId)
        {
            return await _http.GetFromJsonAsync<List<Match>>($"api/Matches/club/{clubId}") ?? new List<Match>();
        }

        public async Task<bool> AddAsync(Match match)
        {
            var response = await _http.PostAsJsonAsync("api/Matches", match);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Match match)
        {
            var response = await _http.PutAsJsonAsync($"api/Matches/{match.Id}", match);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Matches/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
