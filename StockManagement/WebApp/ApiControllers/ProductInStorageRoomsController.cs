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
    public class ProductInStorageRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductInStorageRoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductInStorageRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInStorageRoom>>> GetProductInStorageRooms()
        {
            return await _context.ProductInStorageRooms.ToListAsync();
        }

        // GET: api/ProductInStorageRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInStorageRoom>> GetProductInStorageRoom(Guid id)
        {
            var productInStorageRoom = await _context.ProductInStorageRooms.FindAsync(id);

            if (productInStorageRoom == null)
            {
                return NotFound();
            }

            return productInStorageRoom;
        }

        // PUT: api/ProductInStorageRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInStorageRoom(Guid id, ProductInStorageRoom productInStorageRoom)
        {
            if (id != productInStorageRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(productInStorageRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInStorageRoomExists(id))
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

        // POST: api/ProductInStorageRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductInStorageRoom>> PostProductInStorageRoom(ProductInStorageRoom productInStorageRoom)
        {
            _context.ProductInStorageRooms.Add(productInStorageRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInStorageRoom", new { id = productInStorageRoom.Id }, productInStorageRoom);
        }

        // DELETE: api/ProductInStorageRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInStorageRoom(Guid id)
        {
            var productInStorageRoom = await _context.ProductInStorageRooms.FindAsync(id);
            if (productInStorageRoom == null)
            {
                return NotFound();
            }

            _context.ProductInStorageRooms.Remove(productInStorageRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductInStorageRoomExists(Guid id)
        {
            return _context.ProductInStorageRooms.Any(e => e.Id == id);
        }
    }
}
