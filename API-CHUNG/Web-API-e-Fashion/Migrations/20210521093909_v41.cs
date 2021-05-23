using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "Id_SanPham",
                table: "ChiTietHoaDons",
                newName: "Id_SanPhamBienThe");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_Id_SanPhamBienThe");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietHoaDons",
                column: "Id_SanPhamBienThe",
                principalTable: "SanPhamBienThes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "Id_SanPhamBienThe",
                table: "ChiTietHoaDons",
                newName: "Id_SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_Id_SanPhamBienThe",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_Id_SanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons",
                column: "Id_SanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
