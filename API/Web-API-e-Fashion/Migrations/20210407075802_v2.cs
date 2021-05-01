﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HinhAnh",
                table: "Items",
                newName: "NameHinhAnh");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "SanPhamThietKes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "SanPhams",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Items",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "SanPhamThietKes");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "NameHinhAnh",
                table: "Items",
                newName: "HinhAnh");
        }
    }
}