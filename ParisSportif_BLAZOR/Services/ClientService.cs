using System.Net.Http.Json;
using ProjectFootAPI.Model;

namespace ParisSportif_BLAZOR.Services
{
    public class ClientService
    {
        private readonly HttpClient _http;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Client>>("api/Clients") ?? new List<Client>();
        }

        public async Task<Client?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Client>($"api/Clients/{id}");
        }

        public async Task<bool> AddAsync(Client client)
        {
            var response = await _http.PostAsJsonAsync("api/Clients", client);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Client client)
        {
            var response = await _http.PutAsJsonAsync($"api/Clients/{client.Id}", client);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Clients/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
