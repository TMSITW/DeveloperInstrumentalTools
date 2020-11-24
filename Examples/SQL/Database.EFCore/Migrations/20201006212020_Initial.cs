using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SummaryId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_Summary_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Summary",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "Freezing" },
                    { 2, "Bracing" },
                    { 3, "Chilly" },
                    { 4, "Cool" },
                    { 5, "Mild" },
                    { 6, "Warm" },
                    { 7, "Balmy" },
                    { 8, "Hot" },
                    { 9, "Sweltering" },
                    { 10, "Scorching" }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "Date", "SummaryId", "Temperature" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, -10m },
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, -1.3m },
                    { 2, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5.1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_SummaryId",
                table: "Weather",
                column: "SummaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Summary");
        }
    }
}
