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

        public UbicacionesBibliotecaController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: UbicacionesBiblioteca
        public async Task<IActionResult> Index()
        {
            return View(await _context.UbicacionesBiblioteca.ToListAsync());
        }

        // GET: UbicacionesBiblioteca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionBiblioteca = await _context.UbicacionesBiblioteca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacionBiblioteca == null)
            {
                return NotFound();
            }

            return View(ubicacionBiblioteca);
        }

        // GET: UbicacionesBiblioteca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UbicacionesBiblioteca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estante,Seccion")] UbicacionBiblioteca ubicacionBiblioteca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacionBiblioteca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(ubicacionBiblioteca);
        }

        // POST: UbicacionesBiblioteca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estante,Seccion")] UbicacionBiblioteca ubicacionBiblioteca)
        {
            if (id != ubicacionBiblioteca.Id)
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
                    if (!UbicacionBibliotecaExists(ubicacionBiblioteca.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.UbicacionesBiblioteca.Any(e => e.Id == id);
        }
    }
}
