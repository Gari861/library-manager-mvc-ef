using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [Display(Name = "Fecha Publicación")]
        DateTime? Fechapublicacion { get; set; }

        [Display(Name = "Cantidad copias")]
        [Required(ErrorMessage = "La cantidad de copias es obligatoria")]
        public int CantidadCopias { get; set; }

        [Display(Name = "Cantidad páginas")]
        public int CantidadPags { get; set; }

        [Required(ErrorMessage = "La calificación es obligatoria")]
        [Display(Name = "Calificación Promedio")]
        public double CalificacionPromedio {  get; set; }

        //Relacion UNO a UNO

        [Display(Name = "Ubicación")]
        public UbicacionBiblioteca? UbicacionBiblioteca { get; set; }
        //LA CLAVE FORÁNEA ESTA EN LA CLASE UBICACIÓN

        //Relación UNO A MUCHOS

        [Required(ErrorMessage = "El Estado es obligatorio")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        [ForeignKey(nameof(IdEstado))]
        public string? Estado { get; set; }

        [Display(Name = "Idioma")]
        [Required(ErrorMessage = "El Idioma es obligatorio")]
        public int IdIdioma { get; set; }
        [ForeignKey(nameof(IdIdioma))]
        public string? Idioma { get; set; }

        //Relación MUCHOS A MUCHOS
        public List<LibroCategoria>? LibrosCategorias { get; set; }
        public  List<LibroAutor>? LibrosAutores { get; set; }
    }
}
