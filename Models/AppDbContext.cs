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
            // Relación UNO A UNO 
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.UbicacionBiblioteca)
                .WithOne(u => u.Libro)
                .HasForeignKey<UbicacionBiblioteca>(u => u.IdLibro);

            // Relación UNO A MUCHOS
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Idioma)
                .WithMany(g => g.Libros)
                .HasForeignKey(l => l.IdIdioma);       
            
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Estado)
                .WithMany(g => g.Libros)
                .HasForeignKey(l => l.IdEstado);


            // Relación MUCHOS A MUCHOS
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
            
            modelBuilder.Entity<LibroAutor>()
                .HasKey(lc => new { lc.IdLibro, lc.IdAutor });

            modelBuilder.Entity<LibroAutor>()
                .HasOne(lc => lc.Libro)
                .WithMany(l => l.LibrosAutores)
                .HasForeignKey(lc => lc.IdLibro);

            modelBuilder.Entity<LibroAutor>()
                .HasOne(lc => lc.Autor)
                .WithMany(c => c.LibroAutores)
                .HasForeignKey(lc => lc.IdAutor);
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<UbicacionBiblioteca> UbicacionesBiblioteca { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LibroCategoria> LibrosCategorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LibroAutor> LibrosAutores { get; set; }
    }

}
