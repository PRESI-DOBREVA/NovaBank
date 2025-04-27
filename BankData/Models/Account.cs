using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public double Balance { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        
        
    }
}
