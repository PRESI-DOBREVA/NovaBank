using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Transactions
{
    /// <summary>
    /// Модел за страницата с детайли за транзакции.
    /// </summary>
    public class DetailsModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа DetailsModel.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public DetailsModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Текущата транзакция, която ще бъде показана на страницата.
        /// </summary>
        public Transaction Transaction { get; set; } = default!;

        /// <summary>
        /// Обработва GET заявка за показване на детайли за транзакция.
        /// </summary>
        /// <param name="id">Идентификатор на транзакцията.</param>
        /// <returns>Резултат от заявката - страница или NotFound.</returns>
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
    }
}
