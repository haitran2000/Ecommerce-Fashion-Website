using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ServerToClientModels;
using Web_API_e_Fashion.SignalRModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase //thong ke theo List<Object>
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly DPContext _context;
        public DashboardController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
        [HttpGet("home")]
        public IActionResult GetHome()
        {
            return new OkObjectResult(new { Message = "This is secure data!" });
        }

        [HttpGet("thongkethang")]
        public async Task<ActionResult<IEnumerable<ThangRevenue>>> GetDoanhSoThangasync()
        {
         
            var sells = await _context.HoaDons
             .GroupBy(a => a.NgayTao.Date.Month)
                 .Select(a => new ThangRevenue { Revenues = a.Sum(b => b.TongTien), Month = a.Key.ToString()  })
                .OrderBy(a => a.Revenues)
                 .ToListAsync();
     
            return sells;

        }

        [HttpPost("thongkengaytheothang")]
        public async Task<ActionResult<IEnumerable<NgayRevenue>>> GetDoanhSoNgayTheoThangasync([FromForm]string month)
        {
       
            var sells = await _context.HoaDons
               .GroupBy(a => a.NgayTao.Date)
                   .Select(a => new NgayRevenue { Revenues = a.Sum(b => b.TongTien), Ngay = a.Key.Date })
                  .OrderBy(a => a.Revenues)
                  .Where(s=>s.Ngay.Month == int.Parse(month))
                   .ToListAsync();
         
            return sells;
        }

        



        //Thống kê số sản phẩm số lần xuất hiện trong đơn hàng
        [HttpGet("solanxuathientrongdonhang")]
        public async Task<ActionResult<IEnumerable<TenSPSoLanXuatHienTrongDonHang>>> GetSoLanXuatHienTrongDonHang()
        {
            var sql = @"select SanPhams.Ten, sum(ChiTietHoaDons.Soluong) as 'Số lần tồn tại trong đơn hàng'
                        from SanPhams
                        inner join SanPhamBienThes
                        on SanPhams.Id = SanPhamBienThes.Id_SanPham
                        inner join ChiTietHoaDons
                        on SanPhamBienThes.Id = ChiTietHoaDons.Id_SanPhamBienThe
                        group by (SanPhams.Ten)
                        order by sum(ChiTietHoaDons.Soluong) desc";
         
            var solanxuathiens = new List<TenSPSoLanXuatHienTrongDonHang>();
            try
            {
                SqlConnection conn = new SqlConnection(_context.Database.GetConnectionString());
              
              
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataReader reader;
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while(await reader.ReadAsync())
                    {
                        solanxuathiens.Add(new TenSPSoLanXuatHienTrongDonHang() { TenSP= (string)reader["Ten"],SoLanXuatHienTrongDonHang= (int)reader["Số lần tồn tại trong đơn hàng"] });
                    }
                }
                await conn.CloseAsync();
            }
            catch(Exception ex)
            {

            }
            return solanxuathiens;
        }
        //Sản phẩm bán lợi nhuận nhất
        [HttpGet("sanphamloinhattop")]
        public async Task<ActionResult<IEnumerable<TenSanPhamDoanhSo>>> Top10SanPhamLoiNhats()
        {
            string sql = @"select Top(10)Ten, sum(ChiTietHoaDons.ThanhTien) as'Doanh thu cao nhất'
                        from SanPhams
                        inner join SanPhamBienThes
                        on SanPhams.Id = SanPhamBienThes.Id_SanPham
                        inner join ChiTietHoaDons
						on ChiTietHoaDons.Id_SanPhamBienThe = SanPhamBienThes.Id
						group by Ten
						order by sum(ThanhTien) desc";
            SqlConnection conn = new SqlConnection(_context.Database.GetConnectionString());
            List<TenSanPhamDoanhSo> tenspdss = new List<TenSanPhamDoanhSo>();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {
                        tenspdss.Add(new TenSanPhamDoanhSo() { TenSP = (string)reader["Ten"], DoanhSoCaoNhat = (decimal)reader["Doanh thu cao nhất"] });
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return tenspdss;
        }

    }
}

