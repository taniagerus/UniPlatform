using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedSelectedOptionstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedOptions",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    TestOptionId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_SelectedOptions_TestOptions_TestOptionId",
                        column: x => x.TestOptionId,
                        principalTable: "TestOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOptions_QuestionId",
                table: "SelectedOptions",
                column: "QuestionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOptions_TestOptionId",
                table: "SelectedOptions",
                column: "TestOptionId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "SelectedOptions");
        }
    }
}
