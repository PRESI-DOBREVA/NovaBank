using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public string Type { get; set; }
    }
}
