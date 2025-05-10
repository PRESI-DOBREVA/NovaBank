using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Loans
{
    /// <summary>
    /// Модел за редактиране на заем в Razor Pages.
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
        /// Свойство за обвързване на данни за заем.
        /// </summary>
        [BindProperty]
        public Loan Loan { get; set; } = default!;

        /// <summary>
        /// Метод за обработка на GET заявка за зареждане на данни за заем.
        /// </summary>
        /// <param name="id">Идентификатор на заема.</param>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            Loan = loan;
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Address");
            return Page();
        }

        /// <summary>
        /// Метод за обработка на POST заявка за актуализиране на данни за заем.
        /// </summary>
        /// <returns>Резултат от заявката.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(Loan.Id))
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
        /// Проверява дали заем с даден идентификатор съществува.
        /// </summary>
        /// <param name="id">Идентификатор на заема.</param>
        /// <returns>True, ако заемът съществува; в противен случай False.</returns>
        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
