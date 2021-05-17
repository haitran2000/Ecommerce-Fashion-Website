using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_User_UserID",
                table: "HoaDons");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "HoaDons",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_UserID",
                table: "HoaDons",
                newName: "IX_HoaDons_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HoaDons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "HoaDons",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons",
                newName: "IX_HoaDons_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "HoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChiChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDayDu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    Update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    token_reset_pass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_IdUser",
                table: "TaiKhoans",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_User_UserID",
                table: "HoaDons",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
