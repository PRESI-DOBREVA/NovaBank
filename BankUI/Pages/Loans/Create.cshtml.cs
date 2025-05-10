using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData.Models;

namespace BankUI.Pages.Loans
{
    /// <summary>
    /// Модел за създаване на заем в страницата Razor.
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
        /// </summary>
        /// <returns>Страницата за създаване на заем.</returns>
        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return Page();
        }

        /// <summary>
        /// Свойство за обвързване на данни за заем.
        /// </summary>
        [BindProperty]
        public Loan Loan { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на POST заявка.
        /// </summary>
        /// <returns>Пренасочване към страницата с всички заеми или текущата страница при грешка.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Loans.Add(Loan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
