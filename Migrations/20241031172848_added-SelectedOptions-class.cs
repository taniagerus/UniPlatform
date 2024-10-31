using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedSelectedOptionsclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TestCategories_TestCategoryId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_TestAttempts_TestAttemptId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_StudentAnswers_StudentAnswerId",
                table: "TestOptions");

            migrationBuilder.DropTable(
                name: "TestAttempts");

            migrationBuilder.DropTable(
                name: "TestCategories");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestCategoryId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestCategoryId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "StudentAnswerId",
                table: "TestOptions",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_TestOptions_StudentAnswerId",
                table: "TestOptions",
                newName: "IX_TestOptions_AnswerId");

            migrationBuilder.RenameColumn(
                name: "TestAttemptId",
                table: "StudentAnswers",
                newName: "TestAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_TestAttemptId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_TestAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_TestAssignments_TestAssignmentId",
                table: "StudentAnswers",
                column: "TestAssignmentId",
                principalTable: "TestAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_StudentAnswers_AnswerId",
                table: "TestOptions",
                column: "AnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_TestAssignments_TestAssignmentId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_StudentAnswers_AnswerId",
                table: "TestOptions");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "TestOptions",
                newName: "StudentAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_TestOptions_AnswerId",
                table: "TestOptions",
                newName: "IX_TestOptions_StudentAnswerId");

            migrationBuilder.RenameColumn(
                name: "TestAssignmentId",
                table: "StudentAnswers",
                newName: "TestAttemptId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_TestAssignmentId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_TestAttemptId");

            migrationBuilder.AddColumn<int>(
                name: "TestCategoryId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    TestAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Score = table.Column<decimal>(type: "numeric", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAttempts_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAttempts_TestAssignments_TestAssignmentId",
                        column: x => x.TestAssignmentId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCategories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestCategoryId",
                table: "Questions",
                column: "TestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_StudentId",
                table: "TestAttempts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_TestAssignmentId",
                table: "TestAttempts",
                column: "TestAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCategories_CourseId",
                table: "TestCategories",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TestCategories_TestCategoryId",
                table: "Questions",
                column: "TestCategoryId",
                principalTable: "TestCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_TestAttempts_TestAttemptId",
                table: "StudentAnswers",
                column: "TestAttemptId",
                principalTable: "TestAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_StudentAnswers_StudentAnswerId",
                table: "TestOptions",
                column: "StudentAnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Id");
        }
    }
}
