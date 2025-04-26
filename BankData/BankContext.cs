
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankData.Models;

namespace BankData
{
    public class BankContext : DbContext
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Banks;Integrated Security=True";
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public BankContext(): base()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
