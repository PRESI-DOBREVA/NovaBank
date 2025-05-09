using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData;
using BankData.Models;
using Microsoft.EntityFrameworkCore;

namespace BankUI.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly BankData.BankContext _context;

        public CreateModel(BankData.BankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["TransactionType"] = new SelectList(new List<string>(){ "Депозит", "Теглене" });
            return Page();
        }
        

        [BindProperty]
        public Transaction Transaction { get; set; } = default!;
        public decimal CurrentBalance { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Account = await _context.Accounts
            .Where(u => u.Id == Transaction.AccountId)
            .FirstOrDefaultAsync();

            if (Transaction.TransactionType == "Теглене" && Account.Balance < Transaction.Amount)
            {
                ModelState.AddModelError("", "Insufficient funds.");
                return Page();
            }

            Account.Balance += (Transaction.TransactionType == "Депозит") ? Transaction.Amount : -Transaction.Amount;

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
