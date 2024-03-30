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
    public class PermisosRolesController : Controller
    {
        private readonly LmourContext _context;

        public PermisosRolesController(LmourContext context)
        {
            _context = context;
        }

        // GET: PermisosRoles
        public async Task<IActionResult> Index()
        {
            var lmourContext = _context.PermisosRoles.Include(p => p.IdPermisoNavigation).Include(p => p.IdRolNavigation);
            return View(await lmourContext.ToListAsync());
        }

        // GET: PermisosRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles
                .Include(p => p.IdPermisoNavigation)
                .Include(p => p.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdPermisosRoles == id);
            if (permisosRole == null)
            {
                return NotFound();
            }

            return View(permisosRole);
        }

        // GET: PermisosRoles/Create
        public IActionResult Create()
        {
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: PermisosRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermisosRoles,IdRol,IdPermiso")] PermisosRole permisosRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisosRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", permisosRole.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", permisosRole.IdRol);
            return View(permisosRole);
        }

        // GET: PermisosRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles.FindAsync(id);
            if (permisosRole == null)
            {
                return NotFound();
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", permisosRole.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", permisosRole.IdRol);
            return View(permisosRole);
        }

        // POST: PermisosRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermisosRoles,IdRol,IdPermiso")] PermisosRole permisosRole)
        {
            if (id != permisosRole.IdPermisosRoles)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisosRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisosRoleExists(permisosRole.IdPermisosRoles))
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
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", permisosRole.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", permisosRole.IdRol);
            return View(permisosRole);
        }

        // GET: PermisosRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles
                .Include(p => p.IdPermisoNavigation)
                .Include(p => p.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdPermisosRoles == id);
            if (permisosRole == null)
            {
                return NotFound();
            }

            return View(permisosRole);
        }

        // POST: PermisosRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PermisosRoles == null)
            {
                return Problem("Entity set 'LmourContext.PermisosRoles'  is null.");
            }
            var permisosRole = await _context.PermisosRoles.FindAsync(id);
            if (permisosRole != null)
            {
                _context.PermisosRoles.Remove(permisosRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisosRoleExists(int id)
        {
          return (_context.PermisosRoles?.Any(e => e.IdPermisosRoles == id)).GetValueOrDefault();
        }
    }
}
