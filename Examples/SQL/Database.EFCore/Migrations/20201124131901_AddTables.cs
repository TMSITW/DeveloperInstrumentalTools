using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RUB" },
                    { 2, "EUR" },
                    { 3, "USD" }
                });

            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "Id", "CurrencyId", "Date", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 24, 15, 5, 45, 0, DateTimeKind.Unspecified), 1.0 },
                    { 2, 2, new DateTime(2020, 11, 24, 16, 10, 34, 0, DateTimeKind.Unspecified), 95.0 },
                    { 3, 3, new DateTime(2020, 11, 24, 16, 10, 35, 0, DateTimeKind.Unspecified), 80.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_CurrencyId",
                table: "Rate",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
