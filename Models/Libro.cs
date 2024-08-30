using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El Título es obligatorio")]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Cantidad de copias")]
        [Required(ErrorMessage = "La cantidad de copias es obligatoria")]
        public int CantidadCopias { get; set; }

        //Relacion de uno a uno
        [Display(Name = "Ubicación")]
        public UbicacionBiblioteca? UbicacionBiblioteca { get; set; }

        //Relación de uno a muchos
        [Display(Name = "Género")]
        public int IdGenero { get; set; } //LA CLAV FORÁNEA ESTÁ EN LIBRO
        [ForeignKey(nameof(IdGenero))]
        public Genero? Genero { get; set; }

        //Relación de muchos a muchos
        public List<LibroCategoria>? LibrosCategorias { get; set; }

    }
}
