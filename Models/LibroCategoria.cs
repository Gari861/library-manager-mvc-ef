using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppLibros.Models
{
    public class LibroCategoria
    {
        //Relación de muchos a muchos
        public int IdLibro { get; set; }
        [ForeignKey(nameof(IdLibro))]
        public Libro? Libro { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }
    }
}
