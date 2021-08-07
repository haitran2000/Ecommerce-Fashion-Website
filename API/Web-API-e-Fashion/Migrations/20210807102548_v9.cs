using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoTienGiam",
                table: "MaGiamGias",
                newName: "SoPhanTramGiam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoPhanTramGiam",
                table: "MaGiamGias",
                newName: "SoTienGiam");
        }
    }
}
