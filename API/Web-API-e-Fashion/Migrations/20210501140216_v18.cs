using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_BillID",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Users_UserID",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_BillID",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "AmountOrder",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "BillID",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ThuongHieus",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Loais",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "TotalBill",
                table: "HoaDons",
                newName: "TongTien");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "HoaDons",
                newName: "GhiChi");

            migrationBuilder.RenameColumn(
                name: "DateOrder",
                table: "HoaDons",
                newName: "NgayTao");

            migrationBuilder.RenameColumn(
                name: "TotalItem",
                table: "ChiTietHoaDons",
                newName: "ThanhTien");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ChiTietHoaDons",
                newName: "Soluong");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "HoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HoaDonId",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Users_UserID",
                table: "HoaDons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Users_UserID",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "ThuongHieus",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "Loais",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TongTien",
                table: "HoaDons",
                newName: "TotalBill");

            migrationBuilder.RenameColumn(
                name: "NgayTao",
                table: "HoaDons",
                newName: "DateOrder");

            migrationBuilder.RenameColumn(
                name: "GhiChi",
                table: "HoaDons",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "ChiTietHoaDons",
                newName: "TotalItem");

            migrationBuilder.RenameColumn(
                name: "Soluong",
                table: "ChiTietHoaDons",
                newName: "ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "HoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOrder",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillID",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_BillID",
                table: "ChiTietHoaDons",
                column: "BillID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_BillID",
                table: "ChiTietHoaDons",
                column: "BillID",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Users_UserID",
                table: "HoaDons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
