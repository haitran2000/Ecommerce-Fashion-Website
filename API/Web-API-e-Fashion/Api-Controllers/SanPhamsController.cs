using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ResModels;
using Web_API_e_Fashion.SignalRModels;
using Web_API_e_Fashion.UploadFileModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public SanPhamsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/SanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> GetSanPhams()
        {

            var kb = from s in _context.SanPhams
                     join l in _context.Loais
                     on s.Id_Loai equals l.Id
                     into f
                     from l in f.DefaultIfEmpty()
                     join th in _context.NhanHieus
                     on s.Id_NhanHieu equals th.Id
                     into j
                     from th in j.DefaultIfEmpty()
                     select new SanPhamLoaiThuongHieu()
                     {
                         Id = s.Id,
                         Ten = s.Ten,
                         KhuyenMai = s.KhuyenMai,
                         MoTa = s.MoTa,
                         HuongDan = s.HuongDan,
                         ThanhPhan = s.ThanhPhan,
                         TrangThaiSanPham = s.TrangThaiSanPham,
                         TrangThaiHoatDong = s.TrangThaiHoatDong,
                         TrangThaiSanPhamThietKe = s.TrangThaiSanPhamThietKe,
                         TenLoai = l.Ten,
                         TenNhanHieu = th.Ten,
                     };
            return await kb.ToListAsync();
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
        public async Task<IActionResult> PutSanPham(int id, [FromForm] UploadSanpham upload, string search)
        {
            //var listImage = new List<ImageSanPhamBienThe>();
            SanPham sanpham = new SanPham();
            sanpham = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
            sanpham.Ten = upload.Ten;
            sanpham.NgayCapNhat = DateTime.Now;
            sanpham.HuongDan = upload.HuongDan;
            sanpham.MoTa = upload.MoTa;
            sanpham.Gia = upload.Gia;
            sanpham.Tag = upload.Tag;
            sanpham.KhuyenMai = upload.KhuyenMai;
            sanpham.ThanhPhan = upload.ThanhPhan;
            sanpham.TrangThaiHoatDong = upload.TrangThaiHoatDong;
            sanpham.TrangThaiSanPhamThietKe = upload.TrangThaiSanPham;
            sanpham.TrangThaiSanPham = upload.TrangThaiSanPham;
            SanPham sp;
            sp = _context.SanPhams.Find(id);


            if (upload.Id_NhanHieu == null)
            {
                sanpham.Id_NhanHieu = sp.Id_NhanHieu;
            }
            else
            {
                sanpham.Id_NhanHieu = upload.Id_NhanHieu;
            }

            if (upload.Id_Loai == null)
            {
                sanpham.Id_Loai = sp.Id_Loai;
            }
            else
            {
                sanpham.Id_Loai = upload.Id_Loai;
            }
            Notification notification = new Notification()
            {
                TenSanPham = upload.Ten,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            //ImageSanPham[] images = _context.imageSanPhams.Where(s => s.SanPhamId == id).ToArray();
            /*context.imageSanPhams.RemoveRange(images);*/
            //ImageSanPham image = new ImageSanPham();
            //if (upload.ListImage != null)
            //{
            //    foreach (var formFile in upload.ListImage)
            //    {
            //        if (formFile.Length > 0)
            //        {
            //            var folderName = Path.Combine("Resources", "Images", "list-image-product");
            //            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //            var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            //            var fullPath = Path.Combine(pathToSave, fileName);
            //            using (var stream = new FileStream(fullPath, FileMode.Create))
            //            {
            //                await formFile.CopyToAsync(stream);
            //            }

            //            //listImage.Add(new ImageSanPhamBienThe()
            //            //{
            //            //    ImagePath = formFile.FileName,
            //                //SanPhamId = sanpham.Id,
            //            });
            //        }
            //    }
            //}
            //else
            //{
            //    //List<ImageSanPhamBienThe> ListimageSanPham1;
            //    //ListimageSanPham1 = _context.imageSanPhams.Where(s=>s.SanPhamId==id).ToList();
            //    //foreach(ImageSanPham img in ListimageSanPham1)
            //    //listImage.Add(new ImageSanPhamBienThe()
            //    //{
            //       //ImagePath = img.ImagePath,
            //       //SanPhamId = sanpham.Id,
            ////    });;
            ////};
            //sanpham.ImageSanPhams = listImage;
            _context.SanPhams.Update(sanpham);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        // POST: api/SanPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPham([FromForm] UploadSanpham upload)
        {

            //var listImage = new List<ImageSanPhamBienThe>();
            SanPham sanpham = new SanPham()
            {
                Ten = upload.Ten,
                NgayTao = DateTime.Now,
                HuongDan = upload.HuongDan,
                MoTa = upload.MoTa,
                ThanhPhan = upload.ThanhPhan,
                TrangThaiHoatDong = upload.TrangThaiHoatDong,
                TrangThaiSanPhamThietKe = upload.TrangThaiSanPhamThietKe,
                TrangThaiSanPham = upload.TrangThaiSanPham,
                Gia = upload.Gia,
                Tag = upload.Tag,
                KhuyenMai = upload.KhuyenMai,
                Id_Loai = upload.Id_Loai,
                Id_NhanHieu = upload.Id_NhanHieu,
            };
            Notification notification = new Notification()
            {
                TenSanPham = upload.Ten,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);
            _context.SanPhams.Add(sanpham);
       

            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        // DELETE: api/SanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            SanPhamBienThe[] spbts;
            spbts = _context.SanPhamBienThes.Where(s => s.Id_SanPham == id).ToArray();
            _context.SanPhamBienThes.RemoveRange(spbts);
            await _context.SaveChangesAsync();
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            var CategoryConstraint = _context.Loais.Where(s => s.Id == id);
            var BrandConstraint = _context.NhanHieus.SingleOrDefaultAsync(s => s.Id == id);



            if (CategoryConstraint != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            if (BrandConstraint != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            Notification notification = new Notification()
            {
                TenSanPham = sanPham.Ten,
                TranType = "Delete"
            };
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
