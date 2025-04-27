using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public int Term { get; set; } 
    }
}
