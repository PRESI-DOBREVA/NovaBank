using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    /// <summary>
    /// Представлява банкова сметка в системата на Nova Bank.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Уникален идентификатор на сметката.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Балансът на сметката.
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Идентификатор на клиента, който притежава сметката.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Клиентът, който притежава сметката.
        /// </summary>
        public virtual Customer? Customer { get; set; }

        /// <summary>
        /// Колекция от карти, свързани със сметката.
        /// </summary>
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

        /// <summary>
        /// Колекция от транзакции, свързани със сметката.
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
