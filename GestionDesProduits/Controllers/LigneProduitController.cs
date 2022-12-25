using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionDesProduits.Data;
using GestionDesProduits.Models;

namespace GestionDesProduits.Controllers
{
    public class LigneProduitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LigneProduitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LigneProduits
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.LigneProduit.Include(e => e.ProduitPromo).ToListAsync();
              return View(await ApplicationDbContext);
        }

        // GET: LigneProduits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LigneProduit == null)
            {
                return NotFound();
            }

            var ligneProduit = await _context.LigneProduit.Include(e => e.ProduitPromo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ligneProduit == null)
            {
                return NotFound();
            }

            return View(ligneProduit);
        }

        // GET: LigneProduits/Create
        public IActionResult Create()
        {
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "NomProduit");
            return View();
        }

        // POST: LigneProduits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateDebutPromo,DateFinPromo,prixProduit,prixProduitEnPromo,ProduitPromoId")] LigneProduit ligneProduit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ligneProduit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "NomProduit", ligneProduit.ProduitPromoId);
            return View(ligneProduit);
        }

        // GET: LigneProduits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LigneProduit == null)
            {
                return NotFound();
            }

            var ligneProduit = await _context.LigneProduit.FindAsync(id);
            if (ligneProduit == null)
            {
                return NotFound();
            }
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "NomProduit", ligneProduit.ProduitPromoId);
            return View(ligneProduit);
        }

        // POST: LigneProduits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateDebutPromo,DateFinPromo,prixProduit,prixProduitEnPromo,ProduitPromoId")] LigneProduit ligneProduit)
        {
            if (id != ligneProduit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ligneProduit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigneProduitExists(ligneProduit.Id))
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
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "NomProduit", ligneProduit.ProduitPromoId);
            return View(ligneProduit);
        }

        // GET: LigneProduits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LigneProduit == null)
            {
                return NotFound();
            }

            var ligneProduit = await _context.LigneProduit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ligneProduit == null)
            {
                return NotFound();
            }
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "NomProduit", ligneProduit.ProduitPromoId);
            return View(ligneProduit);
        }

        // POST: LigneProduits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LigneProduit == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LigneProduit'  is null.");
            }
            var ligneProduit = await _context.LigneProduit.FindAsync(id);
            if (ligneProduit != null)
            {
                _context.LigneProduit.Remove(ligneProduit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LigneProduitExists(int id)
        {
          return _context.LigneProduit.Any(e => e.Id == id);
        }
    }
}
