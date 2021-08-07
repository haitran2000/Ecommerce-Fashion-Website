using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamNu",
                table: "Loais");

            migrationBuilder.AddColumn<int>(
                name: "GioiTinh",
                table: "SanPhams",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "SanPhams");

            migrationBuilder.AddColumn<string>(
                name: "NamNu",
                table: "Loais",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
