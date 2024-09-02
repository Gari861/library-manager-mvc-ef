using System.ComponentModel.DataAnnotations;

namespace WebAppLibros.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public List<LibroAutor>? LibroAutores { get; set; }
    }
}
