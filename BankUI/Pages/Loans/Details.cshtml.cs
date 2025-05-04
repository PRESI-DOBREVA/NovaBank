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
    public class DetailsModel : PageModel
    {
        private readonly BankUI.Data.BankUIContext _context;

        public DetailsModel(BankUI.Data.BankUIContext context)
        {
            _context = context;
        }

        public Loan Loan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan.FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            else
            {
                Loan = loan;
            }
            return Page();
        }
    }
}
