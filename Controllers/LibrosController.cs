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
    public class LibrosController : Controller
    {
        private readonly AppDBcontext _context;

        // inyección de dependencia SQL
        public LibrosController(AppDBcontext context)
        {
            _context = context;
        }

        //public LibrosController()
        //{
        //    _context = new AppDBcontext();
        //}

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.Libros.Include(l => l.Estado).Include(l => l.Idioma).Include(l => l.Calificacion).Include(l => l.LibrosAutores).ThenInclude(la => la.Autor);
            //Agregando theninclude también se carga la información del
            //autor, no hay otra forma de hacerlo
            return View(await appDBcontext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Estado)
                .Include(l => l.Idioma)
                .Include(l => l.Calificacion)
        .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
        .FirstOrDefaultAsync(l => l.IdLibro == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Condición"); //id, info
            ViewData["IdIdioma"] = new SelectList(_context.Idiomas, "IdIdioma", "Tipo");
            ViewData["IdCalificacion"] = new SelectList(_context.Idiomas, "IdCalificacion", "NumCalificacion");

            ViewBag.Autores = new MultiSelectList(_context.Autores, "IdAutor", "Nombre");
            //devuelve la lista de autores
            //crea un select list con la list autores, que guarda el id y muestra el nombre

            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,CantidadCopias,CantidadPags,IdEstado,IdIdioma,IdCalificacion")] Libro libro,
            List<int> autoresSeleccionados)//se agrega como parámetro para lista de autores
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();

                // Relacionar los autores seleccionados con el libro
                if (autoresSeleccionados != null && autoresSeleccionados.Count > 0)
                {
                    foreach (var idAutor in autoresSeleccionados)
                    {
                        var libroAutor = new LibroAutor
                        {
                            IdLibro = libro.IdLibro,
                            IdAutor = idAutor
                        };
                        _context.LibrosAutores.Add(libroAutor);
                    }
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            // En caso de error, cargar nuevamente los estados, idiomas y autores
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", libro.IdEstado);
            ViewData["IdIdioma"] = new SelectList(_context.Idiomas, "IdIdioma", "IdIdioma", libro.IdIdioma);
            ViewData["IdCalificacion"] = new SelectList(_context.Idiomas, "IdCalificacion", "NumCalificacion", libro.IdCalificacion);

            // Volver a cargar la lista de autores
            ViewBag.Autores = new MultiSelectList(_context.Autores, "IdAutor", "Nombre");
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Condición", libro.IdEstado);
            ViewData["IdIdioma"] = new SelectList(_context.Idiomas, "IdIdioma", "Tipo", libro.IdIdioma);
            ViewData["IdCalificacion"] = new SelectList(_context.Idiomas, "IdCalificacion", "NumCalificacion", libro.IdCalificacion);
            ViewBag.Autores = new MultiSelectList(_context.Autores, "IdAutor", "Nombre");

            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,CantidadCopias,CantidadPags,CalificacionPromedio,IdEstado,IdIdioma")] Libro libro,
            List<int> autoresSeleccionados)//se agrega como parámetro para lista de autores
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro); //actualiza libro pero no, libroautor
                    await _context.SaveChangesAsync();
                    // Elimina las relaciones antiguas en la tabla intermedia LibroAutor
                    var autoresAntiguos = _context.LibrosAutores.Where(la => la.IdLibro == libro.IdLibro);
                    _context.LibrosAutores.RemoveRange(autoresAntiguos);
                    await _context.SaveChangesAsync();

                    // Agrega las nuevas relaciones en la tabla intermedia LibroAutor
                    if (autoresSeleccionados != null && autoresSeleccionados.Count > 0)
                    {
                        foreach (var IdAuto in autoresSeleccionados)
                        {
                            var libroAutor = new LibroAutor
                            {
                                IdLibro = libro.IdLibro,
                                IdAutor = IdAuto
                            };
                            _context.LibrosAutores.Add(libroAutor);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            // Si el modelo no es válido, vuelve a cargar las listas desplegables
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", libro.IdEstado);
            ViewData["IdIdioma"] = new SelectList(_context.Idiomas, "IdIdioma", "IdIdioma", libro.IdIdioma);
            ViewData["IdCalificacion"] = new SelectList(_context.Idiomas, "IdIdioma", "IdIdioma", libro.IdIdioma);
            ViewBag.Autores = new MultiSelectList(_context.Autores, "IdAutor", "Nombre");
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Estado)
                .Include(l => l.Idioma)
                .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
