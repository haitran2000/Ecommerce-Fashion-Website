using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class ThongKe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var ThongKe = @"go
	                        create proc [dbo].[GetThongKe](@fromDate datetime,@toDate datetime)
	                        as
	                        begin
		                        select o.NgayTao, sum(TongTien)  as Revenues
		                        from HoaDons o
		                        where o.NgayTao <= cast(@toDate as date) and o.NgayTao >= cast (@fromDate as date)
		                        group by o.NgayTao
	                        end";
            migrationBuilder.Sql(ThongKe);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
