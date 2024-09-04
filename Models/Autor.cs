using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string? Apellido { get; set; }

        public List<LibroAutor>? LibroAutores { get; set; }
    }
}
