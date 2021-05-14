using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageSanPhamBienThes_Id_SanPhamBienThe",
                table: "ImageSanPhamBienThes");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSanPhamBienThes_Id_SanPhamBienThe",
                table: "ImageSanPhamBienThes",
                column: "Id_SanPhamBienThe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageSanPhamBienThes_Id_SanPhamBienThe",
                table: "ImageSanPhamBienThes");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSanPhamBienThes_Id_SanPhamBienThe",
                table: "ImageSanPhamBienThes",
                column: "Id_SanPhamBienThe",
                unique: true,
                filter: "[Id_SanPhamBienThe] IS NOT NULL");
        }
    }
}
