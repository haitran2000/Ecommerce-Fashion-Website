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
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ResModels;
using Web_API_e_Fashion.ServerToClientModels;
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

        [HttpGet("sp")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSps()
        {
            return await _context.SanPhams.ToListAsync();
        }
 //       @"select SanPhams.Id,SanPhams.Ten,ImageSanPhams.ImageName,cast(SanPhams.Gia as decimal(18,2)) as'Gia',cast(SanPhams.GiaNhap as decimal(18,2))as'GiaNhap',SanPhams.Tag,
	//SanPhams.KhuyenMai,SanPhams.MoTa,SanPhams.HuongDan,SanPhams.ThanhPhan,
	//SanPhams.TrangThaiSanPham,SanPhams.TrangThaiHoatDong,Loais.Ten as 'LoaiTen',NhanHieus.Ten as'NhanHieuTen'
	//from SanPhams
	//inner join Loais
	//on SanPhams.Id_Loai = Loais.Id
	//inner join NhanHieus
	//on SanPhams.Id_NhanHieu = NhanHieus.Id
	//left join ImageSanPhams
	//on SanPhams.Id = ImageSanPhams.IdSanPham"
        // GET: api/SanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> GetSanPhams()
        {
            string sql = @"
                            	;with ProductImageTable
	                          as (
		                        SELECT SanPhams.Id,SanPhams.Ten,ImageSanPhams.ImageName,cast(SanPhams.GiaBan as decimal(18,2)) as'GiaBan',cast(SanPhams.GiaNhap as decimal(18,2))as'GiaNhap',SanPhams.Tag,
								SanPhams.KhuyenMai,SanPhams.MoTa,SanPhams.HuongDan,SanPhams.ThanhPhan,
								SanPhams.TrangThaiSanPham,SanPhams.TrangThaiHoatDong,Loais.Ten as 'LoaiTen',NhaCungCaps.Ten as 'NhaCungCapTen',NhanHieus.Ten as'NhanHieuTen', 
		                        ROW_NUMBER() OVER (PARTITION BY SanPhams.Id ORDER BY  ImageSanPhams.Id)  RowNum
		                        FROM SanPhams LEFT JOIN ImageSanPhams ON SanPhams.Id=ImageSanPhams.IdSanPham inner join Loais
								on SanPhams.Id_Loai = Loais.Id
								inner join NhanHieus
								on SanPhams.Id_NhanHieu = NhanHieus.Id
                                left join NhaCungCaps
                                on SanPhams.Id_NhaCungCap = NhaCungCaps.Id
		                          )
		                    SELECT Id,Ten, ImageName,GiaBan,GiaNhap,Tag,KhuyenMai,MoTa,HuongDan,ThanhPhan,TrangThaiHoatDong,TrangThaiSanPham,LoaiTen,NhaCungCapTen,NhanHieuTen
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

        // PUT: api/SanPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("capnhattrangthaihoatdong/{id}")]
        public async Task<ActionResult> PutSanPhamTrangThaiHoatDong(int id,SanPham sp)
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
                catch (Exception ex)
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
                catch (Exception ex)
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
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> Laytatcasanphamasync()
        {
            var sql = @";with ProductImageTable
	                          as (
		                        SELECT SanPhams.Id,SanPhams.Ten,SanPhams.GiaBan ,ImageSanPhams.ImageName, 
		                        ROW_NUMBER() OVER (PARTITION BY SanPhams.Id ORDER BY  ImageSanPhams.Id)  RowNum
		                        FROM SanPhams LEFT JOIN ImageSanPhams ON SanPhams.Id=ImageSanPhams.IdSanPham
		                          )
		                    SELECT Id,Ten, ImageName,GiaBan
		                    from ProductImageTable
	                        where
                            ProductImageTable.RowNum = 1";
          
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var list = new List<SanPhamLoaiThuongHieu>();

            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        list.Add(new SanPhamLoaiThuongHieu() { Id=(int)reader["Id"],Ten = (string)reader["Ten"], Image=(string)reader["ImageName"],GiaBan=(decimal)reader["GiaBan"] });
                    }
                }

                await cnn.CloseAsync();
            }
            catch (Exception ex)
            {

            };

            return list;
            //var kb = from s in _context.SanPhams
            //         join l in _context.Loais
            //         on s.Id_Loai equals l.Id
            //         into f
            //         from l in f.DefaultIfEmpty()
            //         join th in _context.NhanHieus
            //         on s.Id_NhanHieu equals th.Id
            //         into j
            //         from th in j.DefaultIfEmpty()                 
            //         join image in _context.ImageSanPhams
            //         on s.Id equals image.IdSanPham
            //         select new SanPhamLoaiThuongHieu()
            //         {
            //             Image = image.ImageName,
            //             Id = s.Id,
            //             Ten = s.Ten,
            //             Gia = s.Gia,
            //             Tag = s.Tag,
            //             KhuyenMai = s.KhuyenMai,
            //             MoTa = s.MoTa,
            //             HuongDan = s.HuongDan,
            //             ThanhPhan = s.ThanhPhan,
            //             TrangThaiSanPham = s.TrangThaiSanPham,
            //             TrangThaiHoatDong = s.TrangThaiHoatDong,
            //             Id_Loai = s.Id_Loai,
            //             Id_NhanHieu = s.Id_NhanHieu,
            //         };
            //var kbs = kb.ToList();
            //return  kbs.Except(kbs.GroupBy(i => i.Id)
            //                                 .Select(ss => ss.FirstOrDefault()))
            //                                .ToList();
        }
        [HttpGet("timnangcao")]
        public async Task<ActionResult<IEnumerable<SanPhamLoaiThuongHieu>>> TimNangCao(TimKiemNangCao nangCao)
        {

            List<SanPhamLoaiThuongHieu> list = new List<SanPhamLoaiThuongHieu>();

            return list;
        }

    }
}
