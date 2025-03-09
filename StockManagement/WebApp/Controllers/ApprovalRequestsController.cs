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
    public class ApprovalRequestsController : Controller
    {
        private readonly AppDbContext _context;

        public ApprovalRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ApprovalRequests
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ApprovalRequests.Include(a => a.Action);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ApprovalRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequests = await _context.ApprovalRequests
                .Include(a => a.Action)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvalRequests == null)
            {
                return NotFound();
            }

            return View(approvalRequests);
        }

        // GET: ApprovalRequests/Create
        public IActionResult Create()
        {
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status");
            return View();
        }

        // POST: ApprovalRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Status,CreatedAt,ApprovedAt,ActionId,RequestedByUserId,ApprovedByUserId,Id,Comment")] ApprovalRequests approvalRequests)
        {
            if (ModelState.IsValid)
            {
                approvalRequests.Id = Guid.NewGuid();
                _context.Add(approvalRequests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", approvalRequests.ActionId);
            return View(approvalRequests);
        }

        // GET: ApprovalRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequests = await _context.ApprovalRequests.FindAsync(id);
            if (approvalRequests == null)
            {
                return NotFound();
            }
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", approvalRequests.ActionId);
            return View(approvalRequests);
        }

        // POST: ApprovalRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Status,CreatedAt,ApprovedAt,ActionId,RequestedByUserId,ApprovedByUserId,Id,Comment")] ApprovalRequests approvalRequests)
        {
            if (id != approvalRequests.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvalRequests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalRequestsExists(approvalRequests.Id))
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
            ViewData["ActionId"] = new SelectList(_context.Actions, "Id", "Status", approvalRequests.ActionId);
            return View(approvalRequests);
        }

        // GET: ApprovalRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequests = await _context.ApprovalRequests
                .Include(a => a.Action)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvalRequests == null)
            {
                return NotFound();
            }

            return View(approvalRequests);
        }

        // POST: ApprovalRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var approvalRequests = await _context.ApprovalRequests.FindAsync(id);
            if (approvalRequests != null)
            {
                _context.ApprovalRequests.Remove(approvalRequests);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalRequestsExists(Guid id)
        {
            return _context.ApprovalRequests.Any(e => e.Id == id);
        }
    }
}
