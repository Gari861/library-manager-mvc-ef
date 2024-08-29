using System;
namespace WebAppLibros.Models
{
    public class Genero
    {
        //La clave llamarla Id
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }

        //relacion de uno a muchos
        public List<Libro>? Libros { get; set; }  // Colección de libros
    }
}
