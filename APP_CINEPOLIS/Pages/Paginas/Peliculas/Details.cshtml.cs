using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APP_CINEPOLIS.Data;
using APP_CINEPOLIS.Model;

namespace APP_CINEPOLIS.Pages.Paginas.Peliculas
{
    public class DetailsModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public DetailsModel(APP_CINEPOLIS.Data.Context context)
        {
            _context = context;
        }

      public Pelicula Pelicula { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pelicula == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.ID == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            else 
            {
                Pelicula = pelicula;
            }
            return Page();
        }
    }
}
