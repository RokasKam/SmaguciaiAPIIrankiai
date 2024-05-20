using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    public partial class Route : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteIndex",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RouteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeInSeconds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RouteId",
                table: "Orders",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Routes_RouteId",
                table: "Orders",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Routes_RouteId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RouteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RouteIndex",
                table: "Orders");
        }
    }
}
