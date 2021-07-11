using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSanPhams_SanPhams_IdSanPham",
                table: "ImageSanPhams");

            migrationBuilder.AlterColumn<int>(
                name: "IdSanPham",
                table: "ImageSanPhams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSanPhams_SanPhams_IdSanPham",
                table: "ImageSanPhams",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSanPhams_SanPhams_IdSanPham",
                table: "ImageSanPhams");

            migrationBuilder.AlterColumn<int>(
                name: "IdSanPham",
                table: "ImageSanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSanPhams_SanPhams_IdSanPham",
                table: "ImageSanPhams",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
