using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_ThuongHieus_BrandId",
                table: "SanPhams");

            migrationBuilder.DropTable(
                name: "imageSanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThuongHieus",
                table: "ThuongHieus");

            migrationBuilder.RenameTable(
                name: "ThuongHieus",
                newName: "NhanHieus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanHieus",
                table: "NhanHieus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ImageSanPhamBienThes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_SanPhamBienThe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSanPhamBienThes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageSanPhamBienThes_SanPhamBienThes_Id_SanPhamBienThe",
                        column: x => x.Id_SanPhamBienThe,
                        principalTable: "SanPhamBienThes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageSanPhamBienThes_Id_SanPhamBienThe",
                table: "ImageSanPhamBienThes",
                column: "Id_SanPhamBienThe",
                unique: true,
                filter: "[Id_SanPhamBienThe] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_NhanHieus_BrandId",
                table: "SanPhams",
                column: "BrandId",
                principalTable: "NhanHieus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhanHieus_BrandId",
                table: "SanPhams");

            migrationBuilder.DropTable(
                name: "ImageSanPhamBienThes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanHieus",
                table: "NhanHieus");

            migrationBuilder.RenameTable(
                name: "NhanHieus",
                newName: "ThuongHieus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThuongHieus",
                table: "ThuongHieus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "imageSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_SanPhamBienThe = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imageSanPhams_SanPhamBienThes_Id_SanPhamBienThe",
                        column: x => x.Id_SanPhamBienThe,
                        principalTable: "SanPhamBienThes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imageSanPhams_Id_SanPhamBienThe",
                table: "imageSanPhams",
                column: "Id_SanPhamBienThe",
                unique: true,
                filter: "[Id_SanPhamBienThe] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_ThuongHieus_BrandId",
                table: "SanPhams",
                column: "BrandId",
                principalTable: "ThuongHieus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
