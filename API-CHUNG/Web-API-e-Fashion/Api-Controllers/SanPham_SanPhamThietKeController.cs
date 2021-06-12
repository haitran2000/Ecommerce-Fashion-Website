using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPham_SanPhamThietKeController : ControllerBase
    {
        private readonly DPContext _context;

        public SanPham_SanPhamThietKeController(DPContext context)
        {
            _context = context;
        }
        // GET: api/SanPham_SanPhamThietKe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham_SanPhamThietKe>>> GetSanPham_SanPhamThietKe()
        {
            return await _context.SanPham_SanPhamThietKe.ToListAsync();
        }

        // GET: api/SanPham_SanPhamThietKe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham_SanPhamThietKe>> GetSanPham_SanPhamThietKe(int id)
        {
            var sanPham_SanPhamThietKe = await _context.SanPham_SanPhamThietKe.FindAsync(id);

            if (sanPham_SanPhamThietKe == null)
            {
                return NotFound();
            }

            return sanPham_SanPhamThietKe;
        }

        // PUT: api/SanPham_SanPhamThietKe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham_SanPhamThietKe(int id, SanPham_SanPhamThietKe sanPham_SanPhamThietKe)
        {
            if (id != sanPham_SanPhamThietKe.SanPhamId)
            {
                return BadRequest();
            }

            _context.Entry(sanPham_SanPhamThietKe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPham_SanPhamThietKeExists(id))
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

        // POST: api/SanPham_SanPhamThietKe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPham_SanPhamThietKe>> PostSanPham_SanPhamThietKe(SanPham_SanPhamThietKe sanPham_SanPhamThietKe)
        {
            _context.SanPham_SanPhamThietKe.Add(sanPham_SanPhamThietKe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SanPham_SanPhamThietKeExists(sanPham_SanPhamThietKe.SanPhamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSanPham_SanPhamThietKe", new { id = sanPham_SanPhamThietKe.SanPhamId }, sanPham_SanPhamThietKe);
        }

        // DELETE: api/SanPham_SanPhamThietKe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham_SanPhamThietKe(int id)
        {
            var sanPham_SanPhamThietKe = await _context.SanPham_SanPhamThietKe.FindAsync(id);
            if (sanPham_SanPhamThietKe == null)
            {
                return NotFound();
            }

            _context.SanPham_SanPhamThietKe.Remove(sanPham_SanPhamThietKe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanPham_SanPhamThietKeExists(int id)
        {
            return _context.SanPham_SanPhamThietKe.Any(e => e.SanPhamId == id);
        }
    }
}
