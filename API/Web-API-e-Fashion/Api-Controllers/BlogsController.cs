//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Web_API_e_Fashion.Data;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Web_API_e_Fashion.Api_Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BlogsController : ControllerBase
//    {
//        private readonly DPContext _context;
//        public BlogsController(DPContext context)
//        {
//            this._context = context;
//        }
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutBlog(int id, [FromForm] UploadBlog upload)
//        {
//            var listImage = new List<Image>();
//            SanPham sanpham = new SanPham();
//            sanpham = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
//            sanpham.Ten = upload.Ten;
//            sanpham.NgayCapNhat = DateTime.Now;
//            sanpham.HuongDan = upload.HuongDan;
//            sanpham.MoTa = upload.MoTa;
//            sanpham.GiaBan = upload.GiaBan;
//            sanpham.Tag = upload.Tag;
//            sanpham.GioiTinh = upload.GioiTinh;
//            sanpham.GiaNhap = upload.GiaNhap;
//            sanpham.KhuyenMai = upload.KhuyenMai;
//            sanpham.ThanhPhan = upload.ThanhPhan;
//            sanpham.TrangThaiHoatDong = upload.TrangThaiHoatDong;
//            sanpham.TrangThaiSanPham = upload.TrangThaiSanPham;
//            SanPham sp;
//            sp = _context.SanPhams.Find(id);


//            if (upload.Id_NhanHieu == null)
//            {
//                sanpham.Id_NhanHieu = sp.Id_NhanHieu;
//            }
//            else
//            {
//                sanpham.Id_NhanHieu = upload.Id_NhanHieu;
//            }

//            if (upload.Id_Loai == null)
//            {
//                sanpham.Id_Loai = sp.Id_Loai;
//            }
//            else
//            {
//                sanpham.Id_Loai = upload.Id_Loai;
//            }
//            if (upload.Id_NhaCungCap == null)
//            {
//                sanpham.Id_NhaCungCap = sp.Id_NhaCungCap;
//            }
//            Notification notification = new Notification()
//            {
//                TenSanPham = upload.Ten,
//                TranType = "Edit"
//            };
//            _context.Notifications.Add(notification);
//            ImageSanPham[] images = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToArray();
//            _context.ImageSanPhams.RemoveRange(images);
//            ImageSanPham image = new ImageSanPham();
//            var file = upload.files.ToArray();
//            var imageSanPhams = _context.ImageSanPhams.ToArray().Where(s => s.IdSanPham == id);
//            foreach (var i in imageSanPhams)
//            {
//                try
//                {
//                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-product", i.ImageName));
//                }
//                catch (Exception)
//                {

//                }

//            }
//            if (upload.files != null)
//            {
//                for (int i = 0; i < file.Length; i++)
//                {

//                    if (file[i].Length > 0)
//                    {
//                        var path = Path.Combine(
//                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-product",
//                       upload.Ten + i + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

//                        using (var stream = new FileStream(path, FileMode.Create))
//                        {
//                            await file[i].CopyToAsync(stream);
//                        }

//                        listImage.Add(new ImageSanPham()
//                        {
//                            ImageName = upload.Ten + i + "." + file[i].FileName.Split(".")
//                            [file[i].FileName.Split(".").Length - 1],
//                            IdSanPham = sanpham.Id,
//                        });
//                    }
//                }


//            }
//            else // xu li khi khong cap nhat hinh
//            {
//                List<ImageSanPham> List;
//                List = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToList();
//                foreach (ImageSanPham img in List)
//                    listImage.Add(new ImageSanPham()
//                    {
//                        ImageName = img.ImageName,
//                        IdSanPham = sanpham.Id,
//                    }); ;
//            };
//            sanpham.ImageSanPhams = listImage;
//            _context.SanPhams.Update(sanpham);
//            await _context.SaveChangesAsync();
//            await _hubContext.Clients.All.BroadcastMessage();
//            return Ok();
//        }

//        // POST: api/SanPhams
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<SanPham>> PostSanPham([FromForm] UploadSanpham upload)
//        {
//            var listImage = new List<ImageSanPham>();
//            SanPham sanpham = new SanPham()
//            {
//                Ten = upload.Ten,
//                NgayTao = DateTime.Now,
//                HuongDan = upload.HuongDan,
//                MoTa = upload.MoTa,
//                ThanhPhan = upload.ThanhPhan,
//                TrangThaiHoatDong = upload.TrangThaiHoatDong,
//                TrangThaiSanPham = upload.TrangThaiSanPham,
//                GiaBan = upload.GiaBan,
//                GioiTinh = upload.GioiTinh,
//                GiaNhap = upload.GiaNhap,
//                Tag = upload.Tag,
//                KhuyenMai = upload.KhuyenMai,
//                Id_Loai = upload.Id_Loai,
//                Id_NhanHieu = upload.Id_NhanHieu,
//                Id_NhaCungCap = upload.Id_NhaCungCap,
//            };
//            Notification notification = new Notification()
//            {
//                TenSanPham = upload.Ten,
//                TranType = "Add"
//            };
//            _context.Notifications.Add(notification);
//            var file = upload.files.ToArray();

//            _context.SanPhams.Add(sanpham);


//            await _context.SaveChangesAsync();
//            SanPham spTest;
//            spTest = await _context.SanPhams.FindAsync(sanpham.Id);
//            if (upload.files != null)
//            {
//                for (int i = 0; i < file.Length; i++)
//                {

//                    if (file[i].Length > 0)
//                    {

//                        ImageSanPham imageSanPham1 = new ImageSanPham();
//                        _context.ImageSanPhams.Add(imageSanPham1);
//                        await _context.SaveChangesAsync();
//                        var path = Path.Combine(
//                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-product",
//                       upload.Ten + imageSanPham1.Id + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

//                        using (var stream = new FileStream(path, FileMode.Create))
//                        {
//                            await file[i].CopyToAsync(stream);
//                        }


//                        imageSanPham1.ImageName = upload.Ten + imageSanPham1.Id + "." + file[i].FileName.Split(".")
//                            [file[i].FileName.Split(".").Length - 1];
//                        imageSanPham1.IdSanPham = spTest.Id;

//                        _context.ImageSanPhams.Update(imageSanPham1);
//                        await _context.SaveChangesAsync();

//                    }
//                }


//            }

//            await _hubContext.Clients.All.BroadcastMessage();
//            return Ok();
//        }
//        // DELETE: api/SanPhams/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSanPham(int id)
//        {

//            var imageSanPhams = _context.ImageSanPhams.ToArray().Where(s => s.IdSanPham == id);
//            foreach (var i in imageSanPhams)
//            {
//                try
//                {
//                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-product", i.ImageName));
//                }
//                catch (Exception)
//                {

//                }

//            }
//            Models.SanPhamBienThe[] spbts;
//            spbts = _context.SanPhamBienThes.Where(s => s.Id_SanPham == id).ToArray();
//            _context.SanPhamBienThes.RemoveRange(spbts);
//            ImageSanPham[] images;
//            images = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToArray();
//            _context.ImageSanPhams.RemoveRange(images);
//            await _context.SaveChangesAsync();
//            var sanPham = await _context.SanPhams.FindAsync(id);
//            if (sanPham == null)
//            {
//                return NotFound();
//            }

//            var CategoryConstraint = _context.Loais.Where(s => s.Id == id);
//            var BrandConstraint = _context.NhanHieus.SingleOrDefaultAsync(s => s.Id == id);



//            if (CategoryConstraint != null)
//            {
//                _context.SanPhams.Remove(sanPham);
//            }
//            if (BrandConstraint != null)
//            {
//                _context.SanPhams.Remove(sanPham);
//            }
//            Notification notification = new Notification()
//            {
//                TenSanPham = sanPham.Ten,
//                TranType = "Delete"
//            };
//            _context.Notifications.Add(notification);
//            await _context.SaveChangesAsync();
//            await _hubContext.Clients.All.BroadcastMessage();
//            return Ok();
//        }
//    }
//}
