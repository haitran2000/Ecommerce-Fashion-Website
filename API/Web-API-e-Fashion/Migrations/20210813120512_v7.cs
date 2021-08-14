using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_NhaCungCap",
                table: "PhieuNhapHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapHangs_Id_NhaCungCap",
                table: "PhieuNhapHangs",
                column: "Id_NhaCungCap");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapHangs_NhaCungCaps_Id_NhaCungCap",
                table: "PhieuNhapHangs",
                column: "Id_NhaCungCap",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapHangs_NhaCungCaps_Id_NhaCungCap",
                table: "PhieuNhapHangs");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhapHangs_Id_NhaCungCap",
                table: "PhieuNhapHangs");

            migrationBuilder.DropColumn(
                name: "Id_NhaCungCap",
                table: "PhieuNhapHangs");
        }
    }
}
