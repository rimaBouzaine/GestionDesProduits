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
    public class ProduitPromoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitPromoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProduitPromoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProduitPromo.Include(p => p.Categories).Include(p => p.Magasins);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProduitPromoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProduitPromo == null)
            {
                return NotFound();
            }

            var produitPromo = await _context.ProduitPromo
                .Include(p => p.Categories)
                .Include(p => p.Magasins)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitPromo == null)
            {
                return NotFound();
            }

            return View(produitPromo);
        }

        // GET: ProduitPromoes/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "NomCategorie");
            ViewData["MagasinId"] = new SelectList(_context.Magasin, "Id", "NomParVille");
            return View();
        }

        // POST: ProduitPromoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProduit,MagasinId,CategorieId")] ProduitPromo produitPromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produitPromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "NomCategorie", produitPromo.CategorieId);
            ViewData["MagasinId"] = new SelectList(_context.Magasin, "Id", "NomParVille", produitPromo.MagasinId);
            return View(produitPromo);
        }

        // GET: ProduitPromoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProduitPromo == null)
            {
                return NotFound();
            }

            var produitPromo = await _context.ProduitPromo.FindAsync(id);
            if (produitPromo == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "NomCategorie", produitPromo.CategorieId);
            ViewData["MagasinId"] = new SelectList(_context.Magasin, "Id", "NomParVille", produitPromo.MagasinId);
            return View(produitPromo);
        }

        // POST: ProduitPromoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProduit,MagasinId,CategorieId")] ProduitPromo produitPromo)
        {
            if (id != produitPromo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produitPromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitPromoExists(produitPromo.Id))
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
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "NomCategorie", produitPromo.CategorieId);
            ViewData["MagasinId"] = new SelectList(_context.Magasin, "Id", "NomParVille", produitPromo.MagasinId);
            return View(produitPromo);
        }

        // GET: ProduitPromoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProduitPromo == null)
            {
                return NotFound();
            }

            var produitPromo = await _context.ProduitPromo
                .Include(p => p.Categories)
                .Include(p => p.Magasins)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitPromo == null)
            {
                return NotFound();
            }

            return View(produitPromo);
        }

        // POST: ProduitPromoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProduitPromo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProduitPromo'  is null.");
            }
            var produitPromo = await _context.ProduitPromo.FindAsync(id);
            if (produitPromo != null)
            {
                _context.ProduitPromo.Remove(produitPromo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitPromoExists(int id)
        {
          return _context.ProduitPromo.Any(e => e.Id == id);
        }
    }
}
