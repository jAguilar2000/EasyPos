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
    public class DeleteModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public DeleteModel(EasyPos.Models.EasyPosDb context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estados == null)
            {
                return NotFound();
            }
            var estado = await _context.Estados.FindAsync(id);

            if (estado != null)
            {
                Estado = estado;
                _context.Estados.Remove(Estado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
