namespace CafeDuCoin.Models
{
    public class Game
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameHistory> GameHistories { get; set; }
        public string CurrentState
        {
            get
            {
                var latestHistory = GameHistories?.OrderByDescending(h => h.Id).FirstOrDefault();
                return latestHistory?.State.ToString() ?? GameState.Free.ToString();
            }           
        }
    }
}
