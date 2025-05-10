using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    /// <summary>
    /// Модел за страницата с детайли за карта.
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
        /// Представлява данните за картата, които ще бъдат показани на страницата.
        /// </summary>
        public Card Card { get; set; } = default!;

        /// <summary>
        /// Обработва GET заявка за показване на детайли за карта.
        /// </summary>
        /// <param name="id">Идентификатор на картата.</param>
        /// <returns>Резултат от заявката - страница или грешка NotFound.</returns>
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
    }
}
