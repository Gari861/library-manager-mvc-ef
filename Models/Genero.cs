using System;
namespace WebAppLibros.Models
{
    public class Genero
    {
        public int IdGenero { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }

        //relacion de uno a muchos
        public List<Libro> Libros { get; set; }  // Colección de libros
    }
}
