using FactoryAPI.Data;
using FactoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections;

namespace FactoryAPI.Controllers
{
    //item controller providing us with responses to various requests - as well as responses in case the request could not be finished
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemDbContext _context;
        public ItemController(ItemDbContext context) => _context = context;


        // Create a new item
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(Item item) {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id=item.Id}, item);
        }

        // Retrieve a single item
        [HttpGet("id")]
        [ProducesResponseType(typeof(Item), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        // Retrieve all items (only if you'll be using an ORM framework)
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll() => await _context.Items.ToListAsync();

        // Update an existing item
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, Item item) {
            if (id != item.Id) return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // Delete an item
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete=await _context.Items.FindAsync(id);
            if (itemToDelete == null) return NotFound();
            _context.Items.Remove(itemToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
