using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkBlogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageBlogs_Blogs_FkBlogId",
                        column: x => x.FkBlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageBlogs_FkBlogId",
                table: "ImageBlogs",
                column: "FkBlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageBlogs");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.RenameColumn(
                name: "SoTienGiam",
                table: "MaGiamGias",
                newName: "SoPhanTramGiam");

            migrationBuilder.RenameColumn(
                name: "GiaBan",
                table: "ChiTietHoaDons",
                newName: "Gia");

            migrationBuilder.AddColumn<string>(
                name: "DaLayTien",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
