using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnTop.Modules.Blogs.Infrastructure.Data.SnapshotsDb.Migrations
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
                name: "UserSnapshots",
                schema: "Blogs",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSnapshots", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSnapshots",
                schema: "Blogs");
        }
    }
}
