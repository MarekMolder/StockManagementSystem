using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Controllers
{
    public class StockMovementsController : Controller
    {
        private readonly AppDbContext _context;

        public StockMovementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockMovements
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StockMovements.Include(s => s.FromInventory).Include(s => s.FromStorageRoom).Include(s => s.Product).Include(s => s.ToInventory).Include(s => s.ToStorageRoom);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StockMovements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements
                .Include(s => s.FromInventory)
                .Include(s => s.FromStorageRoom)
                .Include(s => s.Product)
                .Include(s => s.ToInventory)
                .Include(s => s.ToStorageRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockMovement == null)
            {
                return NotFound();
            }

            return View(stockMovement);
        }

        // GET: StockMovements/Create
        public IActionResult Create()
        {
            ViewData["FromInventoryId"] = new SelectList(_context.Inventories, "Id", "Name");
            ViewData["FromStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Code");
            ViewData["ToInventoryId"] = new SelectList(_context.Inventories, "Id", "Name");
            ViewData["ToStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location");
            return View();
        }

        // POST: StockMovements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,CreatedAt,ProductId,FromStorageRoomId,ToStorageRoomId,FromInventoryId,ToInventoryId,Id,Comment")] StockMovement stockMovement)
        {
            if (ModelState.IsValid)
            {
                stockMovement.Id = Guid.NewGuid();
                _context.Add(stockMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.FromInventoryId);
            ViewData["FromStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.FromStorageRoomId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Code", stockMovement.ProductId);
            ViewData["ToInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.ToInventoryId);
            ViewData["ToStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.ToStorageRoomId);
            return View(stockMovement);
        }

        // GET: StockMovements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements.FindAsync(id);
            if (stockMovement == null)
            {
                return NotFound();
            }
            ViewData["FromInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.FromInventoryId);
            ViewData["FromStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.FromStorageRoomId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Code", stockMovement.ProductId);
            ViewData["ToInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.ToInventoryId);
            ViewData["ToStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.ToStorageRoomId);
            return View(stockMovement);
        }

        // POST: StockMovements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,CreatedAt,ProductId,FromStorageRoomId,ToStorageRoomId,FromInventoryId,ToInventoryId,Id,Comment")] StockMovement stockMovement)
        {
            if (id != stockMovement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockMovementExists(stockMovement.Id))
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
            ViewData["FromInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.FromInventoryId);
            ViewData["FromStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.FromStorageRoomId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Code", stockMovement.ProductId);
            ViewData["ToInventoryId"] = new SelectList(_context.Inventories, "Id", "Name", stockMovement.ToInventoryId);
            ViewData["ToStorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockMovement.ToStorageRoomId);
            return View(stockMovement);
        }

        // GET: StockMovements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements
                .Include(s => s.FromInventory)
                .Include(s => s.FromStorageRoom)
                .Include(s => s.Product)
                .Include(s => s.ToInventory)
                .Include(s => s.ToStorageRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockMovement == null)
            {
                return NotFound();
            }

            return View(stockMovement);
        }

        // POST: StockMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var stockMovement = await _context.StockMovements.FindAsync(id);
            if (stockMovement != null)
            {
                _context.StockMovements.Remove(stockMovement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockMovementExists(Guid id)
        {
            return _context.StockMovements.Any(e => e.Id == id);
        }
    }
}
