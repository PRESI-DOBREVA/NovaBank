using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    /// <summary>
    /// Модел за страницата Index, която показва списък с акаунти.
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
        /// Списък с акаунти, които ще бъдат показани на страницата.
        /// </summary>
        public IList<Account> Accounts { get; set; } = default!;

        /// <summary>
        /// Метод, който се извиква при GET заявка към страницата.
        /// Зарежда списъка с акаунти от базата данни, включително свързаните клиенти.
        /// </summary>
        public async Task OnGetAsync()
        {
            Accounts = await _context.Accounts
                .Include(a => a.Customer).ToListAsync();
        }
    }
}
