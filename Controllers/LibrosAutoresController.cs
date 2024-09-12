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
    public class LibrosAutoresController : Controller
    {
        private readonly AppDBcontext _context;

        public LibrosAutoresController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: LibrosAutores
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.LibrosAutores.Include(l => l.Autor).Include(l => l.Libro);
            return View(await appDBcontext.ToListAsync());
        }

        // GET: LibrosAutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroAutor = await _context.LibrosAutores
                .Include(l => l.Autor)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroAutor == null)
            {
                return NotFound();
            }

            return View(libroAutor);
        }

        // GET: LibrosAutores/Create
        public IActionResult Create()
        {
            ViewData["IdAutor"] = new SelectList(_context.Autores, "IdAutor", "Apellido");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo");
            return View();
        }

        // POST: LibrosAutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutor,IdLibro")] LibroAutor libroAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libroAutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autores, "IdAutor", "Apellido", libroAutor.IdAutor);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroAutor.IdLibro);
            return View(libroAutor);
        }

        // GET: LibrosAutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroAutor = await _context.LibrosAutores.FindAsync(id);
            if (libroAutor == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autores, "IdAutor", "Apellido", libroAutor.IdAutor);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroAutor.IdLibro);
            return View(libroAutor);
        }

        // POST: LibrosAutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutor,IdLibro")] LibroAutor libroAutor)
        {
            if (id != libroAutor.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroAutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroAutorExists(libroAutor.IdLibro))
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
            ViewData["IdAutor"] = new SelectList(_context.Autores, "IdAutor", "Apellido", libroAutor.IdAutor);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", libroAutor.IdLibro);
            return View(libroAutor);
        }

        // GET: LibrosAutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroAutor = await _context.LibrosAutores
                .Include(l => l.Autor)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libroAutor == null)
            {
                return NotFound();
            }

            return View(libroAutor);
        }

        // POST: LibrosAutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroAutor = await _context.LibrosAutores.FindAsync(id);
            if (libroAutor != null)
            {
                _context.LibrosAutores.Remove(libroAutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroAutorExists(int id)
        {
            return _context.LibrosAutores.Any(e => e.IdLibro == id);
        }
    }
}
