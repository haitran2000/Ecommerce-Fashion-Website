using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "HinhAnh",
                table: "SanPhams",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Categories",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Imagename",
                table: "Brands",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "SanPhams",
                newName: "HinhAnh");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Categories",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Brands",
                newName: "Imagename");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Categories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Brands",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
