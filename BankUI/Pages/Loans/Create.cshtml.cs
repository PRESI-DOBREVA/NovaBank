using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData;
using BankData.Models;

namespace BankUI.Pages.Loans
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
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Loans.Add(Loan);
            await _context.SaveChangesAsync();
            _context.Customers.FirstOrDefault(x => x.Id == Loan.CustomerId).Loans.Add(Loan);
            await _context.SaveChangesAsync();
            _context.Loans.FirstOrDefault(x => x.Id == Loan.Id).Customer = _context.Customers.FirstOrDefault(x => x.Id == Loan.CustomerId);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
