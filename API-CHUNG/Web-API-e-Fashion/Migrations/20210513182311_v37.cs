using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_SanPhamId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_AspNetUsers_IdentityId",
                table: "JobSeekers");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_Loais_LoaiId",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamBienThes_MauSacs_MauId",
                table: "SanPhamBienThes");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamBienThes_SanPhams_SanPhamId",
                table: "SanPhamBienThes");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Loais_CategoryId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhanHieus_BrandId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Loais_LoaiId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_BrandId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_CategoryId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "AuthHistories");

            migrationBuilder.RenameColumn(
                name: "LoaiId",
                table: "Sizes",
                newName: "Id_Loai");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_LoaiId",
                table: "Sizes",
                newName: "IX_Sizes_Id_Loai");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "SanPhams",
                newName: "NgayTao");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "SanPhams",
                newName: "Id_NhanHieu");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "SanPhams",
                newName: "NgayCapNhat");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "SanPhams",
                newName: "Id_Loai");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "SanPhamBienThes",
                newName: "Id_SanPham");

            migrationBuilder.RenameColumn(
                name: "MauId",
                table: "SanPhamBienThes",
                newName: "Id_Mau");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamBienThes_SanPhamId",
                table: "SanPhamBienThes",
                newName: "IX_SanPhamBienThes_Id_SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamBienThes_MauId",
                table: "SanPhamBienThes",
                newName: "IX_SanPhamBienThes_Id_Mau");

            migrationBuilder.RenameColumn(
                name: "LoaiId",
                table: "MauSacs",
                newName: "Id_Loai");

            migrationBuilder.RenameIndex(
                name: "IX_MauSacs_LoaiId",
                table: "MauSacs",
                newName: "IX_MauSacs_Id_Loai");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "JobSeekers",
                newName: "Id_Identity");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekers_IdentityId",
                table: "JobSeekers",
                newName: "IX_JobSeekers_Id_Identity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "HoaDons",
                newName: "Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons",
                newName: "IX_HoaDons_Id_User");

            migrationBuilder.RenameColumn(
                name: "SanPhamId",
                table: "ChiTietHoaDons",
                newName: "Id_SanPham");

            migrationBuilder.RenameColumn(
                name: "HoaDonId",
                table: "ChiTietHoaDons",
                newName: "Id_HoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_SanPhamId",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_Id_SanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_Id_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Id_Loai",
                table: "SanPhams",
                column: "Id_Loai");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Id_NhanHieu",
                table: "SanPhams",
                column: "Id_NhanHieu");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_Id_HoaDon",
                table: "ChiTietHoaDons",
                column: "Id_HoaDon",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons",
                column: "Id_SanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_AspNetUsers_Id_User",
                table: "HoaDons",
                column: "Id_User",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_AspNetUsers_Id_Identity",
                table: "JobSeekers",
                column: "Id_Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauSacs_Loais_Id_Loai",
                table: "MauSacs",
                column: "Id_Loai",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamBienThes_MauSacs_Id_Mau",
                table: "SanPhamBienThes",
                column: "Id_Mau",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamBienThes_SanPhams_Id_SanPham",
                table: "SanPhamBienThes",
                column: "Id_SanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Loais_Id_Loai",
                table: "SanPhams",
                column: "Id_Loai",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_NhanHieus_Id_NhanHieu",
                table: "SanPhams",
                column: "Id_NhanHieu",
                principalTable: "NhanHieus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Loais_Id_Loai",
                table: "Sizes",
                column: "Id_Loai",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_Id_HoaDon",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_AspNetUsers_Id_User",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_AspNetUsers_Id_Identity",
                table: "JobSeekers");

            migrationBuilder.DropForeignKey(
                name: "FK_MauSacs_Loais_Id_Loai",
                table: "MauSacs");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamBienThes_MauSacs_Id_Mau",
                table: "SanPhamBienThes");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamBienThes_SanPhams_Id_SanPham",
                table: "SanPhamBienThes");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Loais_Id_Loai",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhanHieus_Id_NhanHieu",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Loais_Id_Loai",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_Id_Loai",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_Id_NhanHieu",
                table: "SanPhams");

            migrationBuilder.RenameColumn(
                name: "Id_Loai",
                table: "Sizes",
                newName: "LoaiId");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_Id_Loai",
                table: "Sizes",
                newName: "IX_Sizes_LoaiId");

            migrationBuilder.RenameColumn(
                name: "NgayTao",
                table: "SanPhams",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "NgayCapNhat",
                table: "SanPhams",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Id_NhanHieu",
                table: "SanPhams",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "Id_Loai",
                table: "SanPhams",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "Id_SanPham",
                table: "SanPhamBienThes",
                newName: "SanPhamId");

            migrationBuilder.RenameColumn(
                name: "Id_Mau",
                table: "SanPhamBienThes",
                newName: "MauId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamBienThes_Id_SanPham",
                table: "SanPhamBienThes",
                newName: "IX_SanPhamBienThes_SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamBienThes_Id_Mau",
                table: "SanPhamBienThes",
                newName: "IX_SanPhamBienThes_MauId");

            migrationBuilder.RenameColumn(
                name: "Id_Loai",
                table: "MauSacs",
                newName: "LoaiId");

            migrationBuilder.RenameIndex(
                name: "IX_MauSacs_Id_Loai",
                table: "MauSacs",
                newName: "IX_MauSacs_LoaiId");

            migrationBuilder.RenameColumn(
                name: "Id_Identity",
                table: "JobSeekers",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSeekers_Id_Identity",
                table: "JobSeekers",
                newName: "IX_JobSeekers_IdentityId");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "HoaDons",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_Id_User",
                table: "HoaDons",
                newName: "IX_HoaDons_UserId");

            migrationBuilder.RenameColumn(
                name: "Id_SanPham",
                table: "ChiTietHoaDons",
                newName: "SanPhamId");

            migrationBuilder.RenameColumn(
                name: "Id_HoaDon",
                table: "ChiTietHoaDons",
                newName: "HoaDonId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_Id_HoaDon",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_HoaDonId");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "AuthHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_BrandId",
                table: "SanPhams",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_CategoryId",
                table: "SanPhams",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_SanPhamId",
                table: "ChiTietHoaDons",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_AspNetUsers_IdentityId",
                table: "JobSeekers",
                column: "IdentityId",
                principalTable: "AspNetUsers",
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
                name: "FK_SanPhamBienThes_MauSacs_MauId",
                table: "SanPhamBienThes",
                column: "MauId",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamBienThes_SanPhams_SanPhamId",
                table: "SanPhamBienThes",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Loais_CategoryId",
                table: "SanPhams",
                column: "CategoryId",
                principalTable: "Loais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_NhanHieus_BrandId",
                table: "SanPhams",
                column: "BrandId",
                principalTable: "NhanHieus",
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
    }
}
