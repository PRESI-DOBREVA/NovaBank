using System.ComponentModel.DataAnnotations;

namespace BankData.Models
{
    /// <summary>
    /// Представлява банкова карта, свързана със сметка.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Уникален идентификатор на картата.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Номерът на картата.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Идентификатор на свързаната сметка.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Сметката, свързана с картата.
        /// </summary>
        public virtual Account? Account { get; set; }

        /// <summary>
        /// Типът на картата (например дебитна или кредитна).
        /// </summary>
        public string Type { get; set; }
    }
}
