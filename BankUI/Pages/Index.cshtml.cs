﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankData;
using BankData.Models;

namespace BankUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BankData.BankContext _context;

        public IndexModel(BankData.BankContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Card = await _context.Cards
                .Include(c => c.Account).ToListAsync();
        }
    }
}
