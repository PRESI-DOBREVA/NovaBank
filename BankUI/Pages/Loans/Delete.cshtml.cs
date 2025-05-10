using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Loans
{
    /// <summary>
    /// Модел за страницата за изтриване на заем.
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор за инициализиране на контекста на базата данни.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public DeleteModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Свойство за свързване на данни за заема.
        /// </summary>
        [BindProperty]
        public Loan Loan { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за изтриване на заем.
        /// </summary>
        /// <param name="id">Идентификатор на заема.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.Id == id);

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

        /// <summary>
        /// Метод за обработка на POST заявка за изтриване на заем.
        /// </summary>
        /// <param name="id">Идентификатор на заема.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                Loan = loan;
                _context.Loans.Remove(Loan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
