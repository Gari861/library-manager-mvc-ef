using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Models
{
    public class AppDBcontext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Labo4-EF-MVC;Trusted_Connection=True;MultipleActiveResultSets=True");
        
        //}
        public AppDBcontext(DbContextOptions<AppDBcontext> options): base(options)
        {

        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<UbicacionBiblioteca> UbicacionesBiblioteca { get; set; }

    }
}
