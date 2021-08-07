using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class Upats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
