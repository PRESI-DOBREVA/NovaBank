using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Transactions
{
    /// <summary>
    /// Модел за страницата Index, която показва списък с транзакции.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>
        /// Конструктор на класа IndexModel.
        /// </summary>
        /// <param name="context">Контекст на базата данни.</param>
        public IndexModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Списък с транзакции, които ще бъдат показани на страницата.
        /// </summary>
        public IList<Transaction> Transaction { get; set; } = default!;

        /// <summary>
        /// Метод, който се извиква при GET заявка за зареждане на данните.
        /// </summary>
        /// <returns>Асинхронна задача.</returns>
        public async Task OnGetAsync()
        {
            Transaction = await _context.Transactions
                .Include(t => t.Account).ToListAsync();
        }
    }
}
