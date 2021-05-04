using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSanPham_SanPhams_SanPhamId",
                table: "ImageSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham");

            migrationBuilder.RenameTable(
                name: "ImageSanPham",
                newName: "imageSanPhams");

            migrationBuilder.RenameIndex(
                name: "IX_ImageSanPham_SanPhamId",
                table: "imageSanPhams",
                newName: "IX_imageSanPhams_SanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imageSanPhams",
                table: "imageSanPhams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imageSanPhams_SanPhams_SanPhamId",
                table: "imageSanPhams",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageSanPhams_SanPhams_SanPhamId",
                table: "imageSanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_imageSanPhams",
                table: "imageSanPhams");

            migrationBuilder.RenameTable(
                name: "imageSanPhams",
                newName: "ImageSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_imageSanPhams_SanPhamId",
                table: "ImageSanPham",
                newName: "IX_ImageSanPham_SanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSanPham_SanPhams_SanPhamId",
                table: "ImageSanPham",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
