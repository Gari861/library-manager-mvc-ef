using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Models
{
    public class AppDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Labo4; Trusted_Connection=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno con UbicacionBiblioteca
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.UbicacionBiblioteca)
                .WithOne(u => u.Libro)
                .HasForeignKey<UbicacionBiblioteca>(u => u.IdLibro);

            // Relación uno a muchos con Genero
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Genero)
                .WithMany(g => g.Libros)
                .HasForeignKey(l => l.IdGenero);

            // Relación muchos a muchos con Categoria
            modelBuilder.Entity<LibroCategoria>()
                .HasKey(lc => new { lc.IdLibro, lc.IdCategoria });

            modelBuilder.Entity<LibroCategoria>()
                .HasOne(lc => lc.Libro)
                .WithMany(l => l.LibrosCategorias)
                .HasForeignKey(lc => lc.IdLibro);

            modelBuilder.Entity<LibroCategoria>()
                .HasOne(lc => lc.Categoria)
                .WithMany(c => c.LibrosCategorias)
                .HasForeignKey(lc => lc.IdCategoria);
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<UbicacionBiblioteca> UbicacionesBiblioteca { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LibroCategoria> LibroCategorias { get; set; }
    }

}
