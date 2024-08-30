using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppLibros.Models
{
    public class UbicacionBiblioteca
    {
        [Key]
        public int IdUbicacion { get; set; }
        public string? Estante { get; set; }
        [Display(Name = "Sección")]
        public string? Seccion { get; set; }

        //relación de uno a uno
        public int IdLibro { get; set; }
        [ForeignKey(nameof(IdLibro))]
        public Libro? Libro { get; set; }
    }
}
