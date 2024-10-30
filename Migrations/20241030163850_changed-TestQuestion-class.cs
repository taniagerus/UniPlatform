using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class changedTestQuestionclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestCategories_CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "StudentAnswerOptions");

            migrationBuilder.DropTable(
                name: "TestAssignmentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "TestQuestions");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TestQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "TestQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TestAssignmentId",
                table: "TestQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestCategoryId",
                table: "TestQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentAnswerId",
                table: "TestOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestAssignmentId",
                table: "TestQuestions",
                column: "TestAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestCategoryId",
                table: "TestQuestions",
                column: "TestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_StudentAnswerId",
                table: "TestOptions",
                column: "StudentAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_StudentAnswers_StudentAnswerId",
                table: "TestOptions",
                column: "StudentAnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_TestAssignments_TestAssignmentId",
                table: "TestQuestions",
                column: "TestAssignmentId",
                principalTable: "TestAssignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_TestCategories_TestCategoryId",
                table: "TestQuestions",
                column: "TestCategoryId",
                principalTable: "TestCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_StudentAnswers_StudentAnswerId",
                table: "TestOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestAssignments_TestAssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestCategories_TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_TestAssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestOptions_StudentAnswerId",
                table: "TestOptions");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TestAssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "StudentAnswerId",
                table: "TestOptions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TestQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "TestQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentAnswerOptions",
                columns: table => new
                {
                    SelectedOptionsId = table.Column<int>(type: "integer", nullable: false),
                    StudentAnswerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswerOptions", x => new { x.SelectedOptionsId, x.StudentAnswerId });
                    table.ForeignKey(
                        name: "FK_StudentAnswerOptions_StudentAnswers_StudentAnswerId",
                        column: x => x.StudentAnswerId,
                        principalTable: "StudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswerOptions_TestOptions_SelectedOptionsId",
                        column: x => x.SelectedOptionsId,
                        principalTable: "TestOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAssignmentQuestions",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    TestAssignmentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAssignmentQuestions", x => new { x.QuestionsId, x.TestAssignmentsId });
                    table.ForeignKey(
                        name: "FK_TestAssignmentQuestions_TestAssignments_TestAssignmentsId",
                        column: x => x.TestAssignmentsId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAssignmentQuestions_TestQuestions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_CategoryId",
                table: "TestQuestions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerOptions_StudentAnswerId",
                table: "StudentAnswerOptions",
                column: "StudentAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignmentQuestions_TestAssignmentsId",
                table: "TestAssignmentQuestions",
                column: "TestAssignmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_TestCategories_CategoryId",
                table: "TestQuestions",
                column: "CategoryId",
                principalTable: "TestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
