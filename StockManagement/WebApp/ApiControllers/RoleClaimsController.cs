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
    public class RoleClaimsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoleClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RoleClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleClaim>>> GetRoleClaims()
        {
            return await _context.RoleClaims.ToListAsync();
        }

        // GET: api/RoleClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleClaim>> GetRoleClaim(Guid id)
        {
            var roleClaim = await _context.RoleClaims.FindAsync(id);

            if (roleClaim == null)
            {
                return NotFound();
            }

            return roleClaim;
        }

        // PUT: api/RoleClaims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleClaim(Guid id, RoleClaim roleClaim)
        {
            if (id != roleClaim.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleClaimExists(id))
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

        // POST: api/RoleClaims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleClaim>> PostRoleClaim(RoleClaim roleClaim)
        {
            _context.RoleClaims.Add(roleClaim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleClaim", new { id = roleClaim.Id }, roleClaim);
        }

        // DELETE: api/RoleClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleClaim(Guid id)
        {
            var roleClaim = await _context.RoleClaims.FindAsync(id);
            if (roleClaim == null)
            {
                return NotFound();
            }

            _context.RoleClaims.Remove(roleClaim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleClaimExists(Guid id)
        {
            return _context.RoleClaims.Any(e => e.Id == id);
        }
    }
}
