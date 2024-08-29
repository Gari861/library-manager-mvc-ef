using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Título es obligatorio")]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Display(Name = "Cantidad de copias")]
        [Required(ErrorMessage = "La cantidad de copias es obligatoria")]
        public int CantidadCopias { get; set; }

        //relación de uno a muchos
        [Display(Name = "Género")]
        public int IdGenero { get; set; }
        public Genero? genero { get; set; }

        //relacion de uno a muchos
        [Display(Name = "Ubicación")]
        public int IdUbicacion { get; set; }
        public UbicacionBiblioteca? ubicacionBiblioteca { get; set; }
    }
}
