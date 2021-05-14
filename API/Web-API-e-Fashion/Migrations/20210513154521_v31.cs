using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageSanPhams_SanPhams_SanPhamId",
                table: "imageSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_imageSanPhams_SanPhamId",
                table: "imageSanPhams");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "imageSanPhams",
                newName: "Id_SanPhamBienThe");

            migrationBuilder.AddColumn<string>(
                name: "ThongTin",
                table: "ThuongHieus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_imageSanPhams_Id_SanPhamBienThe",
                table: "imageSanPhams",
                column: "Id_SanPhamBienThe",
                unique: true,
                filter: "[Id_SanPhamBienThe] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_imageSanPhams_SanPhamBienThes_Id_SanPhamBienThe",
                table: "imageSanPhams",
                column: "Id_SanPhamBienThe",
                principalTable: "SanPhamBienThes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageSanPhams_SanPhamBienThes_Id_SanPhamBienThe",
                table: "imageSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_imageSanPhams_Id_SanPhamBienThe",
                table: "imageSanPhams");

            migrationBuilder.DropColumn(
                name: "ThongTin",
                table: "ThuongHieus");

            migrationBuilder.RenameColumn(
                name: "Id_SanPhamBienThe",
                table: "imageSanPhams",
                newName: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_imageSanPhams_SanPhamId",
                table: "imageSanPhams",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_imageSanPhams_SanPhams_SanPhamId",
                table: "imageSanPhams",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
