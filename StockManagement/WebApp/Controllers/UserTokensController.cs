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
    public class UserTokensController : Controller
    {
        private readonly AppDbContext _context;

        public UserTokensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserTokens
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTokens.ToListAsync());
        }

        // GET: UserTokens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToken = await _context.UserTokens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userToken == null)
            {
                return NotFound();
            }

            return View(userToken);
        }

        // GET: UserTokens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTokens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment")] UserToken userToken)
        {
            if (ModelState.IsValid)
            {
                userToken.Id = Guid.NewGuid();
                _context.Add(userToken);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userToken);
        }

        // GET: UserTokens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToken = await _context.UserTokens.FindAsync(id);
            if (userToken == null)
            {
                return NotFound();
            }
            return View(userToken);
        }

        // POST: UserTokens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Comment")] UserToken userToken)
        {
            if (id != userToken.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userToken);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTokenExists(userToken.Id))
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
            return View(userToken);
        }

        // GET: UserTokens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToken = await _context.UserTokens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userToken == null)
            {
                return NotFound();
            }

            return View(userToken);
        }

        // POST: UserTokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userToken = await _context.UserTokens.FindAsync(id);
            if (userToken != null)
            {
                _context.UserTokens.Remove(userToken);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTokenExists(Guid id)
        {
            return _context.UserTokens.Any(e => e.Id == id);
        }
    }
}
