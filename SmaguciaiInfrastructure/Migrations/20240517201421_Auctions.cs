using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    public partial class Auctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuctionStatus",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BidSum = table.Column<double>(type: "REAL", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    CVC = table.Column<string>(type: "TEXT", nullable: false),
                    ExpDate = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuctionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Products_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId1",
                table: "Products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuctionStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Products");
        }
    }
}
