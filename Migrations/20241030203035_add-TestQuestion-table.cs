using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addTestQuestiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_TestQuestions_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_TestQuestions_QuestionId",
                table: "TestOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestAssignments_TestAssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestCategories_TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TestCategoryId",
                table: "TestQuestions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TestQuestions",
                newName: "QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "TestAssignmentId",
                table: "TestQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "text", nullable: false),
                    Options = table.Column<string>(type: "text", nullable: true),
                    TestAssignmentId = table.Column<int>(type: "integer", nullable: true),
                    TestCategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_TestAssignments_TestAssignmentId",
                        column: x => x.TestAssignmentId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_TestCategories_TestCategoryId",
                        column: x => x.TestCategoryId,
                        principalTable: "TestCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_QuestionId",
                table: "TestQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestAssignmentId",
                table: "Questions",
                column: "TestAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestCategoryId",
                table: "Questions",
                column: "TestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_Questions_QuestionId",
                table: "TestOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId",
                table: "TestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_TestAssignments_TestAssignmentId",
                table: "TestQuestions",
                column: "TestAssignmentId",
                principalTable: "TestAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_Questions_QuestionId",
                table: "TestOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_TestAssignments_TestAssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_QuestionId",
                table: "TestQuestions");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "TestQuestions",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "TestAssignmentId",
                table: "TestQuestions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "TestQuestions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "TestQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TestCategoryId",
                table: "TestQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestCategoryId",
                table: "TestQuestions",
                column: "TestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_TestQuestions_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_TestQuestions_QuestionId",
                table: "TestOptions",
                column: "QuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
