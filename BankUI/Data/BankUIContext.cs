using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Data
{
    public class BankUIContext : DbContext
    {
        public BankUIContext (DbContextOptions<BankUIContext> options)
            : base(options)
        {
        }

        public DbSet<BankData.Models.Loan> Loan { get; set; } = default!;
    }
}
