using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly EasyPosDb _context;

        public DetailsModel(EasyPosDb context)
        {
            _context = context;
        }

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
    }
}
