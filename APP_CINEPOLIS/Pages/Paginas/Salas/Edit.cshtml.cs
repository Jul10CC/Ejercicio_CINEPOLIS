using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APP_CINEPOLIS.Data;
using APP_CINEPOLIS.Model;

namespace APP_CINEPOLIS.Pages.Paginas.Salas
{
    public class EditModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public EditModel(APP_CINEPOLIS.Data.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Sala Sala { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sala == null)
            {
                return NotFound();
            }

            var sala =  await _context.Sala.FirstOrDefaultAsync(m => m.ID == id);
            if (sala == null)
            {
                return NotFound();
            }
            Sala = sala;
           ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID");
           ViewData["PeliculaID"] = new SelectList(_context.Pelicula, "ID", "ID");
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

            _context.Attach(Sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(Sala.ID))
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

        private bool SalaExists(int id)
        {
          return (_context.Sala?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
