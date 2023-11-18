using BlazorNet8.Shared.Entity;
using BlazorNet8.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudBlazorNet8.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGames(Game game)
        {
            var addedGame = await _gameService.AddGame(game);
            return Ok(addedGame);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(Guid id)
        {
            var game = await _gameService.GetGameById(id);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGameById(Guid id)
        {
            var result = await _gameService.DeleteGameById(id);
            return Ok(result);
        }
    } 
}
