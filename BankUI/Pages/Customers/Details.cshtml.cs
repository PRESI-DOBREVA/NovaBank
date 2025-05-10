using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Customers
{
    /// <summary>
    /// Модел за страницата с детайли на клиент.
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
        /// Свойство за съхранение на информация за клиента.
        /// </summary>
        public Customer Customer { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за показване на детайли за клиент.
        /// </summary>
        /// <param name="id">Идентификатор на клиента.</param>
        /// <returns>Резултат от заявката - страница или грешка.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
