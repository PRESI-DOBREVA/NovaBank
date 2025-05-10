using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    /// <summary>
    /// Модел за страницата за изтриване на карти.
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
        /// Свойство за свързване на данни за картата.
        /// </summary>
        [BindProperty]
        public Card Card { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка.
        /// </summary>
        /// <param name="id">Идентификатор на картата.</param>
        /// <returns>Резултат от заявката.</returns>
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

        /// <summary>
        /// Метод за обработка на POST заявка за изтриване на карта.
        /// </summary>
        /// <param name="id">Идентификатор на картата.</param>
        /// <returns>Резултат от заявката.</returns>
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
