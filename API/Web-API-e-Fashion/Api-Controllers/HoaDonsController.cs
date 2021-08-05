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
                         LoaiThanhToan = hd.LoaiThanhToan,
                         DaLayTien = hd.DaLayTien,
                         TrangThai = hd.TrangThai,
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
            if (hd.LoaiThanhToan == "Online")
            {
                hd.DaLayTien = "Rồi";
            }
            else
            {
                hd.DaLayTien = "Chưa";
            }
            HoaDon hoaDon = new HoaDon()
            {
                GhiChi = hd.GhiChi,
                DaLayTien=hd.DaLayTien,
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
                    CTHD.ThanhTien = SPjoinSPBTTraVeGia((int)cthd.Id_SanPhamBienThe) * cthd.Soluong;
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




