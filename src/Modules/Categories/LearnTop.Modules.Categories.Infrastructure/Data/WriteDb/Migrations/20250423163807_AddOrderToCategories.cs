using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnTop.Modules.Categories.Infrastructure.Data.WriteDb.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "Categories",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "Categories",
                table: "Categories");
        }
    }
}
