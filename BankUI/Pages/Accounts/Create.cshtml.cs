using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    /// <summary>
    /// Модел за създаване на нова сметка в страницата.
    /// </summary>
    public class CreateModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор за инициализиране на контекста на базата данни.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public CreateModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод за обработка на GET заявка за зареждане на страницата.
        /// </summary>
        /// <returns>Резултат от страницата.</returns>
        public async Task<IActionResult> OnGet()
        {
            Customers = new SelectList(_context.Customers.ToList(), "Id", "Name");
            return Page();
        }

        /// <summary>
        /// Свойство за обвързване на данни за сметката.
        /// </summary>
        [BindProperty]
        public Account Account { get; set; }

        /// <summary>
        /// Списък с клиенти за избор.
        /// </summary>
        public SelectList Customers { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на POST заявка за създаване на нова сметка.
        /// </summary>
        /// <returns>Пренасочване към страницата с индекс или повторно зареждане на текущата страница при грешка.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Customers = new SelectList(_context.Customers, "Id", "Name");
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
