using CafeDuCoin.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeDuCoin.Services
{
    public interface IGameHistoryService
    {
        IEnumerable<GameHistory> GetGameHistory(int gameId);
        void AddGameHistory(GameHistory gameHistory);
        void BorrowGame(GameHistory gameHistory);
        void ReturnGame(GameHistory gameHistory);
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

        public void BorrowGame(GameHistory gameHistory)
        {
            gameHistory.BorrowDate = DateTime.UtcNow.Date;
            _context.GameHistories.Add(gameHistory);
            gameHistory.State = GameState.Borrowed;
            _context.SaveChanges();
        }

        public void ReturnGame(GameHistory gameHistory)
        {
            var history = _context.GameHistories.FirstOrDefault(gh => gh.Id == gameHistory.Id);
            if (history != null)
            {
                history.ReturnDate = DateTime.UtcNow.Date;
                gameHistory.State = GameState.Returned;
                _context.SaveChanges();
            }
        }
    }
}