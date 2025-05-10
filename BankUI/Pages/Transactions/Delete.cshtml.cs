using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Transactions
{
    /// <summary>
    /// Модел за страницата за изтриване на транзакции.
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа DeleteModel.
        /// </summary>
        /// <param name="context">Контекстът на базата данни.</param>
        public DeleteModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Свойство за обвързване на транзакция.
        /// </summary>
        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за изтриване на транзакция.
        /// </summary>
        /// <param name="id">Идентификатор на транзакцията.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }
            else
            {
                Transaction = transaction;
            }
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за изтриване на транзакция.
        /// </summary>
        /// <param name="id">Идентификатор на транзакцията.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                Transaction = transaction;
                _context.Transactions.Remove(Transaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
