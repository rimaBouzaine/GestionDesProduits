﻿using System;
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
    public class StocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stock.Include(s => s.ProduitPromo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.ProduitPromo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "Id");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NbrProduit,DescriptionStock,ProduitPromoId")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "Id", stock.ProduitPromoId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "Id", stock.ProduitPromoId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NbrProduit,DescriptionStock,ProduitPromoId")] Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Id))
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
            ViewData["ProduitPromoId"] = new SelectList(_context.ProduitPromo, "Id", "Id", stock.ProduitPromoId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.ProduitPromo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stock == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stock'  is null.");
            }
            var stock = await _context.Stock.FindAsync(id);
            if (stock != null)
            {
                _context.Stock.Remove(stock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
          return _context.Stock.Any(e => e.Id == id);
        }
    }
}
