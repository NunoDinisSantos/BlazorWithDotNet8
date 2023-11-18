using BlazorNet8.Shared.Data;
using BlazorNet8.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorNet8.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGames()
        {
            await Task.Delay(1000);

            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);           
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> GetGameById(Guid gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            return game;
        }

        public async Task<bool> DeleteGameById(Guid gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game is not null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
                return true;
            }
                return false!;
        }
    }
}
