using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El Título es obligatorio")]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Cantidad copias")]
        [Required(ErrorMessage = "La cantidad de copias es obligatoria")]
        public int CantidadCopias { get; set; }

        [Display(Name = "Cantidad páginas")]
        [Required(ErrorMessage = "La cantidad de páginas es obligatoria")]
        public int CantidadPags { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; }

        //Relacion UNO a UNO
        [Display(Name = "Ubicación")]
        public UbicacionBiblioteca? UbicacionBiblioteca { get; set; }
        //LA CLAVE FORÁNEA ESTA EN LA CLASE UBICACIÓN

        //Relación UNO A MUCHOS
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        [ForeignKey(nameof(IdEstado))]
        public Estado? Estado { get; set; }

        [Required(ErrorMessage = "El Idioma es obligatorio")]
        public int IdIdioma { get; set; }
        [ForeignKey(nameof(IdIdioma))]
        public Idioma? Idioma { get; set; }

        [Display(Name = "Calificación")]
        public int IdCalificacion { get; set; }
        [ForeignKey(nameof(IdCalificacion))]
        public Calificacion? Calificacion { get; set; }

        //Relación MUCHOS A MUCHOS
        [Display(Name = "Categorías")]
        public List<LibroCategoria>? LibrosCategorias { get; set; }
        [Display(Name = "Autores")]
        public List<LibroAutor>? LibrosAutores { get; set; }
    }
}
