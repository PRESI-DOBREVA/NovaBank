using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;
using BankUI.Data;

namespace BankUI.Pages.Loans
{
    public class IndexModel : PageModel
    {
        private readonly BankUI.Data.BankUIContext _context;

        public IndexModel(BankUI.Data.BankUIContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Loan = await _context.Loan
                .Include(l => l.Customer).ToListAsync();
        }
    }
}
