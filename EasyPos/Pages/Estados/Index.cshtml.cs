using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPos.Pages.Estados
{
    public class IndexModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public IndexModel(EasyPos.Models.EasyPosDb context)
        {
            _context = context;
        }

        public IList<Estado> Estado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estados != null)
            {
                Estado = await _context.Estados.ToListAsync();
            }
        }
    }
}
