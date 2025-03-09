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
    public class ProductInStorageRoomsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductInStorageRoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductInStorageRooms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductInStorageRooms.Include(p => p.Action).Include(p => p.Product).Include(p => p.StockMovement).Include(p => p.StorageRoom).Include(p => p.Supplier);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductInStorageRooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInStorageRoom = await _context.ProductInStorageRooms
                .Include(p => p.Action)
                .Include(p => p.Product)
                .Include(p => p.StockMovement)
                .Include(p => p.StorageRoom)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInStorageRoom == null)
            {
                return NotFound();
            }

            return View(productInStorageRoom);
        }

        // GET: ProductInStorageRooms/Create
        public IActionResult Create()
        {
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["StockMovementId"] = new SelectList(_context.StockMovements, "Id", "Id");
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: ProductInStorageRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Quantity,ManufacturingDate,ExpiryDate,CreatedAt,ActionId,ProductId,SupplierId,StockMovementId,StorageRoomId,Id,Comment")] ProductInStorageRoom productInStorageRoom)
        {
            if (ModelState.IsValid)
            {
                productInStorageRoom.Id = Guid.NewGuid();
                _context.Add(productInStorageRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", productInStorageRoom.ActionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productInStorageRoom.ProductId);
            ViewData["StockMovementId"] = new SelectList(_context.StockMovements, "Id", "Id", productInStorageRoom.StockMovementId);
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Name", productInStorageRoom.StorageRoomId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", productInStorageRoom.SupplierId);
            return View(productInStorageRoom);
        }

        // GET: ProductInStorageRooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInStorageRoom = await _context.ProductInStorageRooms.FindAsync(id);
            if (productInStorageRoom == null)
            {
                return NotFound();
            }
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", productInStorageRoom.ActionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productInStorageRoom.ProductId);
            ViewData["StockMovementId"] = new SelectList(_context.StockMovements, "Id", "Id", productInStorageRoom.StockMovementId);
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Name", productInStorageRoom.StorageRoomId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", productInStorageRoom.SupplierId);
            return View(productInStorageRoom);
        }

        // POST: ProductInStorageRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Code,Quantity,ManufacturingDate,ExpiryDate,CreatedAt,ActionId,ProductId,SupplierId,StockMovementId,StorageRoomId,Id,Comment")] ProductInStorageRoom productInStorageRoom)
        {
            if (id != productInStorageRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInStorageRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInStorageRoomExists(productInStorageRoom.Id))
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
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", productInStorageRoom.ActionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productInStorageRoom.ProductId);
            ViewData["StockMovementId"] = new SelectList(_context.StockMovements, "Id", "Id", productInStorageRoom.StockMovementId);
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Name", productInStorageRoom.StorageRoomId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", productInStorageRoom.SupplierId);
            return View(productInStorageRoom);
        }

        // GET: ProductInStorageRooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInStorageRoom = await _context.ProductInStorageRooms
                .Include(p => p.Action)
                .Include(p => p.Product)
                .Include(p => p.StockMovement)
                .Include(p => p.StorageRoom)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInStorageRoom == null)
            {
                return NotFound();
            }

            return View(productInStorageRoom);
        }

        // POST: ProductInStorageRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productInStorageRoom = await _context.ProductInStorageRooms.FindAsync(id);
            if (productInStorageRoom != null)
            {
                _context.ProductInStorageRooms.Remove(productInStorageRoom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInStorageRoomExists(Guid id)
        {
            return _context.ProductInStorageRooms.Any(e => e.Id == id);
        }
    }
}
