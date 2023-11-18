using BlazorNet8.Shared.Entity;
using System.Net.Http.Json;

namespace BlazorNet8.Shared.Services
{
    public class ClientGameService : IGameService
    {
        private readonly HttpClient _httpClient;

        public ClientGameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Game> GetGameById(Guid gameId)
        {
            var result = await _httpClient.GetFromJsonAsync<Game>($"/api/game/{gameId}");

            return result;
        }

        public async Task<Game> AddGame(Game game)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/game", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<bool> DeleteGameById(Guid gameId)
        {
            var result = await _httpClient.DeleteAsync($"/api/game/{gameId}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<Game>> GetAllGames()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Game>>($"/api/game/");
            return result;
        }
    }
}
