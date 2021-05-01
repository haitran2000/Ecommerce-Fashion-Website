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
    public class LoaisController : ControllerBase
    {
        private readonly DPContext _context;

        public LoaisController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loai>>> GetCategories()
        {
            return await _context.Loais.ToListAsync();
        }


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loai>> GetCategory(int id)
        {
            var category = await _context.Loais.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromForm] UploadCategory upload)
        {
            Loai category = new Loai();
            category = await _context.Loais.FirstOrDefaultAsync(c => c.Id == id);
            category.Ten = upload.Name;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "category");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                category.ImagePath = fullPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                category.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                category.ImagePath = "noimage.jpg";
            }
           
            category.DateCreate = DateTime.Now;
            _context.Loais.Update(category);
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loai>> PostCategory([FromForm] UploadCategory upload)
        {
            Loai category = new Loai();
            category.Ten = upload.Name;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "category");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                category.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                category.ImagePath = "noimage.jpg";
            }
            category.DateCreate = DateTime.Now;
            _context.Loais.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            SanPham product = new SanPham();
            product = await _context.SanPhams.FirstOrDefaultAsync(s => s.CategoryId == id);
            var category = await _context.Loais.FindAsync(id);
            if (product == null)
            {
                _context.Loais.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.SanPhams.Remove(product);
                await _context.SaveChangesAsync();
                _context.Loais.Remove(category);
                _context.SaveChanges();
            }
           
       

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Loais.Any(e => e.Id == id);
        }
    }
}
