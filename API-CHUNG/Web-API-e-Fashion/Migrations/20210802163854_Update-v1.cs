using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class Updatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GhiChi",
                table: "HoaDons",
                newName: "Xa");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Huyen",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tinh",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "HoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiThanhToan",
                table: "HoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Gia",
                table: "ChiTietHoaDons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Id_SanPham",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mau",
                table: "ChiTietHoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ChiTietHoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    Id_SanPhamBienThe = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_SanPhamBienThes_Id_SanPhamBienThe",
                        column: x => x.Id_SanPhamBienThe,
                        principalTable: "SanPhamBienThes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons",
                column: "Id_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id_SanPhamBienThe",
                table: "Carts",
                column: "Id_SanPhamBienThe");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SanPhamId",
                table: "Carts",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons",
                column: "Id_SanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Huyen",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Tinh",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TrangThaiThanhToan",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Mau",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "Xa",
                table: "HoaDons",
                newName: "GhiChi");
        }
    }
}
