using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APP_CINEPOLIS.Data;
using APP_CINEPOLIS.Model;

namespace APP_CINEPOLIS.Pages.Paginas.Salas
{
    public class DeleteModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public DeleteModel(APP_CINEPOLIS.Data.Context context)
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

            var sala = await _context.Sala.FirstOrDefaultAsync(m => m.ID == id);

            if (sala == null)
            {
                return NotFound();
            }
            else 
            {
                Sala = sala;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sala == null)
            {
                return NotFound();
            }
            var sala = await _context.Sala.FindAsync(id);

            if (sala != null)
            {
                Sala = sala;
                _context.Sala.Remove(Sala);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
