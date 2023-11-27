using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPos.Pages.Proveedores
{
    public class CreateModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public CreateModel(EasyPos.Models.EasyPosDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Proveedor == null || Proveedor == null)
            {
                return Page();
            }

            _context.Proveedor.Add(Proveedor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
