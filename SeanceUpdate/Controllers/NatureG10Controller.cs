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
    public class NatureG10Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public NatureG10Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NatureG10
        public async Task<IActionResult> Index()
        {
            return View(await _context.NatureG10.ToListAsync());
        }

        // GET: NatureG10/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureG10 = await _context.NatureG10
                .FirstOrDefaultAsync(m => m.NatCode == id);
            if (natureG10 == null)
            {
                return NotFound();
            }

            return View(natureG10);
        }

        // GET: NatureG10/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NatureG10/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NatCode,NatDesignation")] NatureG10 natureG10)
        {
            if (ModelState.IsValid)
            {
                _context.Add(natureG10);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(natureG10);
        }

        // GET: NatureG10/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureG10 = await _context.NatureG10.FindAsync(id);
            if (natureG10 == null)
            {
                return NotFound();
            }
            return View(natureG10);
        }

        // POST: NatureG10/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NatCode,NatDesignation")] NatureG10 natureG10)
        {
            if (id != natureG10.NatCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(natureG10);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatureG10Exists(natureG10.NatCode))
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
            return View(natureG10);
        }

        // GET: NatureG10/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureG10 = await _context.NatureG10
                .FirstOrDefaultAsync(m => m.NatCode == id);
            if (natureG10 == null)
            {
                return NotFound();
            }

            return View(natureG10);
        }

        // POST: NatureG10/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var natureG10 = await _context.NatureG10.FindAsync(id);
            if (natureG10 != null)
            {
                _context.NatureG10.Remove(natureG10);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatureG10Exists(int id)
        {
            return _context.NatureG10.Any(e => e.NatCode == id);
        }
    }
}
