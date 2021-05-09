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
        public async Task<IActionResult> PutThuongHieu(int id, [FromForm] UploadBrand upload)
        {
            ThuongHieu thuonghieu = new ThuongHieu();
            thuonghieu = await _context.ThuongHieus.FirstOrDefaultAsync(c => c.Id == id);
            thuonghieu.Ten = upload.Name;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "brand");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                thuonghieu.ImagePath = fullPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                thuonghieu.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                thuonghieu.ImagePath = "noimage.jpg";
            }

            thuonghieu.DateCreate = DateTime.Now;
            _context.ThuongHieus.Update(thuonghieu);

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
        public async Task<ActionResult<ThuongHieu>> PostThuongHieu([FromForm] UploadBrand upload)
        {
            ThuongHieu thuonghieu = new ThuongHieu();
            thuonghieu.Ten = upload.Name;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "brand");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                thuonghieu.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                thuonghieu.ImagePath = "noimage.jpg";
            }
           thuonghieu.DateCreate = DateTime.Now;
            _context.ThuongHieus.Add(thuonghieu);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/ThuongHieus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuongHieu(int id)
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

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieus.Any(e => e.Id == id);
        }
    }
}
