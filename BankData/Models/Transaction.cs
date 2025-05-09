using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int AccountId {get; set;}
        public virtual Account? Account { get; set;}
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        

    }
}
