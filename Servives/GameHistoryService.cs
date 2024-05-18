using CafeDuCoin.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeDuCoin.Services
{
    public interface IGameHistoryService
    {
        IEnumerable<GameHistory> GetGameHistory(int gameId);
        void AddGameHistory(GameHistory gameHistory);
        void BorrowGame(int gameId);
        void ReturnGame(int gameId);
    }
    public class GameHistoryService : IGameHistoryService
    {
        private readonly ApplicationDbContext _context;

        public GameHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GameHistory> GetGameHistory(int gameId)
        {
            return _context.GameHistories.Where(gh => gh.GameId == gameId).ToList();
        }

        public void AddGameHistory(GameHistory gameHistory)
        {
            _context.GameHistories.Add(gameHistory);
            _context.SaveChanges();
        }

        
        public void BorrowGame(int gameId)
        {
            var gameHistory = new GameHistory
            {
                GameId = gameId,
                BorrowDate = DateTime.UtcNow,
                State = "Borrowed"
            };

            _context.GameHistories.Add(gameHistory);
            _context.SaveChanges();

        }


        public void ReturnGame(int gameId)
        {
            var gameHistory = new GameHistory
            {
                GameId = gameId,
                ReturnDate = DateTime.UtcNow,
                State = "Returned"
            };

            _context.GameHistories.Add(gameHistory);
            _context.SaveChanges();

        }

    }
}