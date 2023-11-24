using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eba.Data;
using eba.Models;

namespace eba.Controllers
{
    public class inventariosController : Controller
    {
        private readonly bdContext _context;

        public inventariosController(bdContext context)
        {
            _context = context;
        }

        // GET: inventarios
        public async Task<IActionResult> Index()
        {
              return _context.inventario != null ? 
                          View(await _context.inventario.ToListAsync()) :
                          Problem("Entity set 'bdContext.inventario'  is null.");
        }

        // GET: inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.inventario
                .FirstOrDefaultAsync(m => m.idinventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: inventarios/Create
        public IActionResult Create()
        {
            inventariomodel model = new inventariomodel();
            model.listacli = _context.cadclientes.ToList();
            model.listamaq = _context.cadmaquinas.ToList();
            return View(model);
        }

        // POST: inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idinventario,idcliente,idmaquina,qtvalor")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idinventario,idcliente,idmaquina,qtvalor")] inventario inventario)
        {
            if (id != inventario.idinventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inventarioExists(inventario.idinventario))
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
            return View(inventario);
        }

        // GET: inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.inventario
                .FirstOrDefaultAsync(m => m.idinventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inventario == null)
            {
                return Problem("Entity set 'bdContext.inventario'  is null.");
            }
            var inventario = await _context.inventario.FindAsync(id);
            if (inventario != null)
            {
                _context.inventario.Remove(inventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inventarioExists(int id)
        {
          return (_context.inventario?.Any(e => e.idinventario == id)).GetValueOrDefault();
        }
    }
}
