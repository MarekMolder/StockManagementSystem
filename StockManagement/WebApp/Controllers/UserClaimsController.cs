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
    public class UserClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public UserClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserClaims
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserClaims.ToListAsync());
        }

        // GET: UserClaims/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClaim = await _context.UserClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userClaim == null)
            {
                return NotFound();
            }

            return View(userClaim);
        }

        // GET: UserClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment")] UserClaim userClaim)
        {
            if (ModelState.IsValid)
            {
                userClaim.Id = Guid.NewGuid();
                _context.Add(userClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userClaim);
        }

        // GET: UserClaims/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClaim = await _context.UserClaims.FindAsync(id);
            if (userClaim == null)
            {
                return NotFound();
            }
            return View(userClaim);
        }

        // POST: UserClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Comment")] UserClaim userClaim)
        {
            if (id != userClaim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userClaim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserClaimExists(userClaim.Id))
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
            return View(userClaim);
        }

        // GET: UserClaims/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClaim = await _context.UserClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userClaim == null)
            {
                return NotFound();
            }

            return View(userClaim);
        }

        // POST: UserClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userClaim = await _context.UserClaims.FindAsync(id);
            if (userClaim != null)
            {
                _context.UserClaims.Remove(userClaim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserClaimExists(Guid id)
        {
            return _context.UserClaims.Any(e => e.Id == id);
        }
    }
}
