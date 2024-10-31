using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class renamedcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TestAssignments_TestAssignmentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestAssignmentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestAssignmentId",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestAssignmentId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestAssignmentId",
                table: "Questions",
                column: "TestAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TestAssignments_TestAssignmentId",
                table: "Questions",
                column: "TestAssignmentId",
                principalTable: "TestAssignments",
                principalColumn: "Id");
        }
    }
}
