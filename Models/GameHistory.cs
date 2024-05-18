using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace CafeDuCoin.Models
{
    public enum GameState
    {
        Borrowed,
        Returned,
        Free
    }
    public class GameHistory
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        private DateTime _borrowDate;
        public DateTime BorrowDate
        {
            get => _borrowDate.Date;
            set => _borrowDate = value.Date;
        }
        private DateTime? _returnDate;
        public DateTime? ReturnDate
        {
            get => _returnDate?.Date;
            set => _returnDate = value?.Date;
        }
        public string FormattedBorrowDate => BorrowDate.ToString("yyyy-MM-dd");
        public string FormattedReturnDate => ReturnDate?.ToString("yyyy-MM-dd");
        public string State { get; set; } = "Free";
    }
}
