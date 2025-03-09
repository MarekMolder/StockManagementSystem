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
    public class StockAuditsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockAuditsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StockAudits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockAudit>>> GetStockAudits()
        {
            return await _context.StockAudits.ToListAsync();
        }

        // GET: api/StockAudits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockAudit>> GetStockAudit(Guid id)
        {
            var stockAudit = await _context.StockAudits.FindAsync(id);

            if (stockAudit == null)
            {
                return NotFound();
            }

            return stockAudit;
        }

        // PUT: api/StockAudits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockAudit(Guid id, StockAudit stockAudit)
        {
            if (id != stockAudit.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockAuditExists(id))
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

        // POST: api/StockAudits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockAudit>> PostStockAudit(StockAudit stockAudit)
        {
            _context.StockAudits.Add(stockAudit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockAudit", new { id = stockAudit.Id }, stockAudit);
        }

        // DELETE: api/StockAudits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockAudit(Guid id)
        {
            var stockAudit = await _context.StockAudits.FindAsync(id);
            if (stockAudit == null)
            {
                return NotFound();
            }

            _context.StockAudits.Remove(stockAudit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockAuditExists(Guid id)
        {
            return _context.StockAudits.Any(e => e.Id == id);
        }
    }
}
