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

        // GET: api/Loais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loai>>> GetLoais()
        {
            return await _context.Loais.ToListAsync();
        }

        // GET: api/Loais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loai>> GetLoai(int id)
        {
            var loai = await _context.Loais.FindAsync(id);

            if (loai == null)
            {
                return NotFound();
            }

            return loai;
        }

        // PUT: api/Loais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoai(int id, [FromForm] UploadCategory upload)
        {
            Loai loai = new Loai();
            loai = await _context.Loais.FirstOrDefaultAsync(c => c.Id == id);
            loai.Ten = upload.Name;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "category");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                loai.ImagePath = fullPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                loai.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                loai.ImagePath = "noimage.jpg";
            }

            loai.DateCreate = DateTime.Now;
            _context.Loais.Update(loai);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiExists(id))
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

        // POST: api/Loais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loai>> PostLoai([FromForm] UploadCategory upload)
        {
            Loai loai = new Loai();
            loai.Ten = upload.Name;
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
                loai.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                loai.ImagePath = "noimage.jpg";
            }
            loai.DateCreate = DateTime.Now;
            _context.Loais.Add(loai);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Loais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoai(int id)
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

        private bool LoaiExists(int id)
        {
            return _context.Loais.Any(e => e.Id == id);
        }
    }
}
