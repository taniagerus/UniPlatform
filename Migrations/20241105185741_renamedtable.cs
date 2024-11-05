using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class renamedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_StudentAnswers_AnswerId",
                table: "TestOptions"
            );

            migrationBuilder.DropIndex(name: "IX_TestOptions_AnswerId", table: "TestOptions");

            migrationBuilder.DropColumn(name: "AnswerId", table: "TestOptions");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "SelectedOptions",
                type: "integer",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOptions_AnswerId",
                table: "SelectedOptions",
                column: "AnswerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_StudentAnswers_AnswerId",
                table: "SelectedOptions",
                column: "AnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_StudentAnswers_AnswerId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropIndex(
                name: "IX_SelectedOptions_AnswerId",
                table: "SelectedOptions"
            );

            migrationBuilder.DropColumn(name: "AnswerId", table: "SelectedOptions");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "TestOptions",
                type: "integer",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_AnswerId",
                table: "TestOptions",
                column: "AnswerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_StudentAnswers_AnswerId",
                table: "TestOptions",
                column: "AnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Id"
            );
        }
    }
}
