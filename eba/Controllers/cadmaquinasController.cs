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
    public class cadmaquinasController : Controller
    {
        private readonly bdContext _context;

        public cadmaquinasController(bdContext context)
        {
            _context = context;
        }

        // GET: cadmaquinas
        public async Task<IActionResult> Index()
        {
              return _context.cadmaquinas != null ? 
                          View(await _context.cadmaquinas.ToListAsync()) :
                          Problem("Entity set 'bdContext.cadmaquinas'  is null.");
        }

        // GET: cadmaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadmaquinas == null)
            {
                return NotFound();
            }

            var cadmaquinas = await _context.cadmaquinas
                .FirstOrDefaultAsync(m => m.idmaquina == id);
            if (cadmaquinas == null)
            {
                return NotFound();
            }

            return View(cadmaquinas);
        }

        // GET: cadmaquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadmaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idmaquina,nomemaquina,patrimonio,memoria,hd")] cadmaquinas cadmaquinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadmaquinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadmaquinas);
        }

        // GET: cadmaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadmaquinas == null)
            {
                return NotFound();
            }

            var cadmaquinas = await _context.cadmaquinas.FindAsync(id);
            if (cadmaquinas == null)
            {
                return NotFound();
            }
            return View(cadmaquinas);
        }

        // POST: cadmaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idmaquina,nomemaquina,patrimonio,memoria,hd")] cadmaquinas cadmaquinas)
        {
            if (id != cadmaquinas.idmaquina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadmaquinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadmaquinasExists(cadmaquinas.idmaquina))
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
            return View(cadmaquinas);
        }

        // GET: cadmaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadmaquinas == null)
            {
                return NotFound();
            }

            var cadmaquinas = await _context.cadmaquinas
                .FirstOrDefaultAsync(m => m.idmaquina == id);
            if (cadmaquinas == null)
            {
                return NotFound();
            }

            return View(cadmaquinas);
        }

        // POST: cadmaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadmaquinas == null)
            {
                return Problem("Entity set 'bdContext.cadmaquinas'  is null.");
            }
            var cadmaquinas = await _context.cadmaquinas.FindAsync(id);
            if (cadmaquinas != null)
            {
                _context.cadmaquinas.Remove(cadmaquinas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadmaquinasExists(int id)
        {
          return (_context.cadmaquinas?.Any(e => e.idmaquina == id)).GetValueOrDefault();
        }
    }
}
