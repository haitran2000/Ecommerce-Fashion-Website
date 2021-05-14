using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaSanPhams");

            migrationBuilder.DropColumn(
                name: "KhoiLuong",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "SanPhams");

            migrationBuilder.RenameColumn(
                name: "TrangThaiHienThi",
                table: "SanPhams",
                newName: "TrangThaiHoatDong");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "SanPhams",
                newName: "TrangThaiSanPham");

            migrationBuilder.RenameColumn(
                name: "ChatLieu",
                table: "SanPhams",
                newName: "Tag");

            migrationBuilder.AddColumn<string>(
                name: "Gia",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SanPhamBienThes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: true),
                    MauId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamBienThes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamBienThes_MauSacs_MauId",
                        column: x => x.MauId,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhamBienThes_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhamBienThes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamBienThes_MauId",
                table: "SanPhamBienThes",
                column: "MauId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamBienThes_SanPhamId",
                table: "SanPhamBienThes",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamBienThes_SizeId",
                table: "SanPhamBienThes",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhamBienThes");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "SanPhams");

            migrationBuilder.RenameColumn(
                name: "TrangThaiSanPham",
                table: "SanPhams",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "TrangThaiHoatDong",
                table: "SanPhams",
                newName: "TrangThaiHienThi");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "SanPhams",
                newName: "ChatLieu");

            migrationBuilder.AddColumn<int>(
                name: "KhoiLuong",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GiaSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauId = table.Column<int>(type: "int", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaSanPhams_MauSacs_MauId",
                        column: x => x.MauId,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiaSanPhams_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiaSanPhams_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaSanPhams_MauId",
                table: "GiaSanPhams",
                column: "MauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaSanPhams_SanPhamId",
                table: "GiaSanPhams",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaSanPhams_SizeId",
                table: "GiaSanPhams",
                column: "SizeId");
        }
    }
}
