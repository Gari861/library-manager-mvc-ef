using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Idioma
    {
        [Key]
        public int IdIdioma { get; set; }
        public string? Tipo { get; set; }

        //RELACIÓN
        public List<Libro>? Libros { get; set; }
    }
}
