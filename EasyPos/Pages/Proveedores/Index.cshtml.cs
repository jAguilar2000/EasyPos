using EasyPos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Proveedores
{
    public class IndexModel : PageModel
    {
        private readonly EasyPosDb _context;

        public IndexModel(EasyPosDb context)
        {
            _context = context;
        }

        public IList<Proveedor> Proveedor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proveedor != null)
            {
                Proveedor = await _context.Proveedor.ToListAsync();
            }
        }
    }
}
