using System.Net.Http.Json;
using ParisSportif_BLAZOR.Model;

namespace ParisSportif_BLAZOR.Services
{
    public class ClubService
    {
        private readonly HttpClient _http;

        public ClubService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Club>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Club>>("api/Clubs") ?? new List<Club>();
        }

        public async Task<Club?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Club>($"api/Clubs/{id}");
        }

        public async Task<ApiResult<Club>> AddAsync(Club club)
        {
            var response = await _http.PostAsJsonAsync("api/Clubs", club);
            if (response.IsSuccessStatusCode)
            {
                var createdClub = await response.Content.ReadFromJsonAsync<Club>();
                return new ApiResult<Club>
                {
                    Success = true,
                    Data = createdClub
                };
            }
            var errorMessage = await response.Content.ReadAsStringAsync();
            return new ApiResult<Club>
            {
                Success = false,
                Error = errorMessage
            };
        }

        public async Task<bool> UpdateAsync(Club club)
        {
            var response = await _http.PutAsJsonAsync($"api/Clubs/{club.Id}", club);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Clubs/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
