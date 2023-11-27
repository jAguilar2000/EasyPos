using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyPos.Pages.Estados
{
    public class CreateModel : PageModel
    {
        private readonly EasyPosDb _context;

        public CreateModel(EasyPosDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Estado Estado { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Estados == null || Estado == null)
            {
                return Page();
            }

            _context.Estados.Add(Estado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
