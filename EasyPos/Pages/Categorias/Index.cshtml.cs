using EasyPos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly EasyPosDb _context;

        public IndexModel(EasyPosDb context)
        {
            _context = context;
        }

        public IList<CategoriaProducto> CategoriaProducto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CategoriaProducto != null)
            {
                CategoriaProducto = await _context.CategoriaProducto.ToListAsync();
            }
        }
    }
}
