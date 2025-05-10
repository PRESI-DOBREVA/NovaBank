using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор за инициализиране на модела за изтриване.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public DeleteModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Свойство за свързване на данни на клиента.
        /// </summary>
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за изтриване на клиент.
        /// </summary>
        /// <param name="id">Идентификатор на клиента.</param>
        /// <returns>Резултат от заявката.</returns>
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

        /// <summary>
        /// Метод за обработка на POST заявка за изтриване на клиент.
        /// </summary>
        /// <param name="id">Идентификатор на клиента.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                Customer = customer;
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
