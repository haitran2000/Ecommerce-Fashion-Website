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
    public class NhanHieusController : ControllerBase
    {
        private readonly DPContext _context;

        public NhanHieusController(DPContext context)
        {
            _context = context;
        }

        // GET: api/ThuongHieus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanHieu>>> GetThuongHieus()
        {
            return await _context.NhanHieus.ToListAsync();
        }

        // GET: api/ThuongHieus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanHieu>> GetThuongHieu(int id)
        {
            var thuongHieu = await _context.NhanHieus.FindAsync(id);

            if (thuongHieu == null)
            {
                return NotFound();
            }

            return thuongHieu;
        }

        // PUT: api/ThuongHieus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanHieu(int id, [FromForm] UploadBrand upload)
        {
            NhanHieu thuonghieu = new NhanHieu();
            thuonghieu = await _context.NhanHieus.FirstOrDefaultAsync(c => c.Id == id);
            thuonghieu.Ten = upload.Name;
            thuonghieu.ThongTin = upload.ThongTin;
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
            _context.NhanHieus.Update(thuonghieu);

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
        public async Task<ActionResult<NhanHieu>> PostNhanHieu([FromForm] UploadBrand upload)
        {
            NhanHieu nhanhieu = new NhanHieu();
            nhanhieu.Ten = upload.Name;
            nhanhieu.ThongTin = upload.ThongTin;
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
                nhanhieu.ImagePath = upload.TileImage.FileName;
            }
            else
            {
                nhanhieu.ImagePath = "noimage.jpg";
            }
           nhanhieu.DateCreate = DateTime.Now;
            _context.NhanHieus.Add(nhanhieu);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/ThuongHieus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuongHieu(int id)
        {
            SanPham[] product;
            product = await _context.SanPhams.Where(b => b.Id_NhanHieu == id).ToArrayAsync();
            var brand = await _context.NhanHieus.FindAsync(id);
            if (product == null)
            {
                _context.NhanHieus.Remove(brand);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.SanPhams.RemoveRange(product);
                await _context.SaveChangesAsync();
                _context.NhanHieus.Remove(brand);
                _context.SaveChanges();
            }
            return Ok();
        }
        private bool ThuongHieuExists(int id)
        {
            return _context.NhanHieus.Any(e => e.Id == id);
        }
    }
}
