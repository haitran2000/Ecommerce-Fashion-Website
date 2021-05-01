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
    public class SanPhamThietKesController : ControllerBase
    {
        private readonly DPContext _context;
        public SanPhamThietKesController(DPContext context)
        {
            _context = context;
        }
        // GET: api/SanPhamThietKes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamThietKe>>> GetSanPhamThietKes()
        {
            return await _context.SanPhamThietKes.ToListAsync();
        }

        // GET: api/SanPhamThietKes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamThietKe>> GetSanPhamThietKe(int id)
        {
            var sanPhamThietKe = await _context.SanPhamThietKes.FindAsync(id);

            if (sanPhamThietKe == null)
            {
                return NotFound();
            }

            return sanPhamThietKe;
        }

        // PUT: api/SanPhamThietKes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamThietKe(int id, SanPhamThietKe sanPhamThietKe)
        {
            if (id != sanPhamThietKe.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanPhamThietKe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamThietKeExists(id))
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

        // POST: api/SanPhamThietKes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPhamThietKe>> PostSanPhamThietKe(SanPhamThietKe sanPhamThietKe)
        {
            _context.SanPhamThietKes.Add(sanPhamThietKe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanPhamThietKe", new { id = sanPhamThietKe.Id }, sanPhamThietKe);
        }

        // DELETE: api/SanPhamThietKes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPhamThietKe(int id)
        {
            var sanPhamThietKe = await _context.SanPhamThietKes.FindAsync(id);
            if (sanPhamThietKe == null)
            {
                return NotFound();
            }
            _context.SanPhamThietKes.Remove(sanPhamThietKe);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SanPhamThietKeExists(int id)
        {
            return _context.SanPhamThietKes.Any(e => e.Id == id);
        }
    }
}
