using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Loans
{
    /// <summary>
    /// Модел за страницата с детайли за заем.
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
        /// Информация за заема, която ще бъде показана на страницата.
        /// </summary>
        public Loan Loan { get; set; } = default!;

        /// <summary>
        /// Обработва заявката за получаване на детайли за конкретен заем.
        /// </summary>
        /// <param name="id">Идентификатор на заема.</param>
        /// <returns>Резултат от заявката - страница или грешка NotFound.</returns>
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
    }
}
