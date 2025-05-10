using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    /// <summary>
    /// Представлява заем, свързан с клиент.
    /// </summary>
    public class Loan
    {
        /// <summary>
        /// Уникален идентификатор на заема.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор на клиента, свързан със заема.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Клиентът, свързан със заема.
        /// </summary>
        public virtual Customer? Customer { get; set; }

        /// <summary>
        /// Сумата на заема.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Лихвеният процент на заема.
        /// </summary>
        public decimal Interest { get; set; }

        /// <summary>
        /// Срокът на заема в месеци.
        /// </summary>
        public int Term { get; set; }
    }
}
