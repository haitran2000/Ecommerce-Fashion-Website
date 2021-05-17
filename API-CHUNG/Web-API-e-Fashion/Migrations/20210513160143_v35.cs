using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageSanPhamBienThes");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "SanPhamBienThes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "SanPhamBienThes");

            migrationBuilder.CreateTable(
                name: "ImageSanPhamBienThes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_SanPhamBienThe = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                column: "Id_SanPhamBienThe");
        }
    }
}
