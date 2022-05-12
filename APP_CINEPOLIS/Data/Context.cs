using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APP_CINEPOLIS.Model;

namespace APP_CINEPOLIS.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<APP_CINEPOLIS.Model.Pelicula>? Pelicula { get; set; }

        public DbSet<APP_CINEPOLIS.Model.Cliente>? Cliente { get; set; }

        public DbSet<APP_CINEPOLIS.Model.Sala>? Sala { get; set; }
    }
}
