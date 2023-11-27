using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Proveedores
{
    public class DeleteModel : PageModel
    {
        private readonly EasyPosDb _context;

        public DeleteModel(EasyPosDb context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(m => m.ProveedorId == id);

            if (proveedor == null)
            {
                return NotFound();
            }
            else
            {
                Proveedor = proveedor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedor.FindAsync(id);

            if (proveedor != null)
            {
                Proveedor = proveedor;
                _context.Proveedor.Remove(Proveedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
