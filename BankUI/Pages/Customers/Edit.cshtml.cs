using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Customers
{
    /// <summary>
    /// Модел за редактиране на клиент.
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
        /// Свойство за обвързване на данни на клиента.
        /// </summary>
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка.
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
            Customer = customer;
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка.
        /// </summary>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Id))
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
        /// Проверява дали клиентът съществува в базата данни.
        /// </summary>
        /// <param name="id">Идентификатор на клиента.</param>
        /// <returns>Истина, ако клиентът съществува; в противен случай - лъжа.</returns>
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
