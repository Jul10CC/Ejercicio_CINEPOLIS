using System.ComponentModel.DataAnnotations.Schema;

namespace APP_CINEPOLIS.Model
{
    public class Sala
    {
        public int ID { get; set; }
        public string? Tipo { get; set; }
        public decimal Precio { get; set; }
        public int PeliculaID { get; set; }
        [ForeignKey("PeliculaID")]
        public Pelicula? Pelicula { get; set; }
        public int ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        public Cliente? Cliente { get; set; }
    }
}
