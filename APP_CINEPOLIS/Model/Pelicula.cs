using System.ComponentModel.DataAnnotations;

namespace APP_CINEPOLIS.Model
{
    public class Pelicula
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; } 
        public string? Genero { get; set; }
    }
}
