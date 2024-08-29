using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? Titulo  { get; set; }
        public int CantidadCopias { get; set; }

        //relación de uno a muchos
        public int IdGenero { get; set; }
        public Genero? genero { get; set; }

        //relacion de uno a muchos
        public int IdUbicacion { get; set; }
        public UbicacionBiblioteca? ubicacionBiblioteca { get; set; }
    }
}
