using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkeletonApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Cars", new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6005), null, null },
                    { 2, "Planes", new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6459), null, null },
                    { 3, "Trucks", new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6468), null, null },
                    { 4, "Boats", new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6469), null, null },
                    { 5, "Rockets", new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6471), null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImagePath", "ProductName", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(337), "This convertible car is fast! The engine is powered by a neutrino based battery (not included).Power it up and let it go!", "carconvert.png", "Convertible Car", 22.5, null },
                    { 2, 1, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(488), "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.", "carearly.png", "Old-time Car", 15.949999999999999, null },
                    { 3, 1, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(491), "Yes this car is fast, but it also floats in water.", "carfast.png", "Fast Car", 32.990000000000002, null },
                    { 4, 1, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(532), "Use this super fast car to entertain guests. Lights and doors work!", "carfaster.png", "Super Fast Car", 8.9499999999999993, null },
                    { 5, 1, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(533), "This old style racer can fly (with user assistance). Gravity controls flight duration.No batteries required.", "carracer.png", "Old Style Racer", 34.950000000000003, null },
                    { 6, 2, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(538), "Authentic airplane toy. Features realistic color and details.", "planeace.png", "Ace Plane", 95.0, null },
                    { 7, 2, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(540), "This fun glider is made from real balsa wood. Some assembly required.", "planeglider.png", "Glider", 4.9500000000000002, null },
                    { 8, 2, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(541), "This paper plane is like no other paper plane. Some folding required.", "planepaper.png", "Paper Plane", 2.9500000000000002, null },
                    { 9, 2, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(542), "Rubber band powered plane features two wheels.", "planeprop.png", "Propeller Plane", 32.950000000000003, null },
                    { 10, 3, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(545), "This toy truck has a real gas powered engine. Requires regular tune ups.", "truckearly.png", "Early Truck", 15.0, null },
                    { 11, 3, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(546), "You will have endless fun with this one quarter sized fire truck.", "truckfire.png", "Fire Truck", 26.0, null },
                    { 12, 3, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(548), "This fun toy truck can be used to tow other trucks that are not as big.", "truckbig.png", "Big Truck", 29.0, null },
                    { 13, 4, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(549), "Is it a boat or a ship. Let this floating vehicle decide by using its artifically intelligent computer brain!", "boatbig.png", "Big Ship", 95.0, null },
                    { 14, 4, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(550), "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!Some folding required.", "boatpaper.png", "Paper Boat", 4.9500000000000002, null },
                    { 15, 4, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(551), "Put this fun toy sail boat in the water and let it go!", "boatsail.png", "Sail Boat", 42.950000000000003, null },
                    { 16, 5, new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(553), "This fun rocket will travel up to a height of 200 feet.", "rocket.png", "Rocket", 122.95, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
