using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Loans
{
    /// <summary>
    /// Модел за страницата Index, която показва списък с кредити.
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
        /// Списък с кредити, който ще бъде показан на страницата.
        /// </summary>
        public IList<Loan> Loan { get; set; } = default!;

        /// <summary>
        /// Метод, който се извиква при GET заявка към страницата.
        /// Зарежда списъка с кредити от базата данни, включително информация за клиента.
        /// </summary>
        /// <returns>Задача, която представлява асинхронната операция.</returns>
        public async Task OnGetAsync()
        {
            Loan = await _context.Loans
                .Include(l => l.Customer).ToListAsync();
        }
    }
}
