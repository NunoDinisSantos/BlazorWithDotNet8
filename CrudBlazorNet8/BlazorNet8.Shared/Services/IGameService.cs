using BlazorNet8.Shared.Entity;

namespace BlazorNet8.Shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> AddGame(Game game);
        Task<Game> GetGameById(Guid gameId);
        Task<bool> DeleteGameById(Guid gameId);
    }
}
