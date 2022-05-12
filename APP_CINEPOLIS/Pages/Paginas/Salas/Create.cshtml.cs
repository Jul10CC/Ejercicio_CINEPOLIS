using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using APP_CINEPOLIS.Data;
using APP_CINEPOLIS.Model;

namespace APP_CINEPOLIS.Pages.Paginas.Salas
{
    public class CreateModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public CreateModel(APP_CINEPOLIS.Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID");
        ViewData["PeliculaID"] = new SelectList(_context.Pelicula, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Sala Sala { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sala == null || Sala == null)
            {
                return Page();
            }

            _context.Sala.Add(Sala);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
