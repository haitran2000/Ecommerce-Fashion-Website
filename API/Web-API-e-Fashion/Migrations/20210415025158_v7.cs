using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Brands_BrandId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Categories_CategoryId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "Loai",
                table: "SanPhams");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Brands_BrandId",
                table: "SanPhams",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Categories_CategoryId",
                table: "SanPhams",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Brands_BrandId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_Categories_CategoryId",
                table: "SanPhams");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SanPhams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "SanPhams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Loai",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Brands_BrandId",
                table: "SanPhams",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_Categories_CategoryId",
                table: "SanPhams",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
