using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CafeDuCoin.Models;
using CafeDuCoin.Services;

namespace CafeDuCoin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameHistoryController : ControllerBase
    {
        private readonly IGameHistoryService _gameHistoryService;

        public GameHistoryController(IGameHistoryService gameHistoryService)
        {
            _gameHistoryService = gameHistoryService;
        }

        [HttpGet("history/{gameId}")]
        public ActionResult<IEnumerable<GameHistory>> GetGameHistory(int gameId)
        {
            var gameHistory = _gameHistoryService.GetGameHistory(gameId);
            if (gameHistory == null)
            {
                return NotFound();
            }
            return Ok(gameHistory);
        }

        [HttpPost]
        public ActionResult<GameHistory> AddGameHistory(GameHistory gameHistory)
        {
            _gameHistoryService.AddGameHistory(gameHistory);
            return CreatedAtAction(nameof(GetGameHistory), new { gameId = gameHistory.GameId }, gameHistory);
        }

        [HttpPost("borrow")]
        public ActionResult BorrowGame([FromBody] GameHistory gameHistory)
        {
            _gameHistoryService.BorrowGame(gameHistory);
            return Ok();
        }

        [HttpPost("return")]
        public ActionResult ReturnGame([FromBody] GameHistory gameHistory)
        {
            _gameHistoryService.ReturnGame(gameHistory);
            return Ok();
        }



    }
}
