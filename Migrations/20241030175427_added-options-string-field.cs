using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedoptionsstringfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "TestQuestions",
                type: "text",
                nullable: false,
                defaultValue: ""
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Options", table: "TestQuestions");
        }
    }
}
