using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_AspNetUsers_IdUser",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_Id_HoaDon",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhanHieus_Id_NhanHieu",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_AspNetUsers_IdAppUser",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_SanPhams_IdSanPham",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_IdAppUser",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_SanPhams_IdSanPham",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.DropIndex(
                name: "IX_UserLikes_IdAppUser",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_IdAppUser",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_Id_NhanHieu",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_Id_HoaDon",
                table: "ChiTietHoaDons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IdAppUser",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "IdAppUser",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "TrangThaiHienThi",
                table: "UserComments");

            migrationBuilder.RenameTable(
                name: "Calendars",
                newName: "Calendar");

            migrationBuilder.RenameColumn(
                name: "LoaiThanhToan",
                table: "HoaDons",
                newName: "Xa");

            migrationBuilder.RenameIndex(
                name: "IX_Calendars_IdUser",
                table: "Calendar",
                newName: "IX_Calendar_IdUser");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserLikes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserLikes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "UserLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayComment",
                table: "UserComments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanHieuId",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Huyen",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tinh",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "ChiTietHoaDons",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Gia",
                table: "ChiTietHoaDons",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoaDonId",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_SanPham",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mau",
                table: "ChiTietHoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ChiTietHoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthHistories_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    Id_SanPhamBienThe = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_SanPhamBienThes_Id_SanPhamBienThe",
                        column: x => x.Id_SanPhamBienThe,
                        principalTable: "SanPhamBienThes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Identity = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekers_AspNetUsers_Id_Identity",
                        column: x => x.Id_Identity,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_AppUserId",
                table: "UserLikes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_AppUserId",
                table: "UserComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_NhanHieuId",
                table: "SanPhams",
                column: "NhanHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons",
                column: "Id_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_AuthHistories_IdentityId",
                table: "AuthHistories",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id_SanPhamBienThe",
                table: "Carts",
                column: "Id_SanPhamBienThe");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SanPhamId",
                table: "Carts",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_Id_Identity",
                table: "JobSeekers",
                column: "Id_Identity");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_AspNetUsers_IdUser",
                table: "Calendar",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId",
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
                name: "FK_SanPhams_NhanHieus_NhanHieuId",
                table: "SanPhams",
                column: "NhanHieuId",
                principalTable: "NhanHieus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_AspNetUsers_AppUserId",
                table: "UserComments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_AppUserId",
                table: "UserLikes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_AspNetUsers_IdUser",
                table: "Calendar");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhanHieus_NhanHieuId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_AspNetUsers_AppUserId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_AppUserId",
                table: "UserLikes");

            migrationBuilder.DropTable(
                name: "AuthHistories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.DropIndex(
                name: "IX_UserLikes_AppUserId",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_AppUserId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_NhanHieuId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "NgayComment",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "NhanHieuId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Huyen",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Tinh",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Id_SanPham",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Mau",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameTable(
                name: "Calendar",
                newName: "Calendars");

            migrationBuilder.RenameColumn(
                name: "Xa",
                table: "HoaDons",
                newName: "LoaiThanhToan");

            migrationBuilder.RenameIndex(
                name: "IX_Calendar_IdUser",
                table: "Calendars",
                newName: "IX_Calendars_IdUser");

            migrationBuilder.AddColumn<string>(
                name: "IdAppUser",
                table: "UserLikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdAppUser",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiHienThi",
                table: "UserComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "ChiTietHoaDons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendars",
                table: "Calendars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_IdAppUser",
                table: "UserLikes",
                column: "IdAppUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_IdAppUser",
                table: "UserComments",
                column: "IdAppUser");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Id_NhanHieu",
                table: "SanPhams",
                column: "Id_NhanHieu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Id_HoaDon",
                table: "ChiTietHoaDons",
                column: "Id_HoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_AspNetUsers_IdUser",
                table: "Calendars",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_Id_HoaDon",
                table: "ChiTietHoaDons",
                column: "Id_HoaDon",
                principalTable: "HoaDons",
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
                name: "FK_UserComments_AspNetUsers_IdAppUser",
                table: "UserComments",
                column: "IdAppUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_SanPhams_IdSanPham",
                table: "UserComments",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_IdAppUser",
                table: "UserLikes",
                column: "IdAppUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_SanPhams_IdSanPham",
                table: "UserLikes",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
