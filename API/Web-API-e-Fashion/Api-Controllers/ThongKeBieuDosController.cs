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
    public class ThongKeBieuDosController : ControllerBase //thong ke theo List<Object>
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly DPContext _context;
        public ThongKeBieuDosController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
      /// <summary>
      /// Biểu đồ liên quan đến vấn đề bán hàng của shop
      /// </summary>
      /// <returns></returns>

        [HttpGet("topthongkethang")]
        public async Task<ActionResult<IEnumerable<ThangRevenue>>> GetDoanhSoThangasync()
        {
         
            var sells = await _context.HoaDons.Where(s => s.TrangThai == 2)
             .GroupBy(a => a.NgayTao.Date.Month)
                 .Select(a => new ThangRevenue { Revenues = a.Sum(b => b.TongTien), Month = a.Key.ToString()  })
                .OrderBy(a => a.Revenues)
                 .ToListAsync();
     
            return sells;

        }

        [HttpPost("topthongkengaytheothang")]
        public async Task<ActionResult<IEnumerable<NgayRevenue>>> GetDoanhSoNgayTheoThangasync([FromForm]string month)
        {
       
            var sells = await _context.HoaDons.Where(s=>s.TrangThai==2)
               .GroupBy(a => a.NgayTao.Date)
                   .Select(a => new NgayRevenue { Revenues = a.Sum(b => b.TongTien), Ngay = a.Key.Date })
                  .OrderBy(a => a.Revenues)
                  .Where(s=>s.Ngay.Month == int.Parse(month))
                   .ToListAsync();
         
            return sells;
        }

        



        //Thống kê số sản phẩm số lần xuất hiện trong đơn hàng (bán chạy)
        [HttpGet("topsolanxuathientrongdonhang")]
        public async Task<ActionResult<IEnumerable<TenSPSoLanXuatHienTrongDonHang>>> GetSoLanXuatHienTrongDonHang()
        {
            var sql = @"select top(10) SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau as 'Ten', sum(ChiTietHoaDons.Soluong) as 'Số lần tồn tại trong đơn hàng'
                        from SanPhams
                        inner join SanPhamBienThes
                        on SanPhams.Id = SanPhamBienThes.Id_SanPham
						inner join MauSacs
                        on SanPhamBienThes.Id_Mau = MauSacs.Id
                        inner join Sizes
                        on SanPhamBienThes.SizeId = Sizes.Id
                        inner join ChiTietHoaDons
                        on SanPhamBienThes.Id = ChiTietHoaDons.Id_SanPhamBienThe
                        inner join HoaDons
					    on ChiTietHoaDons.Id_HoaDon = HoaDons.Id
                         where HoaDons.TrangThai = 2
                        group by SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau ,SanPhamBienThes.SoLuongTon
                        order by sum(ChiTietHoaDons.Soluong) desc
                       ";
         
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
            catch(Exception )
            {

            }
            return solanxuathiens;
        }
        //Sản phẩm bán đạt lợi nhuận nhất trong top
        [HttpGet("topsanphamloinhattop")]
        public async Task<ActionResult<IEnumerable<TenSanPhamDoanhSo>>> Top10SanPhamLoiNhats()
        {
            string sql = @" select Top(10) SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau as 'Ten', cast(sum(ChiTietHoaDons.ThanhTien) as decimal(18,2)) as'ThanhTien'               
                    from SanPhams
                    inner join SanPhamBienThes
                    on SanPhams.Id = SanPhamBienThes.Id_SanPham
                    inner join MauSacs
                    on SanPhamBienThes.Id_Mau = MauSacs.Id
                    inner join Sizes
                    on SanPhamBienThes.SizeId = Sizes.Id
                    inner join ChiTietHoaDons
                    on SanPhamBienThes.Id_SanPham = ChiTietHoaDons.Id
                    inner join HoaDons
					on ChiTietHoaDons.Id_HoaDon = HoaDons.Id
                    where HoaDons.TrangThai = 2
                    group by(SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau)
                    order by cast(sum(ChiTietHoaDons.ThanhTien) as decimal(18,2)) desc
                    ";
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
                        tenspdss.Add(new TenSanPhamDoanhSo() { TenSP = (string)reader["Ten"], DoanhSoCaoNhat = (decimal)reader["ThanhTien"] });
                    }
                }


            }
            catch (Exception)
            {

            }
            return tenspdss;
        }
        //Tong so luong ban ra trong nam
        [HttpGet("topnhanhieubanchaynhattrongnam2021")]
        public async Task<ActionResult<IEnumerable<NhanHieuBanChayNhatTrongNam2021>>> GetNhanHieuBanChayNhatTrongNam2021()
        {
            string sql = @"select top(10) NhanHieus.Ten,sum(ChiTietHoaDons.Soluong) as'soluong'
                            from NhanHieus
                            inner join SanPhams
                            on NhanHieus.Id =SanPhams.Id_NhanHieu
                            inner join SanPhamBienThes
                            on SanPhamBienThes.Id_SanPham = SanPhams.Id
                            inner join ChiTietHoaDons 
                            on ChiTietHoaDons.Id_SanPhamBienThe = SanPhamBienThes.Id
                            inner join HoaDons
                            on HoaDons.Id = ChiTietHoaDons.Id_HoaDon
                            where DATEPART( YYYY,HoaDons.NgayTao)='2021' and HoaDons.TrangThai = 2
                            group by NhanHieus.Ten
                        ";
            //var d = await _context.SanPhams.FromSqlRaw(sql).ToListAsync();
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            List<NhanHieuBanChayNhatTrongNam2021> listNH = new List<NhanHieuBanChayNhatTrongNam2021>();
            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {
                        listNH.Add(new NhanHieuBanChayNhatTrongNam2021() { Ten = (string)reader["Ten"], SoLuong = (int)reader["soluong"] });

                    }
                }

                cnn.Close();
            }
            catch (Exception )
            {

            };

            return listNH;
        }
        //$sidebar-nav-link-active-bg; //131
        //Bien the dat doanh thu cao nhat
        [HttpGet("topdatasetbanratonkho")]
        public async Task<ActionResult<IEnumerable<DataSetBanRaTonKho>>> DataDataSetBanRaTonKho()
        {

            string sql = @"
                        select  SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau as 'Ten', cast(sum(SanPhams.GiaNhap*SanPhamBienThes.SoLuongTon) as decimal(18,2)) as'GiaTriTonKho' ,sum(ChiTietHoaDons.ThanhTien) as'GiaTriBanRa'               
                    from SanPhams
                    inner join SanPhamBienThes
                    on SanPhams.Id = SanPhamBienThes.Id_SanPham
                    inner join MauSacs
                    on SanPhamBienThes.Id_Mau = MauSacs.Id
                    inner join Sizes
                    on SanPhamBienThes.SizeId = Sizes.Id
                    inner join ChiTietHoaDons
                    on SanPhamBienThes.Id_SanPham = ChiTietHoaDons.Id
					inner join HoaDons
					on ChiTietHoaDons.Id_HoaDon = HoaDons.Id
					  where HoaDons.TrangThai = 2
                    group by(SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau)
                    order by sum(ChiTietHoaDons.ThanhTien) desc
                        ";
         
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var list = new List<DataSetBanRaTonKho>();

            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        list.Add(new DataSetBanRaTonKho() { Ten = (string)reader["Ten"],GiaTriTonKho = (decimal)reader["GiaTriTonKho"], GiaTriBanRa= (decimal)reader["GiaTriBanRa"] });
                    }
                }

                await cnn.CloseAsync();
            }
            catch (Exception )
            {

            };

            return list;
        }


        /// <summary>
        /// Biểu đồ liên quan tới vấn đề nhập hàng
        /// </summary>
        /// <returns></returns>
         
        [HttpGet("nhacungcaptongtien")]
        public async Task<ActionResult<IEnumerable<NhaCungCapTongTien>>> GetDoanhSoBans()
        {
            string sql = @"select NhaCungCaps.Ten, sum(PhieuNhapHangs.TongTien) as 'TongTien' 
	                      from PhieuNhapHangs, NhaCungCaps
	                      where PhieuNhapHangs.Id_NhaCungCap = NhaCungCaps.Id
	                      group by NhaCungCaps.Ten
                          order by sum(PhieuNhapHangs.TongTien) desc";
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var list = new List<NhaCungCapTongTien>();

            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        list.Add(new NhaCungCapTongTien() { Ten = (string)reader["Ten"], TongTien = (decimal)reader["TongTien"]});
                    }
                }

                await cnn.CloseAsync();
            }
            catch (Exception )
            {

            };

            return list;

        }


        [HttpGet("nhacungcapsoluong")]
        public async Task<ActionResult<IEnumerable<NhaCungCapSoLuong>>> GetNhaCungCapSoLuongs()
        {
            string sql = @"	select NhaCungCaps.Ten,sum(ChiTietPhieuNhapHangs.SoluongNhap) as 'So luong da nhap'
	from NhaCungCaps
	inner join PhieuNhapHangs
	on NhaCungCaps.Id = PhieuNhapHangs.Id_NhaCungCap
	inner join ChiTietPhieuNhapHangs
	on NhaCungCaps.Id = ChiTietPhieuNhapHangs.Id_PhieuNhapHang
	inner join SanPhamBienThes
	on SanPhamBienThes.Id = ChiTietPhieuNhapHangs.Id_PhieuNhapHang
	inner join SanPhams
	on SanPhams.Id = SanPhamBienThes.Id_SanPham
	group by NhaCungCaps.Ten ,SanPhams.GiaNhap
	order by sum(ChiTietPhieuNhapHangs.SoluongNhap) desc
";
            SqlConnection cnn;
            cnn = new SqlConnection(_context.Database.GetConnectionString());
            SqlDataReader reader;
            SqlCommand cmd;
            var list = new List<NhaCungCapSoLuong>();

            try
            {
                await cnn.OpenAsync();
                cmd = new SqlCommand(sql, cnn);
                reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        list.Add(new NhaCungCapSoLuong() { Ten = (string)reader["Ten"], SoLuong = (int)reader["So luong da nhap"] });
                    }
                }

                await cnn.CloseAsync();
            }
            catch (Exception )
            {

            };

            return list;

        }
    }
}

