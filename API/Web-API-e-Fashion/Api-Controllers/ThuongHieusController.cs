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
    public class ThuongHieusController : ControllerBase
    {
        private readonly DPContext _context;

        public ThuongHieusController(DPContext context)
        {
            _context = context;
        }

        // GET: api/ThuongHieus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuongHieu>>> GetThuongHieus()
        {
            return await _context.ThuongHieus.ToListAsync();
        }

        // GET: api/ThuongHieus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuongHieu>> GetThuongHieu(int id)
        {
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);

            if (thuongHieu == null)
            {
                return NotFound();
            }

            return thuongHieu;
        }

        // PUT: api/ThuongHieus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuongHieu(int id, ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(thuongHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(id))
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

        // POST: api/ThuongHieus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThuongHieu>> PostThuongHieu(ThuongHieu thuongHieu)
        {
            _context.ThuongHieus.Add(thuongHieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuongHieu", new { id = thuongHieu.Id }, thuongHieu);
        }

        // DELETE: api/ThuongHieus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuongHieu(int id)
        {
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            _context.ThuongHieus.Remove(thuongHieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieus.Any(e => e.Id == id);
        }
    }
}
