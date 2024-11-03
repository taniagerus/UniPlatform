using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class changedfieldcategorytocategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TestAssignments");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "TestAssignments",
                newName: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "TestAssignments",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TestAssignments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
