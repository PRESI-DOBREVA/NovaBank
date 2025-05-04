using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData.Models;
using BankUI.Data;

namespace BankUI.Pages.Loans
{
    public class CreateModel : PageModel
    {
        private readonly BankUI.Data.BankUIContext _context;

        public CreateModel(BankUI.Data.BankUIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Address");
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

            _context.Loan.Add(Loan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
