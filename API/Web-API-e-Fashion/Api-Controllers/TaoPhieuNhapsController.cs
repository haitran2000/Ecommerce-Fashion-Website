using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ServerToClientModels;
using Web_API_e_Fashion.SignalRModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaoPhieuNhapsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public TaoPhieuNhapsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
        [HttpGet("nhacungcap/{id}")]
        public async Task<ActionResult<IEnumerable<NhaCungCap>>> GetAllNhaCungCaps()
        {
            return await _context.NhaCungCaps.ToListAsync();
        }

        [HttpGet("sanpham/{id}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetAllSanPhams(UploadNhaCungCap uploadNhaCungCap)
        {
            return await _context.SanPhams.ToListAsync();
        }
        [HttpGet("sanphambienthe")]
        public async Task<ActionResult<IEnumerable<SanPhamBienThe>>> GetAllSanPhamBienThe()
        {
            return await _context.SanPhamBienThes.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuNhapHang>>> GetAllPhieuNhap()
        {
            return await _context.PhieuNhapHangs.ToListAsync();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpPost("SanPhamNhaCungCap")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamNhaCungCaps(NhaCungCap ncc)
        {
          return await _context.SanPhams.Where(s => s.Id_NhaCungCap == ncc.Id).ToListAsync();
        }
        [HttpPost("NhaCungCap")]
        public async Task<ActionResult<NhaCungCap>> GetNhaCungCaps(NhaCungCap ncc)
        {
            return await _context.NhaCungCaps.FindAsync(ncc.Id);
        }
        [HttpPost("SanPhamBienTheMauSizeLoai")]
        public async Task<ActionResult<IEnumerable<SanPhamBienTheMauSizeLoai>>> GetTenSanPhamBienThe(SanPham sps)
        {
            var kb = from spbt in _context.SanPhamBienThes
                     join sp in _context.SanPhams.Where(s => s.Id==sps.Id)
                     on spbt.Id_SanPham equals sp.Id
                     join l in _context.Loais
                     on sp.Id_Loai equals l.Id
                     join m in _context.MauSacs
                     on spbt.Id_Mau equals m.Id
                     join s in _context.Sizes
                     on spbt.SizeId equals s.Id

                     select new SanPhamBienTheMauSizeLoai()
                     {
                         Id = spbt.Id,
                         TenSanPhamBienTheMauSize = sp.Ten + " " + l.Ten + " " + m.MaMau,
                         GiaNhap = (decimal)sp.GiaNhap,
                     };
            return await kb.ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> PostTaoPhieuNhap(UploadPhieuNhapHang uploadPhieuNhap)
        {
            PhieuNhapHang phieuNhap = new PhieuNhapHang()
            {
                NguoiLapPhieu = uploadPhieuNhap.NguoiLapPhieu,
                NgayTao = DateTime.Now,
                SoChungTu = RandomString(7),

            };
            _context.Add(phieuNhap);
            await _context.SaveChangesAsync();

            decimal TongTien = 0;
            var phieuNhapTest = await _context.PhieuNhapHangs.FindAsync(phieuNhap.Id);
            List<ChiTietPhieuNhapHang> listctpn = new List<ChiTietPhieuNhapHang>();
            foreach(var ctpnupload in uploadPhieuNhap.ChiTietPhieuNhaps)
            {
                ChiTietPhieuNhapHang ctpn = new ChiTietPhieuNhapHang();
                ctpn.Id_SanPhamBienThe = ctpnupload.Id_SanPhamBienThe;
                ctpn.SoluongNhap = (int)ctpnupload.SoluongNhap;
                ctpn.ThanhTienNhap = (decimal)(SPjoinSPBTTraVeGia((int)ctpnupload.Id_SanPhamBienThe) * ctpnupload.SoluongNhap);
                TongTien = TongTien + ctpn.ThanhTienNhap;
                listctpn.Add(ctpn);
                _context.ChiTietPhieuNhapHangs.Add(ctpn);
                await _context.SaveChangesAsync();
            }
            phieuNhapTest.TongTien = TongTien;
            _context.PhieuNhapHangs.Update(phieuNhapTest);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
            
        }

        public decimal SPjoinSPBTTraVeGia(int IdThamSo)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaoPhieuNhap()
        {

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaoPhieuNhap()
        {

            return Ok();
        }
    }
}
