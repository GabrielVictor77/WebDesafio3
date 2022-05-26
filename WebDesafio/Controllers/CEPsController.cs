using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDesafio.Models;

namespace WebDesafio.Controllers
{
    public class CEPsController : Controller
    {
        private readonly Contexto_desafio _context;

        public CEPsController(Contexto_desafio context)
        {
            _context = context;
        }

        // GET: CEPs
        public async Task<IActionResult> Index()
        {
              return _context.CEP != null ? 
                          View(await _context.CEP.ToListAsync()) :
                          Problem("Entity set 'Contexto_desafio.CEP'  is null.");
        }

        // GET: CEPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CEP == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEP
                .FirstOrDefaultAsync(m => m.id == id);
            if (cEP == null)
            {
                return NotFound();
            }

            return View(cEP);
        }

        // GET: CEPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CEPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Residencia")] CEP cEP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cEP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cEP);
        }

        // GET: CEPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CEP == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEP.FindAsync(id);
            if (cEP == null)
            {
                return NotFound();
            }
            return View(cEP);
        }

        // POST: CEPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Residencia")] CEP cEP)
        {
            if (id != cEP.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cEP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CEPExists(cEP.id))
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
            return View(cEP);
        }

        // GET: CEPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CEP == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEP
                .FirstOrDefaultAsync(m => m.id == id);
            if (cEP == null)
            {
                return NotFound();
            }

            return View(cEP);
        }

        // POST: CEPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CEP == null)
            {
                return Problem("Entity set 'Contexto_desafio.CEP'  is null.");
            }
            var cEP = await _context.CEP.FindAsync(id);
            if (cEP != null)
            {
                _context.CEP.Remove(cEP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CEPExists(int id)
        {
          return (_context.CEP?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
