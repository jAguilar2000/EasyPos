using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPos.Pages.Categorias
{
    public class EditModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public EditModel(EasyPos.Models.EasyPosDb context)
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

            var categoriaproducto =  await _context.CategoriaProducto.FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoriaproducto == null)
            {
                return NotFound();
            }
            CategoriaProducto = categoriaproducto;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoriaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaProductoExists(CategoriaProducto.CategoriaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoriaProductoExists(int id)
        {
          return (_context.CategoriaProducto?.Any(e => e.CategoriaId == id)).GetValueOrDefault();
        }
    }
}
