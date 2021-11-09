using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FkAppUser_NguoiThem",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_FkAppUser_NguoiThem",
                table: "Blogs",
                column: "FkAppUser_NguoiThem");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_FkAppUser_NguoiThem",
                table: "Blogs",
                column: "FkAppUser_NguoiThem",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_FkAppUser_NguoiThem",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_FkAppUser_NguoiThem",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "FkAppUser_NguoiThem",
                table: "Blogs");
        }
    }
}
