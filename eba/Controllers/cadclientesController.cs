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
    public class cadclientesController : Controller
    {
        private readonly bdContext _context;

        public cadclientesController(bdContext context)
        {
            _context = context;
        }

        // GET: cadclientes
        public async Task<IActionResult> Index()
        {
              return _context.cadclientes != null ? 
                          View(await _context.cadclientes.ToListAsync()) :
                          Problem("Entity set 'bdContext.cadclientes'  is null.");
        }

        // GET: cadclientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadclientes == null)
            {
                return NotFound();
            }

            var cadclientes = await _context.cadclientes
                .FirstOrDefaultAsync(m => m.idcliente == id);
            if (cadclientes == null)
            {
                return NotFound();
            }

            return View(cadclientes);
        }

        // GET: cadclientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadclientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idcliente,nomecliente,idade,cpf")] cadclientes cadclientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadclientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadclientes);
        }

        // GET: cadclientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadclientes == null)
            {
                return NotFound();
            }

            var cadclientes = await _context.cadclientes.FindAsync(id);
            if (cadclientes == null)
            {
                return NotFound();
            }
            return View(cadclientes);
        }

        // POST: cadclientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idcliente,nomecliente,idade,cpf")] cadclientes cadclientes)
        {
            if (id != cadclientes.idcliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadclientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadclientesExists(cadclientes.idcliente))
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
            return View(cadclientes);
        }

        // GET: cadclientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadclientes == null)
            {
                return NotFound();
            }

            var cadclientes = await _context.cadclientes
                .FirstOrDefaultAsync(m => m.idcliente == id);
            if (cadclientes == null)
            {
                return NotFound();
            }

            return View(cadclientes);
        }

        // POST: cadclientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadclientes == null)
            {
                return Problem("Entity set 'bdContext.cadclientes'  is null.");
            }
            var cadclientes = await _context.cadclientes.FindAsync(id);
            if (cadclientes != null)
            {
                _context.cadclientes.Remove(cadclientes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadclientesExists(int id)
        {
          return (_context.cadclientes?.Any(e => e.idcliente == id)).GetValueOrDefault();
        }
    }
}
