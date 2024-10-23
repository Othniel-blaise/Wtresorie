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
    public class OperationG10Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperationG10Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OperationG10
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OperationG10.Include(o => o.Compte).Include(o => o.Ordonateur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OperationG10/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationG10 = await _context.OperationG10
                .Include(o => o.Compte)
                .Include(o => o.Ordonateur)
                .FirstOrDefaultAsync(m => m.OperRef == id);
            if (operationG10 == null)
            {
                return NotFound();
            }

            return View(operationG10);
        }

        // GET: OperationG10/Create
        public IActionResult Create()
        {
            ViewData["CptNumero"] = new SelectList(_context.Set<CompteDetresoG10>(), "CptNumero", "CptDesignation");
            ViewData["OrdCode"] = new SelectList(_context.Set<OrdonateurG10>(), "OrdCode", "OrdNom");
            return View();
        }

        // POST: OperationG10/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperRef,OperDate,OperLibelle,OperMontDebit,OperMontCredit,OperSolde,OperBeneficiaire,OperExecutant,OperObserva,NatCode,CptNumero,OrdCode")] OperationG10 operationG10)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operationG10);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CptNumero"] = new SelectList(_context.Set<CompteDetresoG10>(), "CptNumero", "CptDesignation", operationG10.CptNumero);
            ViewData["OrdCode"] = new SelectList(_context.Set<OrdonateurG10>(), "OrdCode", "OrdNom", operationG10.OrdCode);
            return View(operationG10);
        }

        // GET: OperationG10/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationG10 = await _context.OperationG10.FindAsync(id);
            if (operationG10 == null)
            {
                return NotFound();
            }
            ViewData["CptNumero"] = new SelectList(_context.Set<CompteDetresoG10>(), "CptNumero", "CptDesignation", operationG10.CptNumero);
            ViewData["OrdCode"] = new SelectList(_context.Set<OrdonateurG10>(), "OrdCode", "OrdNom", operationG10.OrdCode);
            return View(operationG10);
        }

        // POST: OperationG10/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperRef,OperDate,OperLibelle,OperMontDebit,OperMontCredit,OperSolde,OperBeneficiaire,OperExecutant,OperObserva,NatCode,CptNumero,OrdCode")] OperationG10 operationG10)
        {
            if (id != operationG10.OperRef)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operationG10);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationG10Exists(operationG10.OperRef))
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
            ViewData["CptNumero"] = new SelectList(_context.Set<CompteDetresoG10>(), "CptNumero", "CptDesignation", operationG10.CptNumero);
            ViewData["OrdCode"] = new SelectList(_context.Set<OrdonateurG10>(), "OrdCode", "OrdNom", operationG10.OrdCode);
            return View(operationG10);
        }

        // GET: OperationG10/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationG10 = await _context.OperationG10
                .Include(o => o.Compte)
                .Include(o => o.Ordonateur)
                .FirstOrDefaultAsync(m => m.OperRef == id);
            if (operationG10 == null)
            {
                return NotFound();
            }

            return View(operationG10);
        }

        // POST: OperationG10/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operationG10 = await _context.OperationG10.FindAsync(id);
            if (operationG10 != null)
            {
                _context.OperationG10.Remove(operationG10);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationG10Exists(int id)
        {
            return _context.OperationG10.Any(e => e.OperRef == id);
        }
    }
}
