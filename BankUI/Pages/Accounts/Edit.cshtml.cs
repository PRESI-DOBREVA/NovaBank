using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    /// <summary>
    /// Модел за редактиране на акаунт.
    /// </summary>
    public class EditModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа EditModel.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public EditModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Свойство за свързване на данни към акаунт.
        /// </summary>
        [BindProperty]
        public Account Account { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за редактиране на акаунт.
        /// </summary>
        /// <param name="id">Идентификатор на акаунта.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за редактиране на акаунт.
        /// </summary>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Проверява дали акаунт с даден идентификатор съществува.
        /// </summary>
        /// <param name="id">Идентификатор на акаунта.</param>
        /// <returns>True, ако акаунтът съществува; в противен случай False.</returns>
        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
