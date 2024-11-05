using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addtestattempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CategoryQuestionCount");

            migrationBuilder.DropColumn(name: "Options", table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "TestAttemptId",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    SubmittedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    TestAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAttempts_TestAssignments_TestAssignmentId",
                        column: x => x.TestAssignmentId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_TestAttemptId",
                table: "StudentAnswers",
                column: "TestAttemptId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_TestAssignmentId",
                table: "TestAttempts",
                column: "TestAssignmentId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_TestAttempts_TestAttemptId",
                table: "StudentAnswers",
                column: "TestAttemptId",
                principalTable: "TestAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_TestAttempts_TestAttemptId",
                table: "StudentAnswers"
            );

            migrationBuilder.DropTable(name: "TestAttempts");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_TestAttemptId",
                table: "StudentAnswers"
            );

            migrationBuilder.DropColumn(name: "TestAttemptId", table: "StudentAnswers");

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "Questions",
                type: "text",
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "CategoryQuestionCount",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    TestAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    QuestionCount = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryQuestionCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryQuestionCount_TestAssignments_TestAssignmentId",
                        column: x => x.TestAssignmentId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CategoryQuestionCount_TestAssignmentId",
                table: "CategoryQuestionCount",
                column: "TestAssignmentId"
            );
        }
    }
}
