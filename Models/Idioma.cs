using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Idioma
    {
        [Key]
        public int IdIdioma { get; set; }
        [Required(ErrorMessage = "El Idioma es obligatorio")]
        [Display(Name = "Idioma del Libro")]
        public string? Tipo { get; set; }

        //RELACIÓN
        public List<Libro>? Libros { get; set; }
    }
}
