using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    public class Card
    {
        [Key]
        public int CardNumber { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string CardType { get; set; }
    }
}
