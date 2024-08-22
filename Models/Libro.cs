using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2
{
    public class Libro
    {
        //propiedades codefirst, recordar Id primero
        public int Id { get; set; }
        public string Titulo  { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int CantidadCopias { get; set; }
    }
}
