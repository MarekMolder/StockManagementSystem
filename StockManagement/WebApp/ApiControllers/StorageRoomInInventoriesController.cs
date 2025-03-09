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
    public class StorageRoomInInventoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StorageRoomInInventoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StorageRoomInInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageRoomInInventory>>> GetStorageRoomInInventories()
        {
            return await _context.StorageRoomInInventories.ToListAsync();
        }

        // GET: api/StorageRoomInInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageRoomInInventory>> GetStorageRoomInInventory(Guid id)
        {
            var storageRoomInInventory = await _context.StorageRoomInInventories.FindAsync(id);

            if (storageRoomInInventory == null)
            {
                return NotFound();
            }

            return storageRoomInInventory;
        }

        // PUT: api/StorageRoomInInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageRoomInInventory(Guid id, StorageRoomInInventory storageRoomInInventory)
        {
            if (id != storageRoomInInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(storageRoomInInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageRoomInInventoryExists(id))
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

        // POST: api/StorageRoomInInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StorageRoomInInventory>> PostStorageRoomInInventory(StorageRoomInInventory storageRoomInInventory)
        {
            _context.StorageRoomInInventories.Add(storageRoomInInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageRoomInInventory", new { id = storageRoomInInventory.Id }, storageRoomInInventory);
        }

        // DELETE: api/StorageRoomInInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageRoomInInventory(Guid id)
        {
            var storageRoomInInventory = await _context.StorageRoomInInventories.FindAsync(id);
            if (storageRoomInInventory == null)
            {
                return NotFound();
            }

            _context.StorageRoomInInventories.Remove(storageRoomInInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageRoomInInventoryExists(Guid id)
        {
            return _context.StorageRoomInInventories.Any(e => e.Id == id);
        }
    }
}
