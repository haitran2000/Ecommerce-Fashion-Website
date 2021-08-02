using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
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
        public async Task<ActionResult<IEnumerable<HoaDon>>> HoaDons()
        {
            return await _context.HoaDons.ToListAsync();
        }

        public decimal SPjoinSPBTTraVeGia(int IdThamSo)
        {

            SanPham kb = (SanPham)(from spbt in _context.SanPhamBienThes
                                   join sp in _context.SanPhams
                                   on spbt.Id_SanPham equals sp.Id
                                   select new SanPham()
                                   {
                                       Id = (int)spbt.Id,
                                       Gia = sp.Gia,
                                   }).First(s => s.Id == IdThamSo);

            return (decimal)kb.Gia;



        }

        public class ChiTietHoaDonSanPhamBienTheViewModel
        {
            public int IdCTHD { get; set; }
            public int SoLuong { get; set; }
            public string TenSanPham { get; set; }
            public string HinhAnh { get; set; }
            public decimal Gia { get; set; }
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
                         Gia = (decimal)sp.Gia,
                         SoLuong = cthd.Soluong,
                         ThanhTien = cthd.ThanhTien,
                         Id_HoaDon = (int)cthd.Id_HoaDon,
                         TenMau = mau.MaMau,
                         TenSize = size.TenSize,

                     };
            return await kb.Where(s => s.Id_HoaDon == id).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<HoaDon>> TaoHoaDon(HoaDon hd)
        {
            HoaDon hoaDon = new HoaDon()
            {
                GhiChi = hd.GhiChi,
                Id_User = hd.Id_User,
                NgayTao = DateTime.Now,
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
                try{
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
                    CTHD.ThanhTien = SPjoinSPBTTraVeGia((int)cthd.Id_SanPhamBienThe) * cthd.Soluong;
                    TongTien = TongTien + CTHD.ThanhTien;
                    ListCTHD.Add(CTHD);
                    _context.ChiTietHoaDons.Add(CTHD);
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                   
                }
              

            };
            hoaDonTest.TongTien = TongTien;
            _context.HoaDons.Update(hoaDonTest);
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
       public static string basePath = "D:\\API-CHUNG\\API-CHUNG\\Web-API-e-Fashion\\Template\\OrderTemplate.xlsx";
        [HttpGet("cc/{Id}")]
        public IActionResult DownloadFile(int Id)
        {
           GenerateOrderAsync(Id);

            return  File(System.IO.File.ReadAllBytes("D:\\API-CHUNG\\API-CHUNG\\Web-API-e-Fashion\\Template\\OrderTemplate.xlsx"), "application/*");

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
            public string DiaChi { get; set; }
            public string SDT { get; set; }
            public int IDHoaDon { get; set; }
            public DateTime NgayTao { get; set; }
            public string GhiChu { get; set; }
            public string FullName { get; set; }
            public decimal TongTien { get; set; }
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


                var orderusers = from hd in  _context.HoaDons
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
                                     GhiChu = hd.GhiChi
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
                             Gia = (decimal)sp.Gia,
                             SoLuong = cthd.Soluong,
                             ThanhTien = cthd.ThanhTien,
                             Id_HoaDon = (int)cthd.Id_HoaDon,
                             TenMau = mau.MaMau,
                             TenSize = size.TenSize,
                         };

                 var kbs=  kb.Where(s => s.Id_HoaDon == orderId).ToList();
                foreach (var orderDetail in kbs)
                {
                    // Cell 1, Carton Count
                    sheet.Cells[rowIndex, 1].Value = count.ToString();
                    // Cell 2, Order Number (Outline around columns 2-7 make it look like 1 column)
                    sheet.Cells[rowIndex, 2].Value = orderDetail.TenSanPham;
                    // Cell 8, Weight in LBS (convert KG to LBS, and rounding to whole number)
                    sheet.Cells[rowIndex, 3].Value = orderDetail.SoLuong.ToString();

                    sheet.Cells[rowIndex, 4].Value = orderDetail.Gia.ToString("N0");
                    sheet.Cells[rowIndex, 5].Value = (orderDetail.Gia * orderDetail.SoLuong).ToString("N0");
                    // Increment Row Counter
                    rowIndex++;
                    count++;
                }
                double total = (double)(kb.Sum(x => x.SoLuong * x.Gia));
                sheet.Cells[24, 5].Value = total.ToString("N0");

                var numberWord = "Thành tiền (viết bằng chữ): " + NumberHelper.ToString(total);
                sheet.Cells[26, 1].Value = numberWord;

                var date = orderuser.NgayTao;
                sheet.Cells[28, 3].Value = "Ngày " + date.Day + " tháng " + date.Month + " năm " + date.Year;


               package.SaveAs(new FileInfo(fullPath));

            

         

        }

    }
}




