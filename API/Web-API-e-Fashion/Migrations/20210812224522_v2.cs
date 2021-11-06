using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhapHang_PhieuNhapHang_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhapHang_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapHang_AspNetUsers_NguoiLapPhieu",
                table: "PhieuNhapHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhapHang",
                table: "PhieuNhapHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhapHang",
                table: "ChiTietPhieuNhapHang");

            migrationBuilder.RenameTable(
                name: "PhieuNhapHang",
                newName: "PhieuNhapHangs");

            migrationBuilder.RenameTable(
                name: "ChiTietPhieuNhapHang",
                newName: "ChiTietPhieuNhapHangs");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhapHang_NguoiLapPhieu",
                table: "PhieuNhapHangs",
                newName: "IX_PhieuNhapHangs_NguoiLapPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhapHang_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHangs",
                newName: "IX_ChiTietPhieuNhapHangs_Id_SanPhamBienThe");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhapHang_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHangs",
                newName: "IX_ChiTietPhieuNhapHangs_Id_PhieuNhapHang");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhapHangs",
                table: "PhieuNhapHangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhapHangs",
                table: "ChiTietPhieuNhapHangs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhapHangs_PhieuNhapHangs_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHangs",
                column: "Id_PhieuNhapHang",
                principalTable: "PhieuNhapHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhapHangs_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHangs",
                column: "Id_SanPhamBienThe",
                principalTable: "SanPhamBienThes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapHangs_AspNetUsers_NguoiLapPhieu",
                table: "PhieuNhapHangs",
                column: "NguoiLapPhieu",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhapHangs_PhieuNhapHangs_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhapHangs_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhapHangs_AspNetUsers_NguoiLapPhieu",
                table: "PhieuNhapHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhapHangs",
                table: "PhieuNhapHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietPhieuNhapHangs",
                table: "ChiTietPhieuNhapHangs");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "NhaCungCaps");

            migrationBuilder.RenameTable(
                name: "PhieuNhapHangs",
                newName: "PhieuNhapHang");

            migrationBuilder.RenameTable(
                name: "ChiTietPhieuNhapHangs",
                newName: "ChiTietPhieuNhapHang");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhapHangs_NguoiLapPhieu",
                table: "PhieuNhapHang",
                newName: "IX_PhieuNhapHang_NguoiLapPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhapHangs_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHang",
                newName: "IX_ChiTietPhieuNhapHang_Id_SanPhamBienThe");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietPhieuNhapHangs_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHang",
                newName: "IX_ChiTietPhieuNhapHang_Id_PhieuNhapHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhapHang",
                table: "PhieuNhapHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietPhieuNhapHang",
                table: "ChiTietPhieuNhapHang",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhapHang_PhieuNhapHang_Id_PhieuNhapHang",
                table: "ChiTietPhieuNhapHang",
                column: "Id_PhieuNhapHang",
                principalTable: "PhieuNhapHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhapHang_SanPhamBienThes_Id_SanPhamBienThe",
                table: "ChiTietPhieuNhapHang",
                column: "Id_SanPhamBienThe",
                principalTable: "SanPhamBienThes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhapHang_AspNetUsers_NguoiLapPhieu",
                table: "PhieuNhapHang",
                column: "NguoiLapPhieu",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
