using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    public class DeleteModel : PageModel
    {
        private readonly BankData.BankContext _context;

        public DeleteModel(BankData.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Card Card { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);

            if (card == null)
            {
                return NotFound();
            }
            else
            {
                Card = card;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                Card = card;
                _context.Cards.Remove(Card);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
