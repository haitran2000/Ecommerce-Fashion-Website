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
    public class MauSacsController : ControllerBase
    {
        private readonly DPContext _context;

        public MauSacsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/MauSacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauSac>>> GetMauSacs()
        {
            return await _context.MauSacs.ToListAsync();
        }

        // GET: api/MauSacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauSac>> GetMauSac(int id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);

            if (mauSac == null)
            {
                return NotFound();
            }

            return mauSac;
        }

        // PUT: api/MauSacs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMauSac(int id, MauSac mauSac)
        {
            if (id != mauSac.Id)
            {
                return BadRequest();
            }

            _context.Entry(mauSac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauSacExists(id))
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

        // POST: api/MauSacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MauSac>> PostMauSac(MauSac mauSac)
        {
            _context.MauSacs.Add(mauSac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMauSac", new { id = mauSac.Id }, mauSac);
        }

        // DELETE: api/MauSacs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMauSac(int id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);
            if (mauSac == null)
            {
                return NotFound();
            }

            _context.MauSacs.Remove(mauSac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MauSacExists(int id)
        {
            return _context.MauSacs.Any(e => e.Id == id);
        }
    }
}
