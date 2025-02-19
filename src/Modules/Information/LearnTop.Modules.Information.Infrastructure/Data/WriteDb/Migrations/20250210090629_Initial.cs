﻿// <auto-generated/>
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnTop.Modules.Academy.Infrastructure.Data.WriteDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Information");

            migrationBuilder.CreateTable(
                name: "Banners",
                schema: "Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerSettings",
                schema: "Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidExtensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSize = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Information",
                table: "BannerSettings",
                columns: new[] { "Id", "CreatedAt", "MaxSize", "UpdatedAt", "ValidExtensions" },
                values: new object[] { new Guid("3956d347-694f-44c2-a8de-36c01f0d944e"), new DateTime(2025, 2, 10, 12, 36, 28, 794, DateTimeKind.Local).AddTicks(8595), 5, new DateTime(2025, 2, 10, 12, 36, 28, 795, DateTimeKind.Local).AddTicks(5752), "[\"Png\",\"Jpeg\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners",
                schema: "Information");

            migrationBuilder.DropTable(
                name: "BannerSettings",
                schema: "Information");
        }
    }
}
