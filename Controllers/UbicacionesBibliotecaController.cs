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
    public class UbicacionesBibliotecaController : Controller
    {
        private readonly AppDBcontext _context;

        //public UbicacionesBibliotecaController(AppDBcontext context)
        //{
        //    _context = context;
        //}

        public UbicacionesBibliotecaController()
        {
            _context = new AppDBcontext();
        }

        // GET: UbicacionesBiblioteca
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.UbicacionesBiblioteca.Include(u => u.Libro);
            return View(await appDBcontext.ToListAsync());
        }

        // GET: UbicacionesBiblioteca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionBiblioteca = await _context.UbicacionesBiblioteca
                .Include(u => u.Libro)
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicacionBiblioteca == null)
            {
                return NotFound();
            }

            return View(ubicacionBiblioteca);
        }

        // GET: UbicacionesBiblioteca/Create

        public IActionResult Create()
        {
            // Lista de libros que no tienen una ubicación asignada
            var librosSinUbicacion = _context.Libros
                .Where(libro => libro.UbicacionBiblioteca == null)
                .ToList();

            // Crear un SelectList con los libros filtrados
            ViewData["IdLibro"] = new SelectList(librosSinUbicacion, "IdLibro", "Titulo");

            //ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo");
            return View();
        }


        // POST: UbicacionesBiblioteca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUbicacion,Estante,Seccion,IdLibro")] UbicacionBiblioteca ubicacionBiblioteca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacionBiblioteca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", ubicacionBiblioteca.IdLibro);
            return View(ubicacionBiblioteca);
        }

        // GET: UbicacionesBiblioteca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionBiblioteca = await _context.UbicacionesBiblioteca.FindAsync(id);
            if (ubicacionBiblioteca == null)
            {
                return NotFound();
            }
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", ubicacionBiblioteca.IdLibro);
            return View(ubicacionBiblioteca);
        }

        // POST: UbicacionesBiblioteca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUbicacion,Estante,Seccion,IdLibro")] UbicacionBiblioteca ubicacionBiblioteca)
        {
            if (id != ubicacionBiblioteca.IdUbicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacionBiblioteca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionBibliotecaExists(ubicacionBiblioteca.IdUbicacion))
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
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", ubicacionBiblioteca.IdLibro);
            return View(ubicacionBiblioteca);
        }

        // GET: UbicacionesBiblioteca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionBiblioteca = await _context.UbicacionesBiblioteca
                .Include(u => u.Libro)
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicacionBiblioteca == null)
            {
                return NotFound();
            }

            return View(ubicacionBiblioteca);
        }

        // POST: UbicacionesBiblioteca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ubicacionBiblioteca = await _context.UbicacionesBiblioteca.FindAsync(id);
            if (ubicacionBiblioteca != null)
            {
                _context.UbicacionesBiblioteca.Remove(ubicacionBiblioteca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionBibliotecaExists(int id)
        {
            return _context.UbicacionesBiblioteca.Any(e => e.IdUbicacion == id);
        }
    }
}
