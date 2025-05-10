using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData.Models;

namespace BankUI.Pages.Accounts
{
    /// <summary>  
    /// Класът DetailsModel обработва логиката за показване на детайлите на конкретна сметка.  
    /// </summary>  
    public class DetailsModel : PageModel
    {
        private readonly BankData.BankContext _context;

        /// <summary>  
        /// Инициализира нов екземпляр на класа <see cref="DetailsModel"/>.  
        /// </summary>  
        /// <param name="context">Контекстът на базата данни, използван за достъп до данни за сметките.</param>  
        public DetailsModel(BankData.BankContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Взема или задава детайлите на сметката, които ще бъдат показани на страницата.  
        /// </summary>  
        public Account Account { get; set; } = default!;

        /// <summary>  
        /// Обработва GET заявката за извличане на детайлите на конкретна сметка.  
        /// </summary>  
        /// <param name="id">ID на сметката, която трябва да бъде извлечена.</param>  
        /// <returns>  
        /// <see cref="IActionResult"/>, който рендира страницата, ако сметката е намерена,  
        /// или резултат NotFound, ако сметката не съществува.  
        /// </returns>  
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }
    }
}
