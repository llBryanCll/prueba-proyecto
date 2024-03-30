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
    public class DetalleReservaPaquetesController : Controller
    {
        private readonly LmourContext _context;

        public DetalleReservaPaquetesController(LmourContext context)
        {
            _context = context;
        }

        // GET: DetalleReservaPaquetes
        public async Task<IActionResult> Index()
        {
            var lmourContext = _context.DetalleReservaPaquetes.Include(d => d.IdPaqueteNavigation).Include(d => d.IdReservaNavigation);
            return View(await lmourContext.ToListAsync());
        }

        // GET: DetalleReservaPaquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleReservaPaquetes == null)
            {
                return NotFound();
            }

            var detalleReservaPaquete = await _context.DetalleReservaPaquetes
                .Include(d => d.IdPaqueteNavigation)
                .Include(d => d.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.DetalleReservaPaquete1 == id);
            if (detalleReservaPaquete == null)
            {
                return NotFound();
            }

            return View(detalleReservaPaquete);
        }

        // GET: DetalleReservaPaquetes/Create
        public IActionResult Create()
        {
            ViewData["IdPaquete"] = new SelectList(_context.Paquetes, "IdPaquete", "IdPaquete");
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            return View();
        }

        // POST: DetalleReservaPaquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleReservaPaquete1,IdPaquete,IdReserva,Cantidad,Costo")] DetalleReservaPaquete detalleReservaPaquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleReservaPaquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaquete"] = new SelectList(_context.Paquetes, "IdPaquete", "IdPaquete", detalleReservaPaquete.IdPaquete);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaPaquete.IdReserva);
            return View(detalleReservaPaquete);
        }

        // GET: DetalleReservaPaquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleReservaPaquetes == null)
            {
                return NotFound();
            }

            var detalleReservaPaquete = await _context.DetalleReservaPaquetes.FindAsync(id);
            if (detalleReservaPaquete == null)
            {
                return NotFound();
            }
            ViewData["IdPaquete"] = new SelectList(_context.Paquetes, "IdPaquete", "IdPaquete", detalleReservaPaquete.IdPaquete);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaPaquete.IdReserva);
            return View(detalleReservaPaquete);
        }

        // POST: DetalleReservaPaquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleReservaPaquete1,IdPaquete,IdReserva,Cantidad,Costo")] DetalleReservaPaquete detalleReservaPaquete)
        {
            if (id != detalleReservaPaquete.DetalleReservaPaquete1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleReservaPaquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleReservaPaqueteExists(detalleReservaPaquete.DetalleReservaPaquete1))
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
            ViewData["IdPaquete"] = new SelectList(_context.Paquetes, "IdPaquete", "IdPaquete", detalleReservaPaquete.IdPaquete);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleReservaPaquete.IdReserva);
            return View(detalleReservaPaquete);
        }

        // GET: DetalleReservaPaquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleReservaPaquetes == null)
            {
                return NotFound();
            }

            var detalleReservaPaquete = await _context.DetalleReservaPaquetes
                .Include(d => d.IdPaqueteNavigation)
                .Include(d => d.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.DetalleReservaPaquete1 == id);
            if (detalleReservaPaquete == null)
            {
                return NotFound();
            }

            return View(detalleReservaPaquete);
        }

        // POST: DetalleReservaPaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleReservaPaquetes == null)
            {
                return Problem("Entity set 'LmourContext.DetalleReservaPaquetes'  is null.");
            }
            var detalleReservaPaquete = await _context.DetalleReservaPaquetes.FindAsync(id);
            if (detalleReservaPaquete != null)
            {
                _context.DetalleReservaPaquetes.Remove(detalleReservaPaquete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleReservaPaqueteExists(int id)
        {
          return (_context.DetalleReservaPaquetes?.Any(e => e.DetalleReservaPaquete1 == id)).GetValueOrDefault();
        }
    }
}
