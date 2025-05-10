using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankData.Models;
using Microsoft.EntityFrameworkCore;

namespace BankUI.Pages.Transactions
{
    /// <summary>
    /// Модел за създаване на транзакция в страницата.
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
        /// <returns>Страницата за създаване на транзакция.</returns>
        public IActionResult OnGet()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["TransactionType"] = new SelectList(new List<string>() { "Депозит", "Теглене" });
            return Page();
        }

        /// <summary>
        /// Свойство за свързване на данни за транзакцията.
        /// </summary>
        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        /// <summary>
        /// Текущ баланс на акаунта.
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Метод за обработка на POST заявка.
        /// </summary>
        /// <returns>Пренасочване към страницата с транзакции или текущата страница при грешка.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
                ViewData["TransactionType"] = new SelectList(new List<string>() { "Депозит", "Теглене" });
                return Page();
            }

            var Account = await _context.Accounts
                .Where(u => u.Id == Transaction.AccountId)
                .FirstOrDefaultAsync();

            if (Transaction.TransactionType == "Теглене" && Account.Balance < Transaction.Amount)
            {
                ModelState.AddModelError("", "Недостатъчни средства.");
                return Page();
            }

            Account.Balance += (Transaction.TransactionType == "Депозит") ? Transaction.Amount : -Transaction.Amount;

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
