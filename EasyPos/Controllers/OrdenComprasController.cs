using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyPos.Models;

namespace EasyPos.Controllers
{
    public class OrdenComprasController : Controller
    {
        private readonly EasyPosDb _context;

        public OrdenComprasController(EasyPosDb context)
        {
            _context = context;
        }

        // GET: OrdenCompras
        public async Task<IActionResult> Index()
        {
            var easyPosDb = _context.OrdenCompra.Include(o => o.Proveedor).Include(o => o.Usuario);
            return View(await easyPosDb.ToListAsync());
        }

        // GET: OrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenCompra == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra
                .Include(o => o.Proveedor)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.OrdenCompraId == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public IActionResult Create()
        {
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "ProveedorId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenCompraId,ProveedorId,Fecha,SubTotal,Isv,Total,UsuarioId,Estado")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "Nombre", ordenCompra.ProveedorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", ordenCompra.UsuarioId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenCompra == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "ProveedorId", ordenCompra.ProveedorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", ordenCompra.UsuarioId);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenCompraId,ProveedorId,Fecha,SubTotal,Isv,Total,UsuarioId,Estado")] OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.OrdenCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraExists(ordenCompra.OrdenCompraId))
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
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "ProveedorId", "ProveedorId", ordenCompra.ProveedorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", ordenCompra.UsuarioId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenCompra == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra
                .Include(o => o.Proveedor)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.OrdenCompraId == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenCompra == null)
            {
                return Problem("Entity set 'EasyPosDb.OrdenCompra'  is null.");
            }
            var ordenCompra = await _context.OrdenCompra.FindAsync(id);
            if (ordenCompra != null)
            {
                _context.OrdenCompra.Remove(ordenCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraExists(int id)
        {
          return (_context.OrdenCompra?.Any(e => e.OrdenCompraId == id)).GetValueOrDefault();
        }
    }
}
