using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ServerToClientModels;
using Wkhtmltopdf.NetCore;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFsController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly DPContext _context;
        public PDFsController(IGeneratePdf generatePd, DPContext context)
        {
            _generatePdf = generatePd;
            _context = context;

        }
        [HttpGet("allorder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var kb = from hd in _context.HoaDons
                     join us in _context.AppUsers
                     on hd.Id_User equals us.Id
                     select new HoaDonUser()
                     {

                         DaLayTien = hd.DaLayTien,
                         GhiChu = hd.GhiChu,
                         Id = hd.Id,
                         LoaiThanhToan = hd.LoaiThanhToan,
                         NgayTao = hd.NgayTao,
                         TrangThai = hd.TrangThai,
                         TongTien = hd.TongTien,
                         FullName = us.FirstName + ' ' + us.LastName,

                     };
           
            return await _generatePdf.GetPdf("Views/PDFs/GetAllOrder.cshtml", await kb.ToListAsync());
           
        }
        [HttpGet("orderdetail/{id}")]
        public async Task<IActionResult> GetOneOrder(int id)
        {
            string sql = @"		;with ProductImageTable
	                            as (
		                        SELECT ChiTietHoaDons.Id,SanPhams.Ten,ImageSanPhams.ImageName,Sizes.TenSize,MauSacs.MaMau,ChiTietHoaDons.Soluong,cast(SanPhams.GiaBan as decimal(18,2)) as'GiaBan',ChiTietHoaDons.ThanhTien,
										
		                        ROW_NUMBER() OVER (PARTITION BY ChiTietHoaDons.Id ORDER BY  ImageSanPhams.Id)  RowNum
		                        FROM SanPhams 
								LEFT JOIN ImageSanPhams 
								ON SanPhams.Id=ImageSanPhams.IdSanPham 
								inner join SanPhamBienThes
								on SanPhamBienThes.Id_SanPham = SanPhams.Id
								inner join Sizes
								on SanPhamBienThes.SizeId = Sizes.Id
								inner join MauSacs
								on SanPhamBienThes.Id_Mau = MauSacs.Id
								inner join ChiTietHoaDons
								on ChiTietHoaDons.Id_SanPhamBienThe = SanPhamBienThes.Id
								inner join HoaDons
								on HoaDons.Id = ChiTietHoaDons.Id_HoaDon
								where ChiTietHoaDons.Id_HoaDon = @value
		                          )
		                        SELECT Id,Ten,ImageName,TenSize,MaMau,Soluong,GiaBan,ThanhTien
		                        from ProductImageTable
	                            where
                                ProductImageTable.RowNum = 1
";
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var list = new List<NhieuChiTietHoaDon>();

            try
            {
                await cnn.OpenAsync();
                SqlParameter param = new SqlParameter();

                cmd = new SqlCommand(sql, cnn);
                param.ParameterName = "@value";
                param.Value = id;
                cmd.Parameters.Add(param);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        list.Add(new NhieuChiTietHoaDon()
                        {
                            Id = (int)reader["Id"],
                            Ten = (string)reader["Ten"],
                            Hinh = (string)reader["ImageName"],
                            GiaBan = (decimal)reader["GiaBan"],
                            MauSac = (string)reader["MaMau"],
                            Size = (string)reader["TenSize"],
                            SoLuong = (int)reader["SoLuong"],
                            ThanhTien = (decimal)reader["ThanhTien"]
                        });
                    }
                }

                await cnn.CloseAsync();
            }
            catch (Exception ex)
            {

            };



            var hd = from h in _context.HoaDons
                     join us in _context.AppUsers
                     on h.Id_User equals us.Id
                     select new MotHoaDon()
                     {
                         Id = h.Id,
                         FullName = us.LastName + ' ' + us.FirstName,
                         DiaChi = us.DiaChi,
                         Email = us.Email,
                         SDT = us.SDT,
                         hoaDon = new HoaDon()
                         {
                             DaLayTien = h.DaLayTien,
                             LoaiThanhToan = h.LoaiThanhToan,
                             Id_User = h.Id_User,
                             TongTien = h.TongTien,
                             GhiChu = h.GhiChu,
                             NgayTao = h.NgayTao,
                             TrangThai = h.TrangThai

                         },
                         chiTietHoaDons = list,

                     };
          
            return await _generatePdf.GetPdf("Views/PDFs/GetOrderDetail.cshtml", await hd.FirstOrDefaultAsync(s=>s.Id==id));
        }
        [HttpGet("allsanpham")]
        public async Task<IActionResult> GetAllSanPham()
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
                            TenNhaCungCap = (string)reader["NhaCungCapTen"],
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
       
            return await _generatePdf.GetPdf("Views/PDFs/GetAllSanPham.cshtml", List);
        } 

        [HttpGet("allphieunhap")]
        public async Task<IActionResult> GetAllNhaCungCap()
        {
            var kb = from ncc in _context.NhaCungCaps
                     join pnh in _context.PhieuNhapHangs
                     on ncc.Id equals pnh.Id_NhaCungCap
                     join us in _context.AppUsers
                     on pnh.NguoiLapPhieu equals us.Id
                     select new PhieuNhapHangNhaCungCap()
                     {
                         Id = pnh.Id,
                         GhiChu = pnh.GhiChu,
                         NgayTao = pnh.NgayTao,
                         NguoiLapPhieu = us.FirstName + ' ' + us.LastName,
                         SoChungTu = pnh.SoChungTu,
                         TenNhaCungCap = ncc.Ten,
                         TongTien = pnh.TongTien,
                     };
            return await _generatePdf.GetPdf("Views/PDFs/GetAllPhieuNhap.cshtml", kb);
        }

        [HttpGet("phieunhapdetail/{id}")]
        public async Task<IActionResult> Getphieunhapdetail(int id)
        {
            var listDetail = from spbt in _context.SanPhamBienThes
                             join sp in _context.SanPhams
                             on spbt.Id_SanPham equals sp.Id
                             join l in _context.Loais
                             on sp.Id_Loai equals l.Id
                             join m in _context.MauSacs
                             on spbt.Id_Mau equals m.Id
                             join s in _context.Sizes
                             on spbt.SizeId equals s.Id
                             join ctpn in _context.ChiTietPhieuNhapHangs
                             on spbt.Id equals ctpn.Id_SanPhamBienThe
                             select new TenSanPhamBienTheChiTietPhieuNhap()
                             {
                                 Id = spbt.Id,
                                 TenSanPhamBienTheMauSize = sp.Ten + " " + s.TenSize + " " + m.MaMau,
                                 GiaNhap = (decimal)sp.GiaNhap,
                                 SoluongNhap = ctpn.SoluongNhap,
                                 ThanhTienNhap = ctpn.ThanhTienNhap,
                                 Id_PhieuNhapHang = (int)ctpn.Id_PhieuNhapHang
                             };
            var kb = (from phieunhap in _context.PhieuNhapHangs
                      join us in _context.AppUsers
                      on phieunhap.NguoiLapPhieu equals us.Id
                      join ncc in _context.NhaCungCaps
                      on phieunhap.Id_NhaCungCap equals ncc.Id
                      select new PhieuNhapChiTietPhieuNhap()
                      {
                          Id = phieunhap.Id,
                          GhiChu = phieunhap.GhiChu,
                          NgayTao = phieunhap.NgayTao,
                          SoChungTu = phieunhap.SoChungTu,
                          TongTien = phieunhap.TongTien,
                          NguoiLapPhieu = us.FirstName + " " + us.LastName,
                          NhaCungCap = new NhaCungCap()
                          {
                              Id = ncc.Id,
                              Ten = ncc.Ten,
                              DiaChi = ncc.DiaChi,
                              ThongTin = ncc.ThongTin,
                              SDT = ncc.SDT,
                          },
                          ChiTietPhieuNhaps = (List<TenSanPhamBienTheChiTietPhieuNhap>)listDetail.Where(s => s.Id_PhieuNhapHang == id),

                      });
            return await _generatePdf.GetPdf("Views/PDFs/GetPhieuNhapDetail.cshtml", await kb.FirstOrDefaultAsync(s => s.Id == id));

        }
    }
}
