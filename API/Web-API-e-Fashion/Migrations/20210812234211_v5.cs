using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gia",
                table: "SanPhams",
                newName: "GiaBan");

            migrationBuilder.RenameColumn(
                name: "GhiChi",
                table: "HoaDons",
                newName: "GhiChu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiaBan",
                table: "SanPhams",
                newName: "Gia");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "HoaDons",
                newName: "GhiChi");
        }
    }
}
