using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Customers
{
    /// <summary>
    /// Модел за страницата Index, която показва списък с клиенти.
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
        /// Списък с клиенти, който ще бъде показан на страницата.
        /// </summary>
        public IList<Customer> Customer { get; set; } = default!;

        /// <summary>
        /// Метод, който се извиква при GET заявка за зареждане на данните.
        /// </summary>
        /// <returns>Задача, която представлява асинхронната операция.</returns>
        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
