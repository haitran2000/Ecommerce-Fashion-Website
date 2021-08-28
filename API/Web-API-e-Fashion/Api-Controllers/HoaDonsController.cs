using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using OfficeOpenXml;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Helpers;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ServerToClientModels;
using Web_API_e_Fashion.SignalRModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public HoaDonsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonUser>>> HoaDons()
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
            return await kb.ToListAsync();
        }

        public decimal SPjoinSPBTTraVeGiaBan(int IdThamSo)
        {

            SanPham kb = (SanPham)(from spbt in _context.SanPhamBienThes
                                   join sp in _context.SanPhams
                                   on spbt.Id_SanPham equals sp.Id
                                   select new SanPham()
                                   {
                                       Id = (int)spbt.Id,
                                       GiaBan = sp.GiaBan,
                                   }).First(s => s.Id == IdThamSo);

            return (decimal)kb.GiaBan;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotHoaDon>> HoaDonDetailAsync(int id)
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
            return await hd.FirstOrDefaultAsync(s => s.Id == id);

        }

        [HttpPost]
        public async Task<ActionResult<HoaDon>> TaoHoaDon(HoaDon hd)
        {

            HoaDon hoaDon = new HoaDon()
            {
                GhiChu = hd.GhiChu,
                DaLayTien = hd.DaLayTien,
                Id_User = hd.Id_User,
                NgayTao = DateTime.Now,
                LoaiThanhToan = hd.LoaiThanhToan,
                TrangThai = hd.TrangThai,
            };
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();
            HoaDon hoaDonTest;
            hoaDonTest = await _context.HoaDons.FindAsync(hoaDon.Id);
            NotificationCheckout notification = new NotificationCheckout()
            {
                ThongBaoMaDonHang = hoaDonTest.Id,
            };

            _context.NotificationCheckouts.Add(notification);
            decimal TongTien = 0;
            List<ChiTietHoaDon> ListCTHD = new List<ChiTietHoaDon>();
            foreach (ChiTietHoaDon cthd in hd.ChiTietHoaDons)
            {
                try
                {
                    ChiTietHoaDon CTHD = new ChiTietHoaDon();
                    SanPhamBienThe spbt = await _context.SanPhamBienThes.FindAsync(cthd.Id_SanPhamBienThe);

                    spbt.SoLuongTon = spbt.SoLuongTon - cthd.Soluong;
                    if (spbt.SoLuongTon > 0)
                    {
                        _context.SanPhamBienThes.Update(spbt);
                    }
                    else
                    {
                        return BadRequest();
                    }
                    CTHD.Id_SanPhamBienThe = cthd.Id_SanPhamBienThe;
                    CTHD.Id_HoaDon = hoaDonTest.Id;
                    CTHD.Soluong = cthd.Soluong;
                    CTHD.ThanhTien = SPjoinSPBTTraVeGiaBan((int)cthd.Id_SanPhamBienThe) * cthd.Soluong;
                    TongTien = TongTien + CTHD.ThanhTien;
                    ListCTHD.Add(CTHD);
                    _context.ChiTietHoaDons.Add(CTHD);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            };
            hoaDonTest.TongTien = TongTien;
            _context.HoaDons.Update(hoaDonTest);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        //[HttpPut("suatrangthai/{id}")]
        //public IActionResult SuaTrangThai(int id, HoaDonUser hd)
        //{
        //    var kq =  _context.HoaDons.Find(id);
        //    kq.TrangThai = hd.TrangThai;
        //    kq.DaLayTien = hd.DaLayTien;
        //    _context.HoaDons.Update(kq);
        //   _context.SaveChangesAsync();
        //     _hubContext.Clients.All.BroadcastMessage();
        //    return Ok();
        //}
        [HttpPut("suatrangthai/{id}")]
        public async Task<IActionResult> SuaTrangThai(int id, HoaDonUser hd)
        {
            var kq = await _context.HoaDons.FindAsync(id);
            kq.TrangThai = hd.TrangThai;
            kq.DaLayTien = hd.DaLayTien;
            _context.HoaDons.Update(kq);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDons(int id)
        {
            ChiTietHoaDon[] cthd;
            cthd = _context.ChiTietHoaDons.Where(s => s.Id_HoaDon == id).ToArray();
            _context.ChiTietHoaDons.RemoveRange(cthd);
            HoaDon hd;
            hd = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(hd);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}




