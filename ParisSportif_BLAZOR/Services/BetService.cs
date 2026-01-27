using System.Net.Http.Json;
using ProjectFootAPI.Model;

namespace ParisSportif_BLAZOR.Services
{
    public class BetService
    {
        private readonly HttpClient _http;

        public BetService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Bet>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Bet>>("api/Bets") ?? new List<Bet>();
        }

        public async Task<Bet?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Bet>($"api/Bets/{id}");
        }

        public async Task<bool> AddAsync(Bet bet)
        {
            var response = await _http.PostAsJsonAsync("api/Bets", bet);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Bet bet)
        {
            var response = await _http.PutAsJsonAsync($"api/Bets/{bet.Id}", bet);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Bets/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
