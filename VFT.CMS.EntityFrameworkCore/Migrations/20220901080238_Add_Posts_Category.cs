using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VFT.CMS.EntityFrameworkCore.Migrations
{
    public partial class Add_Posts_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_vft_Posts_CategoryId",
                table: "vft_Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_vft_Category_ParentCategory",
                table: "vft_Category",
                column: "ParentCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_vft_Category_vft_Category_ParentCategory",
                table: "vft_Category",
                column: "ParentCategory",
                principalTable: "vft_Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vft_Posts_vft_Category_CategoryId",
                table: "vft_Posts",
                column: "CategoryId",
                principalTable: "vft_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vft_Category_vft_Category_ParentCategory",
                table: "vft_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_vft_Posts_vft_Category_CategoryId",
                table: "vft_Posts");

            migrationBuilder.DropIndex(
                name: "IX_vft_Posts_CategoryId",
                table: "vft_Posts");

            migrationBuilder.DropIndex(
                name: "IX_vft_Category_ParentCategory",
                table: "vft_Category");
        }
    }
}
