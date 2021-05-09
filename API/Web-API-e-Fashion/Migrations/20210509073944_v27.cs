using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiaSanPhams_MauSacs_MauSacId",
                table: "GiaSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_Loais_CategoryId",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Loais_IdLoai",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_MauSacs_CategoryId",
                table: "MauSacs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MauSacs");

            migrationBuilder.DropColumn(
                name: "IDMau",
                table: "GiaSanPhams");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "GiaSanPhams");

            migrationBuilder.DropColumn(
                name: "IdSize",
                table: "GiaSanPhams");

            migrationBuilder.RenameColumn(
                name: "IdLoai",
                table: "Sizes",
                newName: "LoaiId");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_IdLoai",
                table: "Sizes",
                newName: "IX_Sizes_LoaiId");

            migrationBuilder.RenameColumn(
                name: "IdLoai",
                table: "MauSacs",
                newName: "LoaiId");

            migrationBuilder.RenameColumn(
                name: "MauSacId",
                table: "GiaSanPhams",
                newName: "MauId");

            migrationBuilder.RenameIndex(
                name: "IX_GiaSanPhams_MauSacId",
                table: "GiaSanPhams",
                newName: "IX_GiaSanPhams_MauId");

            migrationBuilder.CreateIndex(
                name: "IX_MauSacs_LoaiId",
                table: "MauSacs",
                column: "LoaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaSanPhams_MauSacs_MauId",
                table: "GiaSanPhams",
                column: "MauId",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_Loais_LoaiId",
                table: "MauSacs",
                column: "LoaiId",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Loais_LoaiId",
                table: "Sizes",
                column: "LoaiId",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiaSanPhams_MauSacs_MauId",
                table: "GiaSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_Loais_LoaiId",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Loais_LoaiId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_MauSacs_LoaiId",
                table: "MauSacs");

            migrationBuilder.RenameColumn(
                name: "LoaiId",
                table: "Sizes",
                newName: "IdLoai");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_LoaiId",
                table: "Sizes",
                newName: "IX_Sizes_IdLoai");

            migrationBuilder.RenameColumn(
                name: "LoaiId",
                table: "MauSacs",
                newName: "IdLoai");

            migrationBuilder.RenameColumn(
                name: "MauId",
                table: "GiaSanPhams",
                newName: "MauSacId");

            migrationBuilder.RenameIndex(
                name: "IX_GiaSanPhams_MauId",
                table: "GiaSanPhams",
                newName: "IX_GiaSanPhams_MauSacId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MauSacs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDMau",
                table: "GiaSanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "GiaSanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSize",
                table: "GiaSanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MauSacs_CategoryId",
                table: "MauSacs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaSanPhams_MauSacs_MauSacId",
                table: "GiaSanPhams",
                column: "MauSacId",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_Loais_CategoryId",
                table: "MauSacs",
                column: "CategoryId",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Loais_IdLoai",
                table: "Sizes",
                column: "IdLoai",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
