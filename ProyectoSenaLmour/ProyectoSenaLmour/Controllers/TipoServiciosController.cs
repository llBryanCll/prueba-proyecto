using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSenaLmour.Models;

namespace ProyectoSenaLmour.Controllers
{
    public class TipoServiciosController : Controller
    {
        private readonly LmourContext _context;

        public TipoServiciosController(LmourContext context)
        {
            _context = context;
        }

        // GET: TipoServicios
        public async Task<IActionResult> Index()
        {
              return _context.TipoServicios != null ? 
                          View(await _context.TipoServicios.ToListAsync()) :
                          Problem("Entity set 'LmourContext.TipoServicios'  is null.");
        }

        // GET: TipoServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            return View(tipoServicio);
        }

        // GET: TipoServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoServicio,NombreTipoServicio")] TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoServicio);
        }

        // GET: TipoServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios.FindAsync(id);
            if (tipoServicio == null)
            {
                return NotFound();
            }
            return View(tipoServicio);
        }

        // POST: TipoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoServicio,NombreTipoServicio")] TipoServicio tipoServicio)
        {
            if (id != tipoServicio.IdTipoServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoServicioExists(tipoServicio.IdTipoServicio))
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
            return View(tipoServicio);
        }

        // GET: TipoServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            return View(tipoServicio);
        }

        // POST: TipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoServicios == null)
            {
                return Problem("Entity set 'LmourContext.TipoServicios'  is null.");
            }
            var tipoServicio = await _context.TipoServicios.FindAsync(id);
            if (tipoServicio != null)
            {
                _context.TipoServicios.Remove(tipoServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoServicioExists(int id)
        {
          return (_context.TipoServicios?.Any(e => e.IdTipoServicio == id)).GetValueOrDefault();
        }
    }
}
