using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShreeGanpati.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jewels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jewelleryOptions",
                columns: table => new
                {
                    JewelleryId = table.Column<int>(type: "int", nullable: false),
                    Metel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddOns = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jewelleryOptions", x => new { x.JewelleryId, x.Metel, x.AddOns });
                    table.ForeignKey(
                        name: "FK_jewelleryOptions_Jewels_JewelleryId",
                        column: x => x.JewelleryId,
                        principalTable: "Jewels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JewelleryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Metel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddOns = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    OrderId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jewels",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/green_diamond_pendant.png", "Green Diamond Pendant", 45000.0 },
                    { 2, "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/ruby_ring.png", "Gold Diamond and Ruby Ring", 85000.0 },
                    { 3, "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/diamond_earring.png", "Diamond Earring", 25000.0 },
                    { 4, "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/diamond_ring.png", "Silver Diamond Ring", 8000.0 },
                    { 5, "https://raw.githubusercontent.com/Priyanshsoni-18/Project_Images/main/gold_ring.png", "Gold Diamond Ring", 60000.0 }
                });

            migrationBuilder.InsertData(
                table: "jewelleryOptions",
                columns: new[] { "AddOns", "JewelleryId", "Metel" },
                values: new object[,]
                {
                    { "Diamond", 1, "Gold" },
                    { "Emerald", 2, "Silver" },
                    { "Sapphire", 3, "Platinum" },
                    { "Ruby", 4, "Gold" },
                    { "Topaz", 5, "Silver" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId1",
                table: "Items",
                column: "OrderId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "jewelleryOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Jewels");
        }
    }
}
