using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Estados
{
    public class DeleteModel : PageModel
    {
        private readonly EasyPosDb _context;

        public DeleteModel(EasyPosDb context)
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
