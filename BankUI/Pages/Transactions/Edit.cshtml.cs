using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Transactions
{
    /// <summary>
    /// Модел за редактиране на транзакции в страницата.
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
        /// Свойство за обвързване на данни за транзакцията.
        /// </summary>
        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за зареждане на данни за транзакция.
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
            Transaction = transaction;
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за актуализиране на транзакция.
        /// </summary>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(Transaction.Id))
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
        /// Проверява дали транзакцията съществува в базата данни.
        /// </summary>
        /// <param name="id">Идентификатор на транзакцията.</param>
        /// <returns>True, ако транзакцията съществува; в противен случай False.</returns>
        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
