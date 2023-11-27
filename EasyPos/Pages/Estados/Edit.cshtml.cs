using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPos.Pages.Estados
{
    public class EditModel : PageModel
    {
        private readonly EasyPos.Models.EasyPosDb _context;

        public EditModel(EasyPos.Models.EasyPosDb context)
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

            var estado =  await _context.Estados.FirstOrDefaultAsync(m => m.EstadoId == id);
            if (estado == null)
            {
                return NotFound();
            }
            Estado = estado;
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

            _context.Attach(Estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(Estado.EstadoId))
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

        private bool EstadoExists(int id)
        {
          return (_context.Estados?.Any(e => e.EstadoId == id)).GetValueOrDefault();
        }
    }
}
