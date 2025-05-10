using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData;
using BankData.Models;

namespace BankUI.Pages.Cards
{
    /// <summary>
    /// Модел за страницата Index, която показва списък с карти.
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
        /// Списък с карти, които ще бъдат показани на страницата.
        /// </summary>
        public IList<Card> Card { get; set; } = default!;

        /// <summary>
        /// Метод, който се извиква при GET заявка за страницата.
        /// Зарежда списъка с карти от базата данни.
        /// </summary>
        /// <returns>Задача, която представлява асинхронната операция.</returns>
        public async Task OnGetAsync()
        {
            Card = await _context.Cards
                .Include(c => c.Account).ToListAsync();
        }
    }
}
