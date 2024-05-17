namespace CafeDuCoin.Models
{
    public class Game
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameHistory> GameHistories { get; set; }
        public GameState CurrentState
        {
            get
            {
                var latestHistory = GameHistories?.OrderByDescending(h => h.BorrowDate).FirstOrDefault();
                return latestHistory?.State ?? GameState.Free;
            }
        }
    }
}
