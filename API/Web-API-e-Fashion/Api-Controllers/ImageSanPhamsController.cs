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
    public class ImageSanPhamsController : ControllerBase
    {
        private readonly DPContext _context;

        public ImageSanPhamsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/ImageSanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageSanPham>>> GetimageSanPhams()
        {
            return await _context.imageSanPhams.ToListAsync();
        }

        // GET: api/ImageSanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ImageSanPham>>> GetImageSanPham(int id)
        {
            List<ImageSanPham> imageSanPham = new List<ImageSanPham>();

            imageSanPham = await _context.imageSanPhams.Where(s => s.SanPhamId == id).ToListAsync();

            if (imageSanPham == null)
            {
                return NotFound();
            }

            return  imageSanPham;
        }

        // PUT: api/ImageSanPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageSanPham(int id, ImageSanPham imageSanPham)
        {
            if (id != imageSanPham.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageSanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageSanPhamExists(id))
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

        // POST: api/ImageSanPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageSanPham>> PostImageSanPham(ImageSanPham imageSanPham)
        {
            _context.imageSanPhams.Add(imageSanPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageSanPham", new { id = imageSanPham.Id }, imageSanPham);
        }

        // DELETE: api/ImageSanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageSanPham(int id)
        {
            var imageSanPham = await _context.imageSanPhams.FindAsync(id);
            if (imageSanPham == null)
            {
                return NotFound();
            }

            _context.imageSanPhams.Remove(imageSanPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageSanPhamExists(int id)
        {
            return _context.imageSanPhams.Any(e => e.Id == id);
        }
    }
}
