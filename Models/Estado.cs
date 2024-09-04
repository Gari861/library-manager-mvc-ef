using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "La condición es obligatoria")]
        [Display(Name = "Estado del Libro")]
        public string? Condición { get; set; }

        //RELACIÓN
        public List<Libro>? Libros { get; set; }
    }
}
