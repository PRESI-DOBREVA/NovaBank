using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    /// <summary>
    /// Представлява транзакция, свързана със сметка.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Уникален идентификатор на транзакцията.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор на свързаната сметка.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Сметката, свързана с транзакцията.
        /// </summary>
        public virtual Account? Account { get; set; }

        /// <summary>
        /// Сумата на транзакцията.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Типът на транзакцията (например депозит или теглене).
        /// </summary>
        public string TransactionType { get; set; }
    }
}
