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
    public class IndexModel : PageModel
    {
        private readonly APP_CINEPOLIS.Data.Context _context;

        public IndexModel(APP_CINEPOLIS.Data.Context context)
        {
            _context = context;
        }

        public IList<Sala> Sala { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sala != null)
            {
                Sala = await _context.Sala
                .Include(s => s.Cliente)
                .Include(s => s.Pelicula).ToListAsync();
            }
        }
    }
}
