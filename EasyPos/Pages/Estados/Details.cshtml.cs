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
    public class DetailsModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public DetailsModel(EasyPos.Models.EasyPosDb context)
        {
            _context = context;
        }

      public Estado Estado { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estados == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados.FirstOrDefaultAsync(m => m.EstadoId == id);
            if (estado == null)
            {
                return NotFound();
            }
            else 
            {
                Estado = estado;
            }
            return Page();
        }
    }
}
