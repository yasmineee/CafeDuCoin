
using System.Collections.Generic;
using System.Linq;
using CafeDuCoin;
using CafeDuCoin.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeDuCoin.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetGames();
        Game GetGameById(int id);        
        void UpdateGame(Game game);
        IEnumerable<Game> GetAllGamesWithCurrentState();

    }

    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public IEnumerable<Game> GetAllGamesWithCurrentState()
        {
            return _context.Games.Include(g => g.GameHistories).ToList();
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }


        public void UpdateGame(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }

    }
}