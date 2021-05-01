using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Item_SanPhamThietKeController : ControllerBase
    {
        private readonly DPContext _context;

        public Item_SanPhamThietKeController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Item_SanPhamThietKe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item_SanPhamThietKe>>> GetItem_SanPhamThietKe()
        {
            return await _context.Item_SanPhamThietKe.ToListAsync();
        }

        // GET: api/Item_SanPhamThietKe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item_SanPhamThietKe>> GetItem_SanPhamThietKe(int id)
        {
            var item_SanPhamThietKe = await _context.Item_SanPhamThietKe.FindAsync(id);

            if (item_SanPhamThietKe == null)
            {
                return NotFound();
            }

            return item_SanPhamThietKe;
        }

        // PUT: api/Item_SanPhamThietKe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem_SanPhamThietKe(int id, Item_SanPhamThietKe item_SanPhamThietKe)
        {
            if (id != item_SanPhamThietKe.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item_SanPhamThietKe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Item_SanPhamThietKeExists(id))
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

        // POST: api/Item_SanPhamThietKe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item_SanPhamThietKe>> PostItem_SanPhamThietKe(Item_SanPhamThietKe item_SanPhamThietKe)
        {
            _context.Item_SanPhamThietKe.Add(item_SanPhamThietKe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Item_SanPhamThietKeExists(item_SanPhamThietKe.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItem_SanPhamThietKe", new { id = item_SanPhamThietKe.ItemId }, item_SanPhamThietKe);
        }

        // DELETE: api/Item_SanPhamThietKe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem_SanPhamThietKe(int id)
        {
            var item_SanPhamThietKe = await _context.Item_SanPhamThietKe.FindAsync(id);
            if (item_SanPhamThietKe == null)
            {
                return NotFound();
            }

            _context.Item_SanPhamThietKe.Remove(item_SanPhamThietKe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Item_SanPhamThietKeExists(int id)
        {
            return _context.Item_SanPhamThietKe.Any(e => e.ItemId == id);
        }
    }
}
