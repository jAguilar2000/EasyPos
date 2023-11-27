using EasyPos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Pages.Estados
{
    public class IndexModel : PageModel
    {
        private readonly EasyPosDb _context;

        public IndexModel(EasyPosDb context)
        {
            _context = context;
        }

        public IList<Estado> Estado { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estados != null)
            {
                Estado = await _context.Estados.ToListAsync();
            }
        }
    }
}
