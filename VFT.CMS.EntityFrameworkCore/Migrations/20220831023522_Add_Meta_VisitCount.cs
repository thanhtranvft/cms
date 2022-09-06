using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VFT.CMS.EntityFrameworkCore.Migrations
{
    public partial class Add_Meta_VisitCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LinkTo",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ExcerptImage",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "vft_Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MetaValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vft_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vft_Meta_vft_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "vft_Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vft_VisitCount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vft_VisitCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vft_VisitCount_vft_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "vft_Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vft_Meta_MetaKey",
                table: "vft_Meta",
                column: "MetaKey");

            migrationBuilder.CreateIndex(
                name: "IX_vft_Meta_PostsId",
                table: "vft_Meta",
                column: "PostsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vft_VisitCount_PostsId",
                table: "vft_VisitCount",
                column: "PostsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vft_Meta");

            migrationBuilder.DropTable(
                name: "vft_VisitCount");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkTo",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExcerptImage",
                table: "vft_Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
