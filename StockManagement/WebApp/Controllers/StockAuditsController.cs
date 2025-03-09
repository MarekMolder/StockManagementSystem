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
    public class StockAuditsController : Controller
    {
        private readonly AppDbContext _context;

        public StockAuditsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockAudits
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StockAudits.Include(s => s.StorageRoom);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StockAudits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAudit = await _context.StockAudits
                .Include(s => s.StorageRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockAudit == null)
            {
                return NotFound();
            }

            return View(stockAudit);
        }

        // GET: StockAudits/Create
        public IActionResult Create()
        {
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location");
            return View();
        }

        // POST: StockAudits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreatedAt,StorageRoomId,UserId,Id,Comment")] StockAudit stockAudit)
        {
            if (ModelState.IsValid)
            {
                stockAudit.Id = Guid.NewGuid();
                _context.Add(stockAudit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockAudit.StorageRoomId);
            return View(stockAudit);
        }

        // GET: StockAudits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAudit = await _context.StockAudits.FindAsync(id);
            if (stockAudit == null)
            {
                return NotFound();
            }
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockAudit.StorageRoomId);
            return View(stockAudit);
        }

        // POST: StockAudits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CreatedAt,StorageRoomId,UserId,Id,Comment")] StockAudit stockAudit)
        {
            if (id != stockAudit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockAudit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockAuditExists(stockAudit.Id))
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
            ViewData["StorageRoomId"] = new SelectList(_context.StorageRooms, "Id", "Location", stockAudit.StorageRoomId);
            return View(stockAudit);
        }

        // GET: StockAudits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAudit = await _context.StockAudits
                .Include(s => s.StorageRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockAudit == null)
            {
                return NotFound();
            }

            return View(stockAudit);
        }

        // POST: StockAudits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var stockAudit = await _context.StockAudits.FindAsync(id);
            if (stockAudit != null)
            {
                _context.StockAudits.Remove(stockAudit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockAuditExists(Guid id)
        {
            return _context.StockAudits.Any(e => e.Id == id);
        }
    }
}
