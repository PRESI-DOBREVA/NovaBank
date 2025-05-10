using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankData
{
    /// <summary>
    /// Представлява контекста на базата данни за системата Nova Bank.
    /// Използва Entity Framework Core за управление на данните.
    /// </summary>
    public class BankContext : DbContext
    {
        /// <summary>
        /// Стринг за връзка с базата данни.
        /// </summary>
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=NovaBank;Integrated Security=True";

        /// <summary>
        /// Таблица за банкови сметки.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Таблица за клиенти.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Таблица за транзакции.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Таблица за банкови карти.
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Таблица за заеми.
        /// </summary>
        public DbSet<Loan> Loans { get; set; }

        /// <summary>
        /// Конструктор, който създава базата данни, ако тя не съществува.
        /// </summary>
        public BankContext() : base()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигуриране на контекста с използване на SQL Server и Lazy Loading.
        /// </summary>
        /// <param name="optionsBuilder">Обект за конфигуриране на опциите.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
