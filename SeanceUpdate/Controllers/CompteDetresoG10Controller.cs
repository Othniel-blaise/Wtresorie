using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeanceUpdate.Data;
using SeanceUpdate.Models;

namespace SeanceUpdate.Controllers
{
    public class CompteDetresoG10Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompteDetresoG10Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompteDetresoG10
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompteDetresoG10.ToListAsync());
        }

        // GET: CompteDetresoG10/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteDetresoG10 = await _context.CompteDetresoG10
                .FirstOrDefaultAsync(m => m.CptNumero == id);
            if (compteDetresoG10 == null)
            {
                return NotFound();
            }

            return View(compteDetresoG10);
        }

        // GET: CompteDetresoG10/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompteDetresoG10/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CptNumero,CptDesignation,CptDescription")] CompteDetresoG10 compteDetresoG10)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compteDetresoG10);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compteDetresoG10);
        }

        // GET: CompteDetresoG10/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteDetresoG10 = await _context.CompteDetresoG10.FindAsync(id);
            if (compteDetresoG10 == null)
            {
                return NotFound();
            }
            return View(compteDetresoG10);
        }

        // POST: CompteDetresoG10/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CptNumero,CptDesignation,CptDescription")] CompteDetresoG10 compteDetresoG10)
        {
            if (id != compteDetresoG10.CptNumero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compteDetresoG10);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompteDetresoG10Exists(compteDetresoG10.CptNumero))
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
            return View(compteDetresoG10);
        }

        // GET: CompteDetresoG10/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compteDetresoG10 = await _context.CompteDetresoG10
                .FirstOrDefaultAsync(m => m.CptNumero == id);
            if (compteDetresoG10 == null)
            {
                return NotFound();
            }

            return View(compteDetresoG10);
        }

        // POST: CompteDetresoG10/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compteDetresoG10 = await _context.CompteDetresoG10.FindAsync(id);
            if (compteDetresoG10 != null)
            {
                _context.CompteDetresoG10.Remove(compteDetresoG10);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompteDetresoG10Exists(int id)
        {
            return _context.CompteDetresoG10.Any(e => e.CptNumero == id);
        }
    }
}
