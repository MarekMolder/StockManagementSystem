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
    public class ActionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionEntity>>> GetActions()
        {
            return await _context.Actions.ToListAsync();
        }

        // GET: api/Actions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActionEntity>> GetActionEntity(Guid id)
        {
            var actionEntity = await _context.Actions.FindAsync(id);

            if (actionEntity == null)
            {
                return NotFound();
            }

            return actionEntity;
        }

        // PUT: api/Actions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActionEntity(Guid id, ActionEntity actionEntity)
        {
            if (id != actionEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(actionEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionEntityExists(id))
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

        // POST: api/Actions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActionEntity>> PostActionEntity(ActionEntity actionEntity)
        {
            _context.Actions.Add(actionEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActionEntity", new { id = actionEntity.Id }, actionEntity);
        }

        // DELETE: api/Actions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActionEntity(Guid id)
        {
            var actionEntity = await _context.Actions.FindAsync(id);
            if (actionEntity == null)
            {
                return NotFound();
            }

            _context.Actions.Remove(actionEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActionEntityExists(Guid id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }
    }
}
