using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppLibros.Models
{
    public class LibroAutor
    {
        public int IdAutor { get; set; }
        [ForeignKey(nameof(IdAutor))]
        public Autor? Autor { get; set; }

        public int IdLibro { get; set; }
        [ForeignKey(nameof(IdLibro))]
        public Libro? Libro { get; set; }
    }
}
