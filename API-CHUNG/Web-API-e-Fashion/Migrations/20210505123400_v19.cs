using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TaiKhoans");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TaiKhoans",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TaiKhoans");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TaiKhoans",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TaiKhoans",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
