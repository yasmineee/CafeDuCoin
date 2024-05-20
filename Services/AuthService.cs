using CafeDuCoin.Models;

namespace CafeDuCoin.Services
{
    public interface IAuthService
    {
        User Authenticate(string login, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string login, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return null;
            }            
            return user;
        }
    }
}