using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppLibros.Models
{
    public class LibroAutor
    {
        public int IdAutor { get; set; }
        [ForeignKey(nameof(IdAutor))]
        public Autor? Autor { get; set; }

        public int IdLIbro { get; set; }
        [ForeignKey(nameof(IdLIbro))]
        public Libro? Libro { get; set; }
        
        public string? Nombre { get; set; }
    }
}
