using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMOficialGestorDeTareasMVC.Models;

namespace DMOficialGestorDeTareasMVC.Controllers
{
    public class DMCategoriasController : Controller
    {
        private readonly DMOficialGestorDeTareasMVCContext _context;

        public DMCategoriasController(DMOficialGestorDeTareasMVCContext context)
        {
            _context = context;
        }

        // GET: DMCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.DMCategoria.ToListAsync());
        }

        // GET: DMCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMCategoria = await _context.DMCategoria
                .FirstOrDefaultAsync(m => m.DMCategoriaID == id);
            if (dMCategoria == null)
            {
                return NotFound();
            }

            return View(dMCategoria);
        }

        // GET: DMCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DMCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DMCategoriaID,DMNombre,DMDescripcion")] DMCategoria dMCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dMCategoria);
        }

        // GET: DMCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMCategoria = await _context.DMCategoria.FindAsync(id);
            if (dMCategoria == null)
            {
                return NotFound();
            }
            return View(dMCategoria);
        }

        // POST: DMCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DMCategoriaID,DMNombre,DMDescripcion")] DMCategoria dMCategoria)
        {
            if (id != dMCategoria.DMCategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMCategoriaExists(dMCategoria.DMCategoriaID))
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
            return View(dMCategoria);
        }

        // GET: DMCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMCategoria = await _context.DMCategoria
                .FirstOrDefaultAsync(m => m.DMCategoriaID == id);
            if (dMCategoria == null)
            {
                return NotFound();
            }

            return View(dMCategoria);
        }

        // POST: DMCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMCategoria = await _context.DMCategoria.FindAsync(id);
            if (dMCategoria != null)
            {
                _context.DMCategoria.Remove(dMCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMCategoriaExists(int id)
        {
            return _context.DMCategoria.Any(e => e.DMCategoriaID == id);
        }
    }
}
