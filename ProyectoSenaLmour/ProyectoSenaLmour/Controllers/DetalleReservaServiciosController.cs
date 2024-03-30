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
    public class DetalleReservaServiciosController : Controller
    {
        private readonly LmourContext _context;

        public DetalleReservaServiciosController(LmourContext context)
        {
            _context = context;
        }

        // GET: DetalleReservaServicios
        public async Task<IActionResult> Index()
        {
            var lmourContext = _context.DetalleReservaServicios.Include(d => d.IdReservaNavigation).Include(d => d.IdServicioNavigation);
            return View(await lmourContext.ToListAsync());
        }

        // GET: DetalleReservaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleReservaServicios == null)
            {
                return NotFound();
            }

            var detalleReservaServicio = await _context.DetalleReservaServicios
                .Include(d => d.IdReservaNavigation)
                .Include(d => d.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleReservaServicio == id);
            if (detalleReservaServicio == null)
            {
                return NotFound();
            }

            return View(detalleReservaServicio);
        }

        // GET: DetalleReservaServicios/Create
        public IActionResult Create()
        {
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: DetalleReservaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleReservaServicio,IdServicio,IdReserva,Cantidad,Costo")] DetalleReservaServicio detalleReservaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleReservaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaServicio.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", detalleReservaServicio.IdServicio);
            return View(detalleReservaServicio);
        }

        // GET: DetalleReservaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleReservaServicios == null)
            {
                return NotFound();
            }

            var detalleReservaServicio = await _context.DetalleReservaServicios.FindAsync(id);
            if (detalleReservaServicio == null)
            {
                return NotFound();
            }
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaServicio.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", detalleReservaServicio.IdServicio);
            return View(detalleReservaServicio);
        }

        // POST: DetalleReservaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleReservaServicio,IdServicio,IdReserva,Cantidad,Costo")] DetalleReservaServicio detalleReservaServicio)
        {
            if (id != detalleReservaServicio.IdDetalleReservaServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleReservaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleReservaServicioExists(detalleReservaServicio.IdDetalleReservaServicio))
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
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaServicio.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", detalleReservaServicio.IdServicio);
            return View(detalleReservaServicio);
        }

        // GET: DetalleReservaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleReservaServicios == null)
            {
                return NotFound();
            }

            var detalleReservaServicio = await _context.DetalleReservaServicios
                .Include(d => d.IdReservaNavigation)
                .Include(d => d.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleReservaServicio == id);
            if (detalleReservaServicio == null)
            {
                return NotFound();
            }

            return View(detalleReservaServicio);
        }

        // POST: DetalleReservaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleReservaServicios == null)
            {
                return Problem("Entity set 'LmourContext.DetalleReservaServicios'  is null.");
            }
            var detalleReservaServicio = await _context.DetalleReservaServicios.FindAsync(id);
            if (detalleReservaServicio != null)
            {
                _context.DetalleReservaServicios.Remove(detalleReservaServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleReservaServicioExists(int id)
        {
          return (_context.DetalleReservaServicios?.Any(e => e.IdDetalleReservaServicio == id)).GetValueOrDefault();
        }
    }
}
