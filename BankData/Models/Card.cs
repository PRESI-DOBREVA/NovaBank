using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string CardType { get; set; }
    }
}
