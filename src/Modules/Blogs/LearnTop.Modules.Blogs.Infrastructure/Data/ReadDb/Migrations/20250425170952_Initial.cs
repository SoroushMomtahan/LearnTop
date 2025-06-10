using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Blogs");

            migrationBuilder.CreateTable(
                name: "AuthorView",
                schema: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleViews",
                schema: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleViews_AuthorView_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Blogs",
                        principalTable: "AuthorView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleViews_AuthorId",
                schema: "Blogs",
                table: "ArticleViews",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleViews",
                schema: "Blogs");

            migrationBuilder.DropTable(
                name: "AuthorView",
                schema: "Blogs");
        }
    }
}
