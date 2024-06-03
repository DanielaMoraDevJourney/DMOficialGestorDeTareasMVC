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
    public class DMTareasController : Controller
    {
        private readonly DMOficialGestorDeTareasMVCContext _context;

        public DMTareasController(DMOficialGestorDeTareasMVCContext context)
        {
            _context = context;
        }

        // GET: DMTareas
        public async Task<IActionResult> Index()
        {
            var dMOficialGestorDeTareasMVCContext = _context.DMTarea.Include(d => d.DMCategoria).Include(d => d.DMPrioridad);
            return View(await dMOficialGestorDeTareasMVCContext.ToListAsync());
        }

        // GET: DMTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea
                .Include(d => d.DMCategoria)
                .Include(d => d.DMPrioridad)
                .FirstOrDefaultAsync(m => m.DMTareaID == id);
            if (dMTarea == null)
            {
                return NotFound();
            }

            return View(dMTarea);
        }

        // GET: DMTareas/Create
        public IActionResult Create()
        {
            ViewData["DMCategoriaID"] = new SelectList(_context.DMCategoria, "DMCategoriaID", "DMNombre");
            ViewData["DMPrioridadID"] = new SelectList(_context.DMPrioridad, "DMPrioridadID", "DMDescripcion");
            return View();
        }

        // POST: DMTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DMTareaID,DMTitulo,DMDescripcion,DMFechaVencimiento,DMPrioridadID,DMCategoriaID")] DMTarea dMTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DMCategoriaID"] = new SelectList(_context.DMCategoria, "DMCategoriaID", "DMNombre", dMTarea.DMCategoriaID);
            ViewData["DMPrioridadID"] = new SelectList(_context.DMPrioridad, "DMPrioridadID", "DMDescripcion", dMTarea.DMPrioridadID);
            return View(dMTarea);
        }

        // GET: DMTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea.FindAsync(id);
            if (dMTarea == null)
            {
                return NotFound();
            }
            ViewData["DMCategoriaID"] = new SelectList(_context.DMCategoria, "DMCategoriaID", "DMNombre", dMTarea.DMCategoriaID);
            ViewData["DMPrioridadID"] = new SelectList(_context.DMPrioridad, "DMPrioridadID", "DMDescripcion", dMTarea.DMPrioridadID);
            return View(dMTarea);
        }

        // POST: DMTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DMTareaID,DMTitulo,DMDescripcion,DMFechaVencimiento,DMPrioridadID,DMCategoriaID")] DMTarea dMTarea)
        {
            if (id != dMTarea.DMTareaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMTareaExists(dMTarea.DMTareaID))
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
            ViewData["DMCategoriaID"] = new SelectList(_context.DMCategoria, "DMCategoriaID", "DMNombre", dMTarea.DMCategoriaID);
            ViewData["DMPrioridadID"] = new SelectList(_context.DMPrioridad, "DMPrioridadID", "DMDescripcion", dMTarea.DMPrioridadID);
            return View(dMTarea);
        }

        // GET: DMTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea
                .Include(d => d.DMCategoria)
                .Include(d => d.DMPrioridad)
                .FirstOrDefaultAsync(m => m.DMTareaID == id);
            if (dMTarea == null)
            {
                return NotFound();
            }

            return View(dMTarea);
        }

        // POST: DMTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMTarea = await _context.DMTarea.FindAsync(id);
            if (dMTarea != null)
            {
                _context.DMTarea.Remove(dMTarea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMTareaExists(int id)
        {
            return _context.DMTarea.Any(e => e.DMTareaID == id);
        }
    }
}
