using System;
using System.ComponentModel.DataAnnotations;
namespace WebAppLibros.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }

        //Relacion de uno a muchos
        public List<Libro>? Libros { get; set; }
    }
}
