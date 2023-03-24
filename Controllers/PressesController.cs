using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Data;

namespace Biblioteka.Controllers
{
    public class PressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Presses
        public async Task<IActionResult> Index()
        {
              return _context.Presses != null ? 
                          View(await _context.Presses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Presses'  is null.");
        }

        // GET: Presses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presses == null)
            {
                return NotFound();
            }

            var press = await _context.Presses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (press == null)
            {
                return NotFound();
            }

            return View(press);
        }

        // GET: Presses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LogoURL")] Press press)
        {
            if (ModelState.IsValid)
            {
                _context.Presses.Add(press);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(press);
        }

        // GET: Presses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presses == null)
            {
                return NotFound();
            }

            var press = await _context.Presses.FindAsync(id);
            if (press == null)
            {
                return NotFound();
            }
            return View(press);
        }

        // POST: Presses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoURL")] Press press)
        {
            if (id != press.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Presses.Update(press);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PressExists(press.Id))
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
            return View(press);
        }

        // GET: Presses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presses == null)
            {
                return NotFound();
            }

            var press = await _context.Presses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (press == null)
            {
                return NotFound();
            }

            return View(press);
        }

        // POST: Presses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Presses'  is null.");
            }
            var press = await _context.Presses.FindAsync(id);
            if (press != null)
            {
                _context.Presses.Remove(press);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PressExists(int id)
        {
          return (_context.Presses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
