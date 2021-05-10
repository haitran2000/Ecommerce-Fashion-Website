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
    public class SanPhamsController : ControllerBase
    {
        private readonly DPContext _context;
        public SanPhamsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/SanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhams()
        {
            return await _context.SanPhams.ToListAsync();
        }

        // GET: api/SanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetSanPham(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return sanPham;
        }

        // PUT: api/SanPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(int id,[FromForm]UploadSanpham upload, string search)
        {
            var listImage = new List<ImageSanPham>();
            SanPham sanpham = new SanPham();
            sanpham = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
           sanpham.Ten = upload.Ten;
            sanpham.ChatLieu = upload.ChatLieu;
            sanpham.CreateBy = upload.CreateBy;
            sanpham.CreatedDate = DateTime.Now;
            sanpham.HuongDan = upload.HuongDan;
            sanpham.KhoiLuong = upload.KhoiLuong;
            sanpham.MoTa = upload.MoTa;
          
            sanpham.ThanhPhan = upload.ThanhPhan;
            sanpham.SoLuong = upload.SoLuong;
            sanpham.TrangThaiHienThi = true;
            sanpham.TrangThaiSanPhamThietKe = upload.TrangThaiSanPham;
            sanpham.UpdateBy = upload.UpdateBy;
            SanPham sp;
            sp = _context.SanPhams.Find(id);
            
            sanpham.UpdatedDate = null;
            if (upload.BrandId == null)
            {
                sanpham.BrandId = sp.BrandId;
            }
            else
            {
                sanpham.BrandId = upload.BrandId;
            }

            if (upload.CategoryId == null)
            {
                sanpham.CategoryId = sp.CategoryId;
            }
            else
            {
                sanpham.CategoryId = upload.CategoryId;
            }

            ImageSanPham image = new ImageSanPham();
            if (upload.ListImage != null)
            {
                foreach (var formFile in upload.ListImage)
                {
                    if (formFile.Length > 0)
                    {
                        var folderName = Path.Combine("Resources", "Images", "list-image-product");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        listImage.Add(new ImageSanPham()
                        {
                            ImagePath = formFile.FileName,
                            SanPhamId = sanpham.Id,
                        });
                    }
                }
            }
            else
            {
                List<ImageSanPham> ListimageSanPham1;
                ListimageSanPham1 = _context.imageSanPhams.Where(s=>s.SanPhamId==id).ToList();
                foreach(ImageSanPham img in ListimageSanPham1)
                listImage.Add(new ImageSanPham()
                {
                   ImagePath = img.ImagePath,
                   SanPhamId = sanpham.Id,
                });;
            };
            sanpham.ImageSanPhams = listImage;
            _context.SanPhams.Update(sanpham);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/SanPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPham([FromForm] UploadSanpham upload)
        {
           
            var listImage = new List<ImageSanPham>();
            SanPham sanpham = new SanPham()
            {
                Ten = upload.Ten,
                ChatLieu = upload.ChatLieu,
                CreateBy = upload.CreateBy,
                CreatedDate = DateTime.Now,
                HuongDan = upload.HuongDan,
                KhoiLuong = upload.KhoiLuong,
                MoTa = upload.MoTa,
            
                ThanhPhan = upload.ThanhPhan,
                SoLuong = upload.SoLuong,
                TrangThaiHienThi = true,
                TrangThaiSanPhamThietKe = true,
                UpdateBy = upload.UpdateBy,
                KhuyenMai = upload.KhuyenMai,
                UpdatedDate = null,
                ImageSanPhams = listImage,
                SanPhamThietKes = null,
                SanPham_SanPhamThietKes = null,
                GiaSanPhams = null,
                CategoryId = upload.CategoryId,
                BrandId = upload.BrandId,
            };
            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();
            if (upload.ListImage != null)
            {
                foreach (var formFile in upload.ListImage)
                {
                    if (formFile.Length > 0)
                    {
                        var folderName = Path.Combine("Resources", "Images", "list-image-product");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        listImage.Add(new ImageSanPham()
                        {
                            ImagePath= formFile.FileName,
                            SanPhamId = sanpham.Id,
                        });
                    }
                }
            }
            else
            {
              
            }
            SanPham sanpham2 = await _context.SanPhams.FindAsync(sanpham.Id);
            sanpham2.ImageSanPhams = listImage;
            _context.SanPhams.Update(sanpham2);
            _context.SaveChanges();

            return NoContent();
        }
        // DELETE: api/SanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            List<ImageSanPham> listImage = new List<ImageSanPham>();
             listImage = await _context.imageSanPhams.Where(s=>s.SanPhamId==id).ToListAsync();
            var CategoryConstraint = _context.Loais.Where(s => s.Id == id);
            var BrandConstraint = _context.ThuongHieus.SingleOrDefaultAsync(s => s.Id == id);
           
            foreach (var image in listImage)
            {
                if (image != null)
                {
                    _context.imageSanPhams.Remove(image);
                }
            }
          
            if (CategoryConstraint != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            if (BrandConstraint != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
