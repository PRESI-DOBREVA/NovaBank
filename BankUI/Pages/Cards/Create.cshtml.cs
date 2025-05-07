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

namespace BankUI.Pages.Cards
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
            return Page();
        }

        [BindProperty]
        public Card Card { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cards.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
