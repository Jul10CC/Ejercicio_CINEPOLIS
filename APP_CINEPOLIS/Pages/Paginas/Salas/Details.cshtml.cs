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
    public class DetailsModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public DetailsModel(APP_CINEPOLIS.Data.Context context)
        {
            _context = context;
        }

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
    }
}
