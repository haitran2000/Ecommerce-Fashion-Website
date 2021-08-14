using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "PhieuNhapHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHangs_NhaCungCapId",
                table: "PhieuNhapHangs",
                column: "NhaCungCapId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapHangs_NhaCungCaps_NhaCungCapId",
                table: "PhieuNhapHangs",
                column: "NhaCungCapId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapHangs_NhaCungCaps_NhaCungCapId",
                table: "PhieuNhapHangs");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapHangs_NhaCungCapId",
                table: "PhieuNhapHangs");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "PhieuNhapHangs");
        }
    }
}
