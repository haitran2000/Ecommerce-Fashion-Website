using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class CountEntitysController : ControllerBase //thong ke theo mot Object hoac 1 so
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly DPContext _context;
        public CountEntitysController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }

        //Số lượng sản phẩm
        [Route("countproduct")]
        [HttpGet]
        public async Task<ActionResult<int>> GetProductCount()
        {
            int count = await (from not in _context.SanPhams
                               select not).CountAsync();      
            return count;
        }


        //Số lượng đơn hàng
        [Route("countorder")]
        [HttpGet]
        public async Task<ActionResult<int>> GetOrderCount()
        {
            int count = await (from not in _context.HoaDons
                               select not).CountAsync();
            return count;

        }


        //Số lượng user
        [Route("countuser")]
        [HttpGet]
        public async Task<ActionResult<int>> GetUserCount()
        {
            int count = await (from not in _context.AppUsers
                               select not).CountAsync();      
            return count;
        }


        //Số lượng tiền thu về
        [Route("countmoney")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetMoneyCount()
        {
            var count = await (from not in _context.HoaDons
                               select not).ToListAsync();
            decimal TongTienTatCa = 0;
            foreach(HoaDon hd in count)
            {
                TongTienTatCa = TongTienTatCa + hd.TongTien;
            }
            return TongTienTatCa;
        }
        //Khách hàng mua nhiều nhất
        [HttpGet("getkhachhangmuanhieunhat")]
        public async Task<ActionResult<KhachHangMuaNhieuNhat>> GetKhachHangMuaNhieuNhat()
        {
            string sql = @"select AspNetUsers.FirstName+' '+AspNetUsers.LastName as 'Fullname',sum(TongTien) as'Tong tien'
                            from ChiTietHoaDons
                            inner join HoaDons
                            on HoaDons.Id = ChiTietHoaDons.Id_HoaDon
                            inner join AspNetUsers
                            on HoaDons.Id_User = AspNetUsers.Id
                            group by (AspNetUsers.FirstName+' '+AspNetUsers.LastName)";
            var khachHang = new KhachHangMuaNhieuNhat();
            try
            {
                SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString());
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(sql, connection);
                await connection.OpenAsync();
                reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        khachHang.Id_User = (string)reader["Fullname"];
                        khachHang.TongTienDaChiTieu = (decimal)reader["Tong tien"];
                    }
                }
                await connection.CloseAsync();

            }
            catch (Exception ex)
            {

            }
            return khachHang;
        }
        //Sản phẩm bán chạy nhất
        [HttpGet("getsanphambanchay")]
        public async Task<ActionResult<TenSanPham>> GetSanPhamBanChayNhatAsync()
        {
            string sql = @"	select Top(1)Ten, sum(ChiTietHoaDons.Soluong) as'Số sản phẩm bán được'
                        from SanPhams
                        inner join SanPhamBienThes
                        on SanPhams.Id = SanPhamBienThes.Id_SanPham
                        inner join ChiTietHoaDons
						on ChiTietHoaDons.Id_SanPhamBienThe = SanPhamBienThes.Id
						group by Ten
						order by sum(Soluong) desc
                        ";
            //var d = await _context.SanPhams.FromSqlRaw(sql).ToListAsync();
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var tenSP = new TenSanPham();
            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (await reader.ReadAsync())
                    {
                        tenSP.TenSP = (string)reader["Ten"];
                        tenSP.SoSanPhamBanDuoc = (int)reader["Số sản phẩm bán được"];
                    }
                }           
             
                cnn.Close();
            }
            catch(Exception ex)
            {

            };
          
            return tenSP;
          
          
        }


       

    }

}
