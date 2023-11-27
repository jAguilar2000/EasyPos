using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly EasyPosDb _context;

        public DeleteModel(EasyPosDb context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoriaProducto CategoriaProducto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategoriaProducto == null)
            {
                return NotFound();
            }

            var categoriaproducto = await _context.CategoriaProducto.FirstOrDefaultAsync(m => m.CategoriaId == id);

            if (categoriaproducto == null)
            {
                return NotFound();
            }
            else
            {
                CategoriaProducto = categoriaproducto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CategoriaProducto == null)
            {
                return NotFound();
            }
            var categoriaproducto = await _context.CategoriaProducto.FindAsync(id);

            if (categoriaproducto != null)
            {
                CategoriaProducto = categoriaproducto;
                _context.CategoriaProducto.Remove(CategoriaProducto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
