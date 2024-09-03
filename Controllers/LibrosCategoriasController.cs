using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppLibros.Models;

namespace WebAppLibros.Controllers
{
    public class LibrosCategoriasController : Controller
    {
        private readonly AppDBcontext _context;

        //public LibrosCategoriasController(AppDBcontext context)
        //{
        //    _context = context;
        //}

        public LibrosCategoriasController()
        {
            _context = new AppDBcontext();
        }

        // GET: LibrosCategorias
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.LibrosCategorias.Include(l => l.Categoria).Include(l => l.Libro);
            return View(await appDBcontext.ToListAsync());
        }

        // GET: LibrosCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibrosCategorias
                .Include(l => l.Categoria)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroCategoria == null)
            {
                return NotFound();
            }

            return View(libroCategoria);
        }

        // GET: LibrosCategorias/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Tipo");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo");
            return View();
        }

        // POST: LibrosCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,IdCategoria")] LibroCategoria libroCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libroCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Tipo", libroCategoria.IdCategoria);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroCategoria.IdLibro);
            return View(libroCategoria);
        }

        // GET: LibrosCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibrosCategorias.FindAsync(id);
            if (libroCategoria == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Tipo", libroCategoria.IdCategoria);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroCategoria.IdLibro);
            return View(libroCategoria);
        }

        // POST: LibrosCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,IdCategoria")] LibroCategoria libroCategoria)
        {
            if (id != libroCategoria.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroCategoriaExists(libroCategoria.IdLibro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Tipo", libroCategoria.IdCategoria);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroCategoria.IdLibro);
            return View(libroCategoria);
        }

        // GET: LibrosCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibrosCategorias
                .Include(l => l.Categoria)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroCategoria == null)
            {
                return NotFound();
            }

            return View(libroCategoria);
        }

        // POST: LibrosCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroCategoria = await _context.LibrosCategorias.FindAsync(id);
            if (libroCategoria != null)
            {
                _context.LibrosCategorias.Remove(libroCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroCategoriaExists(int id)
        {
            return _context.LibrosCategorias.Any(e => e.IdLibro == id);
        }
    }
}
