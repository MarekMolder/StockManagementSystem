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
    public class ApprovalRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApprovalRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ApprovalRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalRequests>>> GetApprovalRequests()
        {
            return await _context.ApprovalRequests.ToListAsync();
        }

        // GET: api/ApprovalRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApprovalRequests>> GetApprovalRequests(Guid id)
        {
            var approvalRequests = await _context.ApprovalRequests.FindAsync(id);

            if (approvalRequests == null)
            {
                return NotFound();
            }

            return approvalRequests;
        }

        // PUT: api/ApprovalRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApprovalRequests(Guid id, ApprovalRequests approvalRequests)
        {
            if (id != approvalRequests.Id)
            {
                return BadRequest();
            }

            _context.Entry(approvalRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalRequestsExists(id))
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

        // POST: api/ApprovalRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApprovalRequests>> PostApprovalRequests(ApprovalRequests approvalRequests)
        {
            _context.ApprovalRequests.Add(approvalRequests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApprovalRequests", new { id = approvalRequests.Id }, approvalRequests);
        }

        // DELETE: api/ApprovalRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApprovalRequests(Guid id)
        {
            var approvalRequests = await _context.ApprovalRequests.FindAsync(id);
            if (approvalRequests == null)
            {
                return NotFound();
            }

            _context.ApprovalRequests.Remove(approvalRequests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApprovalRequestsExists(Guid id)
        {
            return _context.ApprovalRequests.Any(e => e.Id == id);
        }
    }
}
