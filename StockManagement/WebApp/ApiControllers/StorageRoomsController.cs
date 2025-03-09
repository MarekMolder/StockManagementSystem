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
    public class StorageRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StorageRoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StorageRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageRoom>>> GetStorageRooms()
        {
            return await _context.StorageRooms.ToListAsync();
        }

        // GET: api/StorageRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageRoom>> GetStorageRoom(Guid id)
        {
            var storageRoom = await _context.StorageRooms.FindAsync(id);

            if (storageRoom == null)
            {
                return NotFound();
            }

            return storageRoom;
        }

        // PUT: api/StorageRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageRoom(Guid id, StorageRoom storageRoom)
        {
            if (id != storageRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(storageRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageRoomExists(id))
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

        // POST: api/StorageRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StorageRoom>> PostStorageRoom(StorageRoom storageRoom)
        {
            _context.StorageRooms.Add(storageRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageRoom", new { id = storageRoom.Id }, storageRoom);
        }

        // DELETE: api/StorageRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageRoom(Guid id)
        {
            var storageRoom = await _context.StorageRooms.FindAsync(id);
            if (storageRoom == null)
            {
                return NotFound();
            }

            _context.StorageRooms.Remove(storageRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageRoomExists(Guid id)
        {
            return _context.StorageRooms.Any(e => e.Id == id);
        }
    }
}
