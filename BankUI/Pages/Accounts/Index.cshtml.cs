using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly BankData.BankContext _context;

        public IndexModel(BankData.BankContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts
                .Include(a => a.Customer).ToListAsync();
        }
    }
}
