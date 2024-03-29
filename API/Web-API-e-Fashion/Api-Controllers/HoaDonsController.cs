﻿using Microsoft.AspNetCore.Mvc;
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
    public class HoaDonsController : Controller
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public HoaDonsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<HoaDon>>> HoaDons()
        //{
        //    return await _context.HoaDons.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonUser>>> AllHoaDons()
        {
            var kb = from hd in _context.HoaDons
                     join us in _context.AppUsers
                     on hd.Id_User equals us.Id
                     select new HoaDonUser()
                     {
                         GhiChu = hd.GhiChu,
                         Id = hd.Id,
                         NgayTao = hd.NgayTao,
                         TrangThai = hd.TrangThai,
                         TongTien = hd.TongTien,
                         FullName = us.FirstName + ' ' + us.LastName,

                     };
            return await kb.ToListAsync();
        }
        [HttpGet("admindetailorder/{id}")]
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
            catch (Exception)
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
        [HttpPost("hoadon/{id}")]
        public async Task<ActionResult> ChitietHoaDon(int id)
        {
            var resuft = _context.HoaDons.Where(d => d.Id == id).FirstOrDefault();
            resuft.User = _context.AppUsers.Where(d => d.Id == resuft.Id_User).FirstOrDefault();
            return Json(resuft);
        }

        [HttpPost("danhsachhoadon")]
        public async Task<ActionResult> ListHoaDon(User user)
        {
            var resuft = await _context.HoaDons.Where(d => d.Id_User == user.idUser).ToListAsync();
            return Json(resuft);
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
        [HttpPut("suatrangthai/{id}")]
        public async Task<IActionResult> SuaTrangThai(int id, HoaDonUser hd)
        {
            var kq = await _context.HoaDons.FindAsync(id);
            kq.TrangThai = hd.TrangThai;
            _context.HoaDons.Update(kq);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        public class User
        {
            public string idUser { get; set; }
        }
        public class ChiTietHoaDonSanPhamBienTheViewModel
        {
            public int IdCTHD { get; set; }
            public int SoLuong { get; set; }
            public string TenSanPham { get; set; }
            public string HinhAnh { get; set; }
            public decimal GiaBan { get; set; }
            public string TenMau { get; set; }
            public string TenSize { get; set; }
            public decimal ThanhTien { get; set; }
            public int Id_HoaDon { get; set; }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ChiTietHoaDonSanPhamBienTheViewModel>>> GetChiTietHoaDonSanPhamBienTheViewModel(int id)
        {
            var kb = from spbt in _context.SanPhamBienThes
                     join sp in _context.SanPhams
                     on spbt.Id_SanPham equals sp.Id
                     join cthd in _context.ChiTietHoaDons
                     on spbt.Id equals cthd.Id_SanPhamBienThe
                     join hd in _context.HoaDons
                     on cthd.Id_HoaDon equals hd.Id
                     join size in _context.Sizes
                     on spbt.SizeId equals size.Id
                     join mau in _context.MauSacs
                     on spbt.Id_Mau equals mau.Id


                     select new ChiTietHoaDonSanPhamBienTheViewModel()
                     {
                         IdCTHD = cthd.Id,
                         TenSanPham = sp.Ten,
                         //HinhAnh = spbt.ImagePath,
                         GiaBan = (decimal)sp.GiaBan,
                         SoLuong = cthd.Soluong,
                         ThanhTien = (decimal)cthd.ThanhTien,
                         Id_HoaDon = (int)cthd.Id_HoaDon,
                         TenMau = mau.MaMau,
                         TenSize = size.TenSize,

                     };
            return await kb.Where(s => s.Id_HoaDon == id).ToListAsync();
        }
        [HttpGet("magiamgia")]
        public async Task<ActionResult<IEnumerable<MaGiamGia>>> MaGiamGia()
        {
            return await _context.MaGiamGias.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<HoaDon>> TaoHoaDon(HoaDon hd)
        {
            HoaDon hoaDon = new HoaDon()
            {
                TrangThai = 0,
                GhiChu = hd.GhiChu,
                Id_User = hd.Id_User,
                NgayTao = DateTime.Now,
                Tinh = hd.Tinh,
                Huyen = hd.Huyen,
                Xa = hd.Xa,
                DiaChi = hd.DiaChi,
                TongTien = hd.TongTien
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
            var cart = _context.Carts.Where(d => d.UserID == hd.Id_User).ToList();
            List<ChiTietHoaDon> ListCTHD = new List<ChiTietHoaDon>();
            for (int i = 0; i < cart.Count; i++)
            {
                var thisSanPhamBienThe =  _context.SanPhamBienThes.Find(cart[i].Id_SanPhamBienThe);
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.Id_SanPham = cart[i].SanPhamId;
                cthd.Id_SanPhamBienThe = cart[i].Id_SanPhamBienThe;
                cthd.Id_HoaDon = hoaDonTest.Id;
                cthd.GiaBan = cart[i].Gia;
                cthd.Soluong = cart[i].SoLuong;
                cthd.ThanhTien = cart[i].Gia * cart[i].SoLuong;
                cthd.Size = cart[i].Size;
                cthd.Mau = cart[i].Mau;
                thisSanPhamBienThe.SoLuongTon = thisSanPhamBienThe.SoLuongTon - cart[i].SoLuong;
                _context.SanPhamBienThes.Update(thisSanPhamBienThe);
                _context.ChiTietHoaDons.Add(cthd);
                _context.Carts.Remove(cart[i]);
                await _context.SaveChangesAsync();

            };

            await _hubContext.Clients.All.BroadcastMessage();
            return Json(1);
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
        public static string basePath = "D:\\API-CHUNG\\API-CHUNG\\Web-API-e-Fashion\\Template\\OrderTemplate.xlsx";
        [HttpGet("cc/{Id}")]
        public IActionResult DownloadFile(int Id)
        {
            GenerateOrderAsync(Id);

            return File(System.IO.File.ReadAllBytes("D:\\API-CHUNG\\API-CHUNG\\Web-API-e-Fashion\\Template\\OrderTemplate.xlsx"), "application/*");

        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
        // If something fails or somebody calls invalid URI, throw error.


        public class HoaDonUser
        {
            public int Id { get; set; }
            public string DiaChi { get; set; }
            public string SDT { get; set; }
            public int IDHoaDon { get; set; }
            public DateTime NgayTao { get; set; }
            public string GhiChu { get; set; }
            public string FullName { get; set; }
            public decimal TongTien { get; set; }
            public int? TrangThai { get; set; }
        }

        private void GenerateOrderAsync(int orderId)
        {
            string filePath = "~/wwwroot/Excel/";
            string documentName = string.Format("Order-{0}-{1}.xlsx", orderId, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, documentName);


            //Instantiate the Excel application object


            //A existing workbook is opened.              

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileStream templateDocumentStream = System.IO.File.OpenRead(basePath);
            var package = new ExcelPackage(templateDocumentStream);

            // lấy ra sheet đầu tiên để thao tác
            ExcelWorksheet sheet = package.Workbook.Worksheets["TEDUOrder"];


            var orderusers = from hd in _context.HoaDons
                             join u in _context.AppUsers
                             on hd.Id_User equals u.Id
                             select new HoaDonUser()
                             {
                                 SDT = u.SDT,
                                 DiaChi = u.DiaChi,
                                 IDHoaDon = hd.Id,
                                 FullName = u.LastName + " " + u.FirstName,
                                 TongTien = hd.TongTien,
                                 NgayTao = hd.NgayTao,//https://localhost:44302/api/hoadons/cc/66
                                 GhiChu = hd.GhiChu
                             };
            var orderuser = orderusers.First(s => s.IDHoaDon == orderId);
            // Insert customer data into template

            sheet.Cells[4, 1].Value = "Tên khách hàng: " + orderuser.FullName;
            sheet.Cells[5, 1].Value = "Địa chỉ: " + orderuser.DiaChi;
            sheet.Cells[6, 1].Value = "Điện thoại: " + orderuser.SDT;
            // Start Row for Detail Rows
            int rowIndex = 9;

            // load order details
            var orderDetails = GetChiTietHoaDonSanPhamBienTheViewModel(orderId);
            int count = 1;

            var kb = from spbt in _context.SanPhamBienThes
                     join sp in _context.SanPhams
                     on spbt.Id_SanPham equals sp.Id
                     join cthd in _context.ChiTietHoaDons
                     on spbt.Id equals cthd.Id_SanPhamBienThe
                     join hd in _context.HoaDons
                     on cthd.Id_HoaDon equals hd.Id
                     join size in _context.Sizes
                     on spbt.SizeId equals size.Id
                     join mau in _context.MauSacs
                     on spbt.Id_Mau equals mau.Id


                     select new ChiTietHoaDonSanPhamBienTheViewModel()
                     {
                         IdCTHD = cthd.Id,
                         TenSanPham = sp.Ten,
                         //HinhAnh = spbt.ImagePath,
                         GiaBan = (decimal)sp.GiaBan,
                         SoLuong = cthd.Soluong,
                         ThanhTien = (decimal)cthd.ThanhTien,
                         Id_HoaDon = (int)cthd.Id_HoaDon,
                         TenMau = mau.MaMau,
                         TenSize = size.TenSize,
                     };

            var kbs = kb.Where(s => s.Id_HoaDon == orderId).ToList();
            foreach (var orderDetail in kbs)
            {
                // Cell 1, Carton Count
                sheet.Cells[rowIndex, 1].Value = count.ToString();
                // Cell 2, Order Number (Outline around columns 2-7 make it look like 1 column)
                sheet.Cells[rowIndex, 2].Value = orderDetail.TenSanPham;
                // Cell 8, Weight in LBS (convert KG to LBS, and rounding to whole number)
                sheet.Cells[rowIndex, 3].Value = orderDetail.SoLuong.ToString();

                sheet.Cells[rowIndex, 4].Value = orderDetail.GiaBan.ToString("N0");
                sheet.Cells[rowIndex, 5].Value = (orderDetail.GiaBan * orderDetail.SoLuong).ToString("N0");
                // Increment Row Counter
                rowIndex++;
                count++;
            }
            double total = (double)(kb.Sum(x => x.SoLuong * x.GiaBan));
            sheet.Cells[24, 5].Value = total.ToString("N0");

            var numberWord = "Thành tiền (viết bằng chữ): " + NumberHelper.ToString(total);
            sheet.Cells[26, 1].Value = numberWord;

            var date = orderuser.NgayTao;
            sheet.Cells[28, 3].Value = "Ngày " + date.Day + " tháng " + date.Month + " năm " + date.Year;


            package.SaveAs(new FileInfo(fullPath));





        }

    }
}




