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
    public class ReasonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reason>>> GetReasons()
        {
            return await _context.Reasons.ToListAsync();
        }

        // GET: api/Reasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reason>> GetReason(Guid id)
        {
            var reason = await _context.Reasons.FindAsync(id);

            if (reason == null)
            {
                return NotFound();
            }

            return reason;
        }

        // PUT: api/Reasons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReason(Guid id, Reason reason)
        {
            if (id != reason.Id)
            {
                return BadRequest();
            }

            _context.Entry(reason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReasonExists(id))
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

        // POST: api/Reasons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reason>> PostReason(Reason reason)
        {
            _context.Reasons.Add(reason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReason", new { id = reason.Id }, reason);
        }

        // DELETE: api/Reasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReason(Guid id)
        {
            var reason = await _context.Reasons.FindAsync(id);
            if (reason == null)
            {
                return NotFound();
            }

            _context.Reasons.Remove(reason);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReasonExists(Guid id)
        {
            return _context.Reasons.Any(e => e.Id == id);
        }
    }
}
