using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    /// <summary>
    /// Модел за редактиране на карта в Razor Pages.
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
        /// Свойство за обвързване на данни за картата.
        /// </summary>
        [BindProperty]
        public Card Card { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за зареждане на данни за редактиране.
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
            Card = card;
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за запис на редактираните данни.
        /// </summary>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(Card.Id))
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
        /// Проверява дали карта с даден идентификатор съществува.
        /// </summary>
        /// <param name="id">Идентификатор на картата.</param>
        /// <returns>Истина, ако картата съществува; иначе - лъжа.</returns>
        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
