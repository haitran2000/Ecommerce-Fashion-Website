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
    public class GiaSanPhamsController : ControllerBase
    {
        private readonly DPContext _context;

        public GiaSanPhamsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/GiaSanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiaSanPham>>> GetGiaSanPhams()
        {
            return await _context.GiaSanPhams.ToListAsync();
        }

        // GET: api/GiaSanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiaSanPham>> GetGiaSanPham(int id)
        {
            var giaSanPham = await _context.GiaSanPhams.FindAsync(id);

            if (giaSanPham == null)
            {
                return NotFound();
            }

            return giaSanPham;
        }

        // PUT: api/GiaSanPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiaSanPham(int id, GiaSanPham giaSanPham)
        {
            if (id != giaSanPham.Id)
            {
                return BadRequest();
            }

            _context.Entry(giaSanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaSanPhamExists(id))
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

        // POST: api/GiaSanPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiaSanPham>> PostGiaSanPham(GiaSanPham giaSanPham)
        {
            _context.GiaSanPhams.Add(giaSanPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiaSanPham", new { id = giaSanPham.Id }, giaSanPham);
        }

        // DELETE: api/GiaSanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaSanPham(int id)
        {
            var giaSanPham = await _context.GiaSanPhams.FindAsync(id);
            if (giaSanPham == null)
            {
                return NotFound();
            }

            _context.GiaSanPhams.Remove(giaSanPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaSanPhamExists(int id)
        {
            return _context.GiaSanPhams.Any(e => e.Id == id);
        }
    }
}
