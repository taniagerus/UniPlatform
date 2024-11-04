using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addcategoryquestioncount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CategoryQuestionCount");
        }
    }
}
