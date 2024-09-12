using System.ComponentModel.DataAnnotations;
namespace WebAppLibros.Models
{
    public class Calificacion
    {
        [Key]
        public int IdCalificacion { get; set; }
        [Required(ErrorMessage = "La Calificación es obligatoria")]
        [Display(Name = "Calificación")]
        [Range(0,10)]
        public int NumCalificacion { get; set; }

        //RELACIÓN
        public List<Libro>? Libros { get; set; }
    }
}
