using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnTop.Modules.Categories.Infrastructure.Data.WriteDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRelation",
                schema: "Categories",
                columns: table => new
                {
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChildCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRelation", x => new { x.ParentCategoryId, x.ChildCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryRelation_Categories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalSchema: "Categories",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryRelation_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "Categories",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRelation_ChildCategoryId",
                schema: "Categories",
                table: "CategoryRelation",
                column: "ChildCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRelation",
                schema: "Categories");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Categories");
        }
    }
}
