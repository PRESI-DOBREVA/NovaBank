using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    /// <summary>
    /// Модел за страницата за изтриване на акаунт.
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа DeleteModel.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public DeleteModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Свойство за свързване на данни с акаунта, който ще бъде изтрит.
        /// </summary>
        [BindProperty]
        public Account Account { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за изтриване на акаунт.
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
            else
            {
                Account = account;
            }
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за изтриване на акаунт.
        /// </summary>
        /// <param name="id">Идентификатор на акаунта.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                Account = account;
                _context.Accounts.Remove(Account);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
