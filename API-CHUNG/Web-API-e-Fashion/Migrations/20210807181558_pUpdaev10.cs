using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_e_Fashion.Migrations
{
    public partial class pUpdaev10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserComment");

            migrationBuilder.DropTable(
                name: "UserLike");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserComment",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdAppUser = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComment", x => new { x.IdSanPham, x.IdAppUser });
                    table.ForeignKey(
                        name: "FK_UserComment_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComment_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLike",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdAppUser = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLike", x => new { x.IdSanPham, x.IdAppUser });
                    table.ForeignKey(
                        name: "FK_UserLike_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLike_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_IdUser",
                table: "UserComment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_IdUser",
                table: "UserLike",
                column: "IdUser");
        }
    }
}
