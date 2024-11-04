using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedTestQuestiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAssignments_Courses_CourseId",
                table: "TestAssignments"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TestAssignments_TestCategories_CategoryId",
                table: "TestAssignments"
            );

            migrationBuilder.DropIndex(
                name: "IX_TestAssignments_CategoryId",
                table: "TestAssignments"
            );

            migrationBuilder.DropIndex(
                name: "IX_TestAssignments_CourseId",
                table: "TestAssignments"
            );

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "TestAssignments",
                newName: "StudentId"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPoints",
                table: "TestAssignments",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric"
            );

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TestAssignments",
                type: "text",
                nullable: false,
                defaultValue: ""
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Category", table: "TestAssignments");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "TestAssignments",
                newName: "CourseId"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPoints",
                table: "TestAssignments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignments_CategoryId",
                table: "TestAssignments",
                column: "CategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignments_CourseId",
                table: "TestAssignments",
                column: "CourseId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TestAssignments_Courses_CourseId",
                table: "TestAssignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TestAssignments_TestCategories_CategoryId",
                table: "TestAssignments",
                column: "CategoryId",
                principalTable: "TestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
