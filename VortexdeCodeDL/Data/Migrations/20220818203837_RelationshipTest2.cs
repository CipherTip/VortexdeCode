using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VortexdeCodeDL.Data.Migrations
{
    public partial class RelationshipTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questions_FloorID",
                table: "Questions",
                column: "FloorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Floors_FloorID",
                table: "Questions",
                column: "FloorID",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Floors_FloorID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FloorID",
                table: "Questions");
        }
    }
}
