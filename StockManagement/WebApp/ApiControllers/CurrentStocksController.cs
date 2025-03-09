using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentStocksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurrentStocksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrentStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentStock>>> GetCurrentStocks()
        {
            return await _context.CurrentStocks.ToListAsync();
        }

        // GET: api/CurrentStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentStock>> GetCurrentStock(Guid id)
        {
            var currentStock = await _context.CurrentStocks.FindAsync(id);

            if (currentStock == null)
            {
                return NotFound();
            }

            return currentStock;
        }

        // PUT: api/CurrentStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentStock(Guid id, CurrentStock currentStock)
        {
            if (id != currentStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(currentStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentStockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CurrentStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CurrentStock>> PostCurrentStock(CurrentStock currentStock)
        {
            _context.CurrentStocks.Add(currentStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrentStock", new { id = currentStock.Id }, currentStock);
        }

        // DELETE: api/CurrentStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrentStock(Guid id)
        {
            var currentStock = await _context.CurrentStocks.FindAsync(id);
            if (currentStock == null)
            {
                return NotFound();
            }

            _context.CurrentStocks.Remove(currentStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrentStockExists(Guid id)
        {
            return _context.CurrentStocks.Any(e => e.Id == id);
        }
    }
}
