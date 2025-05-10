using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    /// <summary>
    /// Представлява клиент в системата на Nova Bank.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Уникален идентификатор на клиента.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Името на клиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адресът на клиента.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Колекция от сметки, притежавани от клиента.
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        /// <summary>
        /// Колекция от заеми, свързани с клиента.
        /// </summary>
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}