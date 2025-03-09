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
    public class RoleClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public RoleClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RoleClaims
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoleClaims.ToListAsync());
        }

        // GET: RoleClaims/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClaim = await _context.RoleClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleClaim == null)
            {
                return NotFound();
            }

            return View(roleClaim);
        }

        // GET: RoleClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment")] RoleClaim roleClaim)
        {
            if (ModelState.IsValid)
            {
                roleClaim.Id = Guid.NewGuid();
                _context.Add(roleClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleClaim);
        }

        // GET: RoleClaims/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClaim = await _context.RoleClaims.FindAsync(id);
            if (roleClaim == null)
            {
                return NotFound();
            }
            return View(roleClaim);
        }

        // POST: RoleClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Comment")] RoleClaim roleClaim)
        {
            if (id != roleClaim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleClaim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleClaimExists(roleClaim.Id))
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
            return View(roleClaim);
        }

        // GET: RoleClaims/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleClaim = await _context.RoleClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleClaim == null)
            {
                return NotFound();
            }

            return View(roleClaim);
        }

        // POST: RoleClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roleClaim = await _context.RoleClaims.FindAsync(id);
            if (roleClaim != null)
            {
                _context.RoleClaims.Remove(roleClaim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleClaimExists(Guid id)
        {
            return _context.RoleClaims.Any(e => e.Id == id);
        }
    }
}
