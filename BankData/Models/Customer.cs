using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}