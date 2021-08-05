using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_AspNetUsers_IdUser",
                table: "UserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_SanPhams_IdSanPham",
                table: "UserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_AspNetUsers_IdUser",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_SanPhams_IdSanPham",
                table: "UserLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment");

            migrationBuilder.RenameTable(
                name: "UserLike",
                newName: "UserLikes");

            migrationBuilder.RenameTable(
                name: "UserComment",
                newName: "UserComments");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_IdUser",
                table: "UserLikes",
                newName: "IX_UserLikes_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserComment_IdUser",
                table: "UserComments",
                newName: "IX_UserComments_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.CreateTable(
                name: "MaGiamGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTienGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaGiamGias", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_AspNetUsers_IdUser",
                table: "UserComments",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_SanPhams_IdSanPham",
                table: "UserComments",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_IdUser",
                table: "UserLikes",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_SanPhams_IdSanPham",
                table: "UserLikes",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_AspNetUsers_IdUser",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_SanPhams_IdSanPham",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_IdUser",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_SanPhams_IdSanPham",
                table: "UserLikes");

            migrationBuilder.DropTable(
                name: "MaGiamGias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments");

            migrationBuilder.RenameTable(
                name: "UserLikes",
                newName: "UserLike");

            migrationBuilder.RenameTable(
                name: "UserComments",
                newName: "UserComment");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_IdUser",
                table: "UserLike",
                newName: "IX_UserLike_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_IdUser",
                table: "UserComment",
                newName: "IX_UserComment_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment",
                columns: new[] { "IdSanPham", "IdAppUser" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_AspNetUsers_IdUser",
                table: "UserComment",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_SanPhams_IdSanPham",
                table: "UserComment",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_AspNetUsers_IdUser",
                table: "UserLike",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_SanPhams_IdSanPham",
                table: "UserLike",
                column: "IdSanPham",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
