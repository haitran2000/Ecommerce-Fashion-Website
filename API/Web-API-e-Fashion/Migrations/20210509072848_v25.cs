using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThaiSanPham",
                table: "SanPhams");

            migrationBuilder.RenameColumn(
                name: "TrangThaiHoatDong",
                table: "SanPhams",
                newName: "TrangThaiSanPhamThietKe");

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiHienThi",
                table: "SanPhams",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThaiHienThi",
                table: "SanPhams");

            migrationBuilder.RenameColumn(
                name: "TrangThaiSanPhamThietKe",
                table: "SanPhams",
                newName: "TrangThaiHoatDong");

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiSanPham",
                table: "SanPhams",
                type: "int",
                nullable: true);
        }
    }
}
