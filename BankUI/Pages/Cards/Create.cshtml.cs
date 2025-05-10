using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    /// <summary>
    /// Модел за създаване на нова карта.
    /// </summary>
    public class CreateModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа CreateModel.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public CreateModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод за обработка на GET заявка.
        /// Зарежда списък с акаунти за избор.
        /// </summary>
        /// <returns>Страницата за създаване на карта.</returns>
        public IActionResult OnGet()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            return Page();
        }

        /// <summary>
        /// Свойство за обвързване на данни за картата.
        /// </summary>
        [BindProperty]
        public Card Card { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на POST заявка.
        /// Създава нова карта и я записва в базата данни.
        /// </summary>
        /// <returns>Пренасочване към страницата с индекс или текущата страница при грешка.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cards.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
