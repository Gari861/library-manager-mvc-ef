using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "La Categoría es obligatoria")]
        [Display(Name = "Categoría del Libro")]
        public string? Tipo { get; set; }

        // Relación de muchos a muchos
        public List<LibroCategoria>? LibrosCategorias { get; set; }
    }

}

