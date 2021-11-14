using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ServerToClientModels;
using Web_API_e_Fashion.SignalRModels;
using Web_API_e_Fashion.UploadFileModels;


namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamsController : Controller
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public SanPhamsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        [HttpPost("size/{id}")]
        public async Task<ActionResult> Size(int idLoai)
        {
            var resuft = _context.Sizes.Where(d => d.Id_Loai == 7).Select(
                d => new TenSizeLoai
                {
                    SizeLoaiTen = d.TenSize
                });
            return Json(resuft);
        }
        [HttpPost("mau/{id}")]
        public async Task<ActionResult<IEnumerable<MauSac>>> Mau(int idLoai)
        {
            return await _context.MauSacs.Where(d => d.Id_Loai == 7).ToListAsync();
        }
        [HttpPost("like")]
        public async Task<ActionResult> LikeSanPham(UserLike userlike)
        {
            var resuft = _context.UserLikes.Where(d => d.IdSanPham == userlike.IdSanPham && d.IdUser == userlike.IdUser).FirstOrDefault();
            if (resuft == null)
            {
                resuft = new UserLike
                {
                    IdSanPham = userlike.IdSanPham,
                    IdUser = userlike.IdUser,
                };
                _context.Add(resuft);
                _context.SaveChanges();
                return Json(1);
            }
            else
            {
                _context.Remove(resuft);
                _context.SaveChanges();
                return Json(2);
            }

        }
        [HttpPost("dslike")]
        public async Task<ActionResult> ListLikeSanPham(UserLike userlike)
        {
            var resuft = _context.UserLikes.Where(d => d.IdUser == userlike.IdUser).Select(
                d => new SanPhamLike
                {
                    id = d.Id,
                    idSanPham = d.IdSanPham,
                    ten = _context.SanPhams.Where(s => s.Id == d.IdSanPham).Select(s => s.Ten).FirstOrDefault(),
                    gia = (decimal)_context.SanPhams.Where(s => s.Id == d.IdSanPham).Select(s => s.GiaBan).FirstOrDefault(),
                }); ;

            return Json(resuft);
        }
        [HttpPost("deletelike/{id}")]
        public async Task<ActionResult> DeleteLike(int id)
        {
            var card = _context.UserLikes.Where(d => d.Id == id).SingleOrDefault();
            _context.UserLikes.Remove(card);
            await _context.SaveChangesAsync();
            return Json("1");
        }
        [HttpPost("review")]
        public async Task<ActionResult> Review(UserComment usercomment)
        {


            var resuft = new UserComment
            {
                NgayComment = DateTime.Now,
                IdSanPham = usercomment.IdSanPham,
                Content = usercomment.Content,
                IdUser = usercomment.IdUser,
            };
            _context.Add(resuft);
            _context.SaveChanges();
            var listcomment = _context.UserComments.Where(d => d.IdSanPham == usercomment.IdSanPham).Select(
                d => new Review
                {
                    Content = d.Content,
                    tenUser = _context.AppUsers.Where(s => s.Id == d.IdUser).Select(s => s.FirstName + " " + s.LastName).SingleOrDefault(),
                    NgayComment = d.NgayComment
                }
                );
            return Json(listcomment);
        }
        [HttpPost("listreview")]
        public async Task<ActionResult> ListReview(UserComment usercomment)
        {
            var listcomment = _context.UserComments.Where(d => d.IdSanPham == usercomment.IdSanPham).Select(
                d => new Review
                {
                    Content = d.Content,
                    tenUser = _context.AppUsers.Where(s => s.Id == d.IdUser).Select(s => s.FirstName + " " + s.LastName).SingleOrDefault(),
                    NgayComment = d.NgayComment
                }
                );
            return Json(listcomment);
        }
        [HttpPost("checklike")]
        public async Task<ActionResult> checkLikeSanPham(UserLike userlike)
        {
            var resuft = _context.UserLikes.Where(d => d.IdSanPham == userlike.IdSanPham && d.IdUser == userlike.IdUser).FirstOrDefault();
            if (resuft == null)
            {
                return Json(1);
            }
            else
            {
                return Json(2);
            }

        }
        [HttpGet("sp")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSps()
        {
            return await _context.SanPhams.ToListAsync();
        }

        // GET: api/SanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> GetSanPhams()
        {
            string sql = @"
                            	;with ProductImageTable
	                            as (
		                        SELECT COUNT(UserLikes.IdSanPham) as 'soluonglike',COUNT(UserComments.IdSanPham)as 'soluongcomment',SanPhams.Id,SanPhams.Ten,ImageSanPhams.ImageName,cast(SanPhams.GiaBan as decimal(18,2)) as'GiaBan',cast(SanPhams.GiaNhap as decimal(18,2))as'GiaNhap',SanPhams.Tag,
								SanPhams.KhuyenMai,SanPhams.MoTa,SanPhams.HuongDan,SanPhams.ThanhPhan,ImageSanPhams.Id as 'IdImage',
								SanPhams.TrangThaiSanPham,SanPhams.TrangThaiHoatDong,Loais.Ten as 'LoaiTen',NhaCungCaps.Ten as 'NhaCungCapTen',NhanHieus.Ten as'NhanHieuTen', 
		                        ROW_NUMBER() OVER (PARTITION BY SanPhams.Id ORDER BY  ImageSanPhams.Id)  RowNum
		                        FROM SanPhams LEFT JOIN ImageSanPhams ON SanPhams.Id=ImageSanPhams.IdSanPham inner join Loais
								on SanPhams.Id_Loai = Loais.Id
								inner join NhanHieus
								on SanPhams.Id_NhanHieu = NhanHieus.Id
                                left join NhaCungCaps
                                on SanPhams.Id_NhaCungCap = NhaCungCaps.Id
								left join UserLikes
								on UserLikes.IdSanPham = SanPhams.Id
								left join UserComments
								on UserComments.IdSanPham = SanPhams.Id
								group by SanPhams.Id,SanPhams.Ten,ImageSanPhams.ImageName,cast(SanPhams.GiaBan as decimal(18,2)) ,cast(SanPhams.GiaNhap as decimal(18,2)),SanPhams.Tag,
								SanPhams.KhuyenMai,SanPhams.MoTa,SanPhams.HuongDan,SanPhams.ThanhPhan,ImageSanPhams.Id,
								SanPhams.TrangThaiSanPham,SanPhams.TrangThaiHoatDong,Loais.Ten ,NhaCungCaps.Ten ,NhanHieus.Ten
		                          )
		                        SELECT Id,Ten,soluonglike,IdImage,soluongcomment, ImageName,GiaBan,GiaNhap,Tag,KhuyenMai,MoTa,HuongDan,ThanhPhan,TrangThaiHoatDong,TrangThaiSanPham,LoaiTen,NhaCungCapTen,NhanHieuTen
		                        from ProductImageTable
	                            where
                                ProductImageTable.RowNum = 1
                            ";
            SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString());
            List<SanPhamLoaiThuongHieu> List = new List<SanPhamLoaiThuongHieu>();
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        List.Add(new SanPhamLoaiThuongHieu()
                        {
                            Id = (int)reader["Id"],
                            Ten = (string)reader["Ten"],
                            Image = reader["ImageName"].ToString(),
                            GiaBan = (decimal)reader["GiaBan"],
                            GiaNhap = (decimal)reader["GiaNhap"],
                            Tag = (string)reader["Tag"],
                            KhuyenMai = (decimal)reader["KhuyenMai"],
                            MoTa = (string)reader["MoTa"],
                            HuongDan = (string)reader["HuongDan"],
                            ThanhPhan = (string)reader["ThanhPhan"],
                            TrangThaiSanPham = (string)reader["TrangThaiSanPham"],
                            TrangThaiHoatDong = (bool)reader["TrangThaiHoatDong"],
                            TenLoai = (string)reader["LoaiTen"],
                            TenNhanHieu = (string)reader["NhanHieuTen"],
                            TenNhaCungCap= (string)reader["NhaCungCapTen"],
                            SoLuongComment = (int)reader["soluongcomment"],
                            SoLuongLike = (int)reader["soluonglike"],
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ToString());
            }
            return List;
      
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
        [HttpPut("capnhattrangthaihoatdong/{id}")]
        public async Task<ActionResult> PutSanPhamTrangThaiHoatDong(int id, SanPham sp)
        {
            SanPham sanpham = new SanPham();
            sanpham = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
            sanpham.TrangThaiHoatDong = !sp.TrangThaiHoatDong;
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(int id, [FromForm] UploadSanpham upload)
        {
            var listImage = new List<ImageSanPham>();
            SanPham sanpham = new SanPham();
            sanpham = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
            sanpham.Ten = upload.Ten;
            sanpham.NgayCapNhat = DateTime.Now;
            sanpham.HuongDan = upload.HuongDan;
            sanpham.MoTa = upload.MoTa;
            sanpham.GiaBan = upload.GiaBan;
            sanpham.Tag = upload.Tag;
            sanpham.GioiTinh = upload.GioiTinh;
            sanpham.GiaNhap = upload.GiaNhap;
            sanpham.KhuyenMai = upload.KhuyenMai;
            sanpham.ThanhPhan = upload.ThanhPhan;
            sanpham.TrangThaiHoatDong = upload.TrangThaiHoatDong;
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
            if (upload.Id_NhaCungCap == null)
            {
                sanpham.Id_NhaCungCap = sp.Id_NhaCungCap;
            }
            Notification notification = new Notification()
            {
                TenSanPham = upload.Ten,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            ImageSanPham[] images = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToArray();
            _context.ImageSanPhams.RemoveRange(images);
            ImageSanPham image = new ImageSanPham();
            var file = upload.files.ToArray();
            var imageSanPhams = _context.ImageSanPhams.ToArray().Where(s => s.IdSanPham == id);
            foreach (var i in imageSanPhams)
            {
                try
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-product", i.ImageName));
                }
                catch (Exception )
                {

                }

            }
            if (upload.files != null)
            {
                for (int i = 0; i < file.Length; i++)
                {

                    if (file[i].Length > 0)
                    {
                        var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-product",
                       upload.Ten + i + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file[i].CopyToAsync(stream);
                        }

                        listImage.Add(new ImageSanPham()
                        {
                            ImageName = upload.Ten + i + "." + file[i].FileName.Split(".")
                            [file[i].FileName.Split(".").Length - 1],
                            IdSanPham = sanpham.Id,
                        });
                    }
                }


            }
            else // xu li khi khong cap nhat hinh
            {
                List<ImageSanPham> List;
                List = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToList();
                foreach (ImageSanPham img in List)
                    listImage.Add(new ImageSanPham()
                    {
                        ImageName = img.ImageName,
                        IdSanPham = sanpham.Id,
                    }); ;
            };
            sanpham.ImageSanPhams = listImage;
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
            var listImage = new List<ImageSanPham>();
            SanPham sanpham = new SanPham()
            {
                Ten = upload.Ten,
                NgayTao = DateTime.Now,
                HuongDan = upload.HuongDan,
                MoTa = upload.MoTa,
                ThanhPhan = upload.ThanhPhan,
                TrangThaiHoatDong = upload.TrangThaiHoatDong,
                TrangThaiSanPham = upload.TrangThaiSanPham,
                GiaBan = upload.GiaBan,
                GioiTinh=upload.GioiTinh,
                GiaNhap = upload.GiaNhap,
                Tag = upload.Tag,
                KhuyenMai = upload.KhuyenMai,
                Id_Loai = upload.Id_Loai,
                Id_NhanHieu = upload.Id_NhanHieu,
                Id_NhaCungCap =upload.Id_NhaCungCap,
            };
            Notification notification = new Notification()
            {
                TenSanPham = upload.Ten,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);
            var file = upload.files.ToArray();

            _context.SanPhams.Add(sanpham);


            await _context.SaveChangesAsync();
            SanPham spTest;
            spTest = await _context.SanPhams.FindAsync(sanpham.Id);
            if (upload.files != null)
            {
                for (int i = 0; i < file.Length; i++)
                {

                    if (file[i].Length > 0)
                    {

                        ImageSanPham imageSanPham1 = new ImageSanPham();
                        _context.ImageSanPhams.Add(imageSanPham1);
                        await _context.SaveChangesAsync();
                        var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-product",
                       upload.Ten + imageSanPham1.Id + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file[i].CopyToAsync(stream);
                        }


                        imageSanPham1.ImageName = upload.Ten + imageSanPham1.Id + "." + file[i].FileName.Split(".")
                            [file[i].FileName.Split(".").Length - 1];
                        imageSanPham1.IdSanPham = spTest.Id;

                        _context.ImageSanPhams.Update(imageSanPham1);
                        await _context.SaveChangesAsync();

                    }
                }


            }

            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        // DELETE: api/SanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {

            var imageSanPhams = _context.ImageSanPhams.ToArray().Where(s => s.IdSanPham == id);
            foreach (var i in imageSanPhams)
            {
                try
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-product", i.ImageName));
                }
                catch (Exception )
                {

                }

            }
            Models.SanPhamBienThe[] spbts;
            spbts = _context.SanPhamBienThes.Where(s => s.Id_SanPham == id).ToArray();
            _context.SanPhamBienThes.RemoveRange(spbts);
            ImageSanPham[] images;
            images = _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToArray();
            _context.ImageSanPhams.RemoveRange(images);
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

        [HttpGet("loai/{id}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetCategory(int id)
        {
            return await _context.SanPhams.Where(s => s.Id_Loai == id || s.Id_NhanHieu == id).ToListAsync();
        }

        [HttpGet("nhanhieu/{id}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetBrand(int id)
        {
            return await _context.SanPhams.Where(s => s.Id_NhanHieu == id).ToListAsync();
        }
        [HttpGet("loainhanhieu/{id}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetBrandCate(int id)
        {

            var get = _context.SanPhams.Where(s => s.Id_Loai == id);
            if (get != null)
            {
                return await _context.SanPhams.Where(s => s.Id_Loai == id).ToListAsync();
            }
            else
            {
                return await _context.SanPhams.Where(s => s.Id_NhanHieu == id).ToListAsync();
            }



        }
        [HttpGet("chitietsanpham/{id}")]
        public async Task<ActionResult<ProductDetail>> Chitiet(int id)
        {
            ProductDetail pr;
            List<ImageSanPham> listImage;
            listImage = await _context.ImageSanPhams.Where(s => s.IdSanPham == id).ToListAsync();
            List<SanPhamBienTheMauSize> listSPBT;
            var kb1 = from s in _context.SanPhamBienThes
                      join z in _context.Sizes
                      on s.SizeId equals z.Id
                      join m in _context.MauSacs
                      on s.Id_Mau equals m.Id
                      select new SanPhamBienTheMauSize()
                      {
                          Id = s.Id,
                          SoLuongTon = s.SoLuongTon,
                          TenMau = m.MaMau,
                          TenSize = z.TenSize,
                          Id_SanPham = s.Id_SanPham,
                      };
            listSPBT = await kb1.Where(s => s.Id_SanPham == id).ToListAsync();
            var kb = from s in _context.SanPhams
                     join spbt in _context.SanPhamBienThes
                     on s.Id equals spbt.Id_SanPham
                     join hinh in _context.ImageSanPhams
                     on s.Id equals hinh.IdSanPham
                     join th in _context.NhanHieus
                     on s.Id_NhanHieu equals th.Id
                     join l in _context.Loais
                     on s.Id_Loai equals l.Id
                     join ncc in _context.NhaCungCaps
                     on s.Id_NhaCungCap equals ncc.Id
                     select new ProductDetail()
                     {

                         Id = s.Id,
                         Ten = s.Ten,
                         GiaBan = s.GiaBan,
                         Tag = s.Tag,
                         KhuyenMai = s.KhuyenMai,
                         MoTa = s.MoTa,
                         GioiTinh=s.GioiTinh,
                         HuongDan = s.HuongDan,
                         TenNhaCungCap = ncc.Ten,
                         ThanhPhan = s.ThanhPhan,
                         TrangThaiSanPham = s.TrangThaiSanPham,
                         TrangThaiHoatDong = s.TrangThaiHoatDong,
                         Id_Loai = s.Id_Loai,
                         Id_NhanHieu = s.Id_NhanHieu,
                         TenLoai = l.Ten,
                         TenNhanHieu = th.Ten,
                         ImageSanPhams = listImage,
                         SanPhamBienThes = listSPBT,
                     };
            pr = kb.FirstOrDefault(s => s.Id == id);
            return pr;
        }
        [HttpGet("laytatcasanpham")]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> Laytatcasanpham()
        {

            try
            {
                var listIdSanPhamliked = await _context.UserLikes.Select(s => s.IdSanPham).ToListAsync();
           
                var kb = _context.SanPhams.Select(
                       s => new SanPhamLoaiThuongHieu()
                       {
                           Id = s.Id,
                           Ten = s.Ten,
                           GiaBan = s.GiaBan,
                           Tag = s.Tag,
                           KhuyenMai = s.KhuyenMai,
                           MoTa = s.MoTa,
                           HuongDan = s.HuongDan,
                           GioiTinh = s.GioiTinh,
                           ThanhPhan = s.ThanhPhan,
                           IsLike = listIdSanPhamliked.Contains(s.Id),
                           TrangThaiSanPham = s.TrangThaiSanPham,
                           TrangThaiHoatDong = s.TrangThaiHoatDong,
                           Id_Loai = s.Id_Loai,
                           Id_NhanHieu = s.Id_NhanHieu,
                           TenLoai = _context.Loais.Where(d => d.Id == s.Id_Loai).Select(d => d.Ten).FirstOrDefault(),
                           TenNhanHieu = _context.NhanHieus.Where(d => d.Id == s.Id_NhanHieu).Select(d => d.Ten).FirstOrDefault(),
                           Image = _context.ImageSanPhams.Where(q => q.IdSanPham == s.Id).Select(q => q.ImageName).FirstOrDefault(),
                       }).Where(s => s.TrangThaiHoatDong == true).ToList();
                return kb;
            }
            catch(Exception ex)
            {
                var a = ex;
                return BadRequest(ex);
            }
          
        }
        [HttpGet("topsanphammoi")]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> DanhSachHangMoi()
        {
            var kb =  _context.SanPhams.Select(
                   s => new SanPhamLoaiThuongHieu()
                   {

                       Id = s.Id,
                       Ten = s.Ten,
                       GiaBan = s.GiaBan,
                       Tag = s.Tag,
                       KhuyenMai = s.KhuyenMai,
                       MoTa = s.MoTa,
                       HuongDan = s.HuongDan,
                       GioiTinh = s.GioiTinh,
                       ThanhPhan = s.ThanhPhan,
                       TrangThaiSanPham = s.TrangThaiSanPham,                   
                       TrangThaiHoatDong = s.TrangThaiHoatDong,
                       Id_Loai = s.Id_Loai,
                       Id_NhanHieu = s.Id_NhanHieu,
                       TenLoai = _context.Loais.Where(d => d.Id == s.Id_Loai).Select(d => d.Ten).FirstOrDefault(),
                       TenNhanHieu = _context.NhanHieus.Where(d => d.Id == s.Id_NhanHieu).Select(d => d.Ten).FirstOrDefault(),
                       Image = _context.ImageSanPhams.Where(q => q.IdSanPham == s.Id).Select(q => q.ImageName).FirstOrDefault(),
                   }).Where(s=>s.TrangThaiSanPham=="new"&&s.TrangThaiHoatDong==true).ToList();
            return kb;
        }
        [HttpPost("sapxepsanpham")]
        public async Task<ActionResult> SapXepSP(SapXep sx)
        {
            var kb = _context.SanPhams.Where(d => d.GiaBan > sx.Thap && d.GiaBan < sx.Cao).Select(
                   s => new SanPhamLoaiThuongHieu()
                   {

                       Id = s.Id,
                       Ten = s.Ten,
                       GiaBan = s.GiaBan,
                       Tag = s.Tag,
                       KhuyenMai = s.KhuyenMai,
                       MoTa = s.MoTa,
                       HuongDan = s.HuongDan,
                       GioiTinh = s.GioiTinh,
                       ThanhPhan = s.ThanhPhan,
                       TrangThaiSanPham = s.TrangThaiSanPham,
                       TrangThaiHoatDong = s.TrangThaiHoatDong,
                       Id_Loai = s.Id_Loai,
                       Id_NhanHieu = s.Id_NhanHieu,
                       TenLoai = _context.Loais.Where(d => d.Id == s.Id_Loai).Select(d => d.Ten).FirstOrDefault(),
                       TenNhanHieu = _context.NhanHieus.Where(d => d.Id == s.Id_NhanHieu).Select(d => d.Ten).FirstOrDefault(),
                       Image = _context.ImageSanPhams.Where(q => q.IdSanPham == s.Id).Select(q => q.ImageName).FirstOrDefault(),
                   }).ToList();
            return Json(kb);
        }
        [HttpPost("searchtheomau")]
        public IActionResult getListTaskCalendar([FromBody] JObject json)
        {
            var mau = json.GetValue("mausac").ToString();
            var list_id_mau = _context.MauSacs.Where(d => d.MaMau == mau).Select(d => d.Id.ToString()).ToList();
            var list_spbienthe_theomau = _context.SanPhamBienThes.Where(d => list_id_mau.Contains((d.Id_Mau.ToString()))).Select(d => d.Id_SanPham).Distinct().ToList();
            var kb = _context.SanPhams.Where(d => list_spbienthe_theomau.Contains(d.Id)).Select(
                   s => new SanPhamLoaiThuongHieu()
                   {

                       Id = s.Id,
                       Ten = s.Ten,
                       GiaBan = s.GiaBan,
                       Tag = s.Tag,
                       KhuyenMai = s.KhuyenMai,
                       MoTa = s.MoTa,
                       HuongDan = s.HuongDan,
                       GioiTinh = s.GioiTinh,
                       ThanhPhan = s.ThanhPhan,
                       TrangThaiSanPham = s.TrangThaiSanPham,
                       TrangThaiHoatDong = s.TrangThaiHoatDong,
                       Id_Loai = s.Id_Loai,
                       Id_NhanHieu = s.Id_NhanHieu,
                       TenLoai = _context.Loais.Where(d => d.Id == s.Id_Loai).Select(d => d.Ten).FirstOrDefault(),
                       TenNhanHieu = _context.NhanHieus.Where(d => d.Id == s.Id_NhanHieu).Select(d => d.Ten).FirstOrDefault(),
                       Image = _context.ImageSanPhams.Where(q => q.IdSanPham == s.Id).Select(q => q.ImageName).FirstOrDefault(),
                   }).ToList();
            return Json(kb);
        }
        public class SapXep
        {
            public decimal Thap { get; set; }
            public decimal Cao { get; set; }


        }
        //[HttpGet("topsanphambanchay")]
        //public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> SanPhamBanChay()
        //{
        //    var kb = _context.SanPhams.Where(d => d.TrangThaiSanPham == "hot").Select(
        //           s => new SanPhamLoaiThuongHieu()
        //           {

        //               Id = s.Id,
        //               Ten = s.Ten,
        //               Gia = s.Gia,
        //               Tag = s.Tag,
        //               KhuyenMai = s.KhuyenMai,
        //               MoTa = s.MoTa,
        //               HuongDan = s.HuongDan,
        //               GioiTinh = s.GioiTinh,
        //               ThanhPhan = s.ThanhPhan,
        //               TrangThaiSanPham = s.TrangThaiSanPham,
        //               TrangThaiHoatDong = s.TrangThaiHoatDong,
        //               Id_Loai = s.Id_Loai,
        //               Id_NhanHieu = s.Id_NhanHieu,
        //               TenLoai = _context.Loais.Where(d => d.Id == s.Id_Loai).Select(d => d.Ten).FirstOrDefault(),
        //               TenNhanHieu = _context.NhanHieus.Where(d => d.Id == s.Id_NhanHieu).Select(d => d.Ten).FirstOrDefault(),
        //               Image = _context.ImageSanPhams.Where(q => q.IdSanPham == s.Id).Select(q => q.ImageName).FirstOrDefault(),
        //           }).Take<SanPhamLoaiThuongHieu>(4).ToList();
        //    return kb;
        //}
    }
}