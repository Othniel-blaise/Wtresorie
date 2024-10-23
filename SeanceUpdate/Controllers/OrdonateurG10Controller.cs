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
    public class OrdonateurG10Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdonateurG10Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdonateurG10
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdonateurG10.ToListAsync());
        }

        // GET: OrdonateurG10/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonateurG10 = await _context.OrdonateurG10
                .FirstOrDefaultAsync(m => m.OrdCode == id);
            if (ordonateurG10 == null)
            {
                return NotFound();
            }

            return View(ordonateurG10);
        }

        // GET: OrdonateurG10/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdonateurG10/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdCode,OrdNom,OrdPrenom,OrdFonction")] OrdonateurG10 ordonateurG10)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordonateurG10);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordonateurG10);
        }

        // GET: OrdonateurG10/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonateurG10 = await _context.OrdonateurG10.FindAsync(id);
            if (ordonateurG10 == null)
            {
                return NotFound();
            }
            return View(ordonateurG10);
        }

        // POST: OrdonateurG10/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdCode,OrdNom,OrdPrenom,OrdFonction")] OrdonateurG10 ordonateurG10)
        {
            if (id != ordonateurG10.OrdCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordonateurG10);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdonateurG10Exists(ordonateurG10.OrdCode))
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
            return View(ordonateurG10);
        }

        // GET: OrdonateurG10/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonateurG10 = await _context.OrdonateurG10
                .FirstOrDefaultAsync(m => m.OrdCode == id);
            if (ordonateurG10 == null)
            {
                return NotFound();
            }

            return View(ordonateurG10);
        }

        // POST: OrdonateurG10/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordonateurG10 = await _context.OrdonateurG10.FindAsync(id);
            if (ordonateurG10 != null)
            {
                _context.OrdonateurG10.Remove(ordonateurG10);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdonateurG10Exists(int id)
        {
            return _context.OrdonateurG10.Any(e => e.OrdCode == id);
        }
    }
}
