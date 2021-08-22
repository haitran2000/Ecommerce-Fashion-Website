using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class pppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserLikes");
        }
    }
}
