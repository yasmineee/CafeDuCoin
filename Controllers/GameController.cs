using Microsoft.AspNetCore.Mvc;
using CafeDuCoin.Models;
using CafeDuCoin.Services;

namespace CafeDuCoin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGamesWithCurrentState()
        {
            var games = _gameService.GetAllGamesWithCurrentState();
            return Ok(games);
        }


        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }
      

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _gameService.UpdateGame(game);
            return NoContent();
        }

    }
}