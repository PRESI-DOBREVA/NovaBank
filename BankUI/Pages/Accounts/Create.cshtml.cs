using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData;
using BankData.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BankUI.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly BankData.BankContext _context;

        public CreateModel(BankData.BankContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> OnGet()
        {
            Customers = new SelectList(_context.Customers.ToList(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } 

        public SelectList Customers { get; set; } = default!;
        
        // For more information, see https://aka.ms/RazorPagesCRUD.
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Customers = new SelectList(_context.Customers, "Id", "Name");
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();
 
            return RedirectToPage("./Index");
        }
    }
}
