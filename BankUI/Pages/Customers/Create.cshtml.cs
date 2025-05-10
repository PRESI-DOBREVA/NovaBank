using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankData.Models;

namespace BankUI.Pages.Customers
{
    /// <summary>
    /// Модел за създаване на нов клиент.
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
        /// <returns>Връща страницата за създаване на клиент.</returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// Свойство за обвързване на данни на клиента.
        /// </summary>
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на POST заявка за създаване на нов клиент.
        /// </summary>
        /// <returns>Пренасочва към страницата с всички клиенти, ако операцията е успешна.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
