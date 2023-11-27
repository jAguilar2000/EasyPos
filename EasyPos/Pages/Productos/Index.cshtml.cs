using EasyPos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly EasyPosDb _context;

        public IndexModel(EasyPosDb context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Producto != null)
            {
                Producto = await _context.Producto
                .Include(p => p.CategoriaProducto).ToListAsync();
            }
        }
    }
}
