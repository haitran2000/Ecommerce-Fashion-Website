using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.UploadFileModels;

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

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuongHieu>>> GetBrands()
        {
            return await _context.ThuongHieus.ToListAsync();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuongHieu>> GetBrand(int id)
        {
            var brand = await _context.ThuongHieus.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, [FromForm] UploadBrand upload)
        {
            ThuongHieu brand = new ThuongHieu();
            brand = await _context.ThuongHieus.FirstOrDefaultAsync(s=>s.Id==id);
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "brand");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                brand.ImagePath = fullPath;
                brand.Ten = upload.Name;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                brand.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                brand.ImagePath = "noimage.jpg";
            }
            brand.DateCreate = DateTime.Now;
            _context.ThuongHieus.Update(brand);
            await _context.SaveChangesAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThuongHieu>> PostBrand([FromForm] UploadBrand upload)
        {
            ThuongHieu brand = new ThuongHieu();
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "brand");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                brand.ImagePath = fullPath;
                brand.Ten = upload.Name;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                brand.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                brand.ImagePath = "noimage.jpg";
            }
          
            brand.DateCreate = DateTime.Now;
            _context.ThuongHieus.Add(brand);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }
        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            SanPham product = new SanPham();
            product = await _context.SanPhams.FirstOrDefaultAsync(b => b.BrandId == id);
            var brand = await _context.ThuongHieus.FindAsync(id);
            if (product == null)
            {
                _context.ThuongHieus.Remove(brand);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.SanPhams.Remove(product);
                await _context.SaveChangesAsync();
                _context.ThuongHieus.Remove(brand);
                _context.SaveChanges();
            }
            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return _context.ThuongHieus.Any(e => e.Id == id);
        }
    }
}
