using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.Api.Migrations
{
    public partial class EndeDanesh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BestellDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellNummer = table.Column<int>(type: "int", nullable: false),
                    IstStorniert = table.Column<bool>(type: "bit", nullable: true),
                    KundenID = table.Column<int>(type: "int", nullable: false),
                    BestelltAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductMenge = table.Column<int>(type: "int", nullable: false),
                    VersandKosten = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SummeOhneMwSt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MwSt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Summe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GesamtSumme = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconCSS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestellDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KundenNummer = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anrede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HausNummer = table.Column<int>(type: "int", nullable: false),
                    PLZ = table.Column<int>(type: "int", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_MailAdresse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BestellDetailsProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BestellDetailsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductMenge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellDetailsProducts", x => new { x.ProductId, x.BestellDetailsId });
                    table.ForeignKey(
                        name: "FK_BestellDetailsProducts_BestellDetails_BestellDetailsId",
                        column: x => x.BestellDetailsId,
                        principalTable: "BestellDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellDetailsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "IconCSS", "Name" },
                values: new object[,]
                {
                    { 1, "fas fa-spa", "Beauty" },
                    { 2, "fas fa-couch", "Furniture" },
                    { 3, "fas fa-headphones", "Electronic" },
                    { 4, "fas fa-shoe-prints", "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BestellDetailsId", "CategoryId", "CategoryName", "Description", "ImageURL", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, null, 1, "Beauty", "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", "Glossier - Beauty Kit", 100m, 100 },
                    { 2, null, 1, "Beauty", "A kit provided by Curology, containing skin care products", "/Images/Beauty/Beauty2.png", "Curology - Skin Care Kit", 50m, 45 },
                    { 3, null, 1, "Beauty", "A kit provided by Curology, containing skin care products", "/Images/Beauty/Beauty3.png", "Cocooil - Organic Coconut Oil", 20m, 30 },
                    { 4, null, 1, "Beauty", "A kit provided by Schwarzkopf, containing skin care and hair care products", "/Images/Beauty/Beauty4.png", "Schwarzkopf - Hair Care and Skin Care Kit", 50m, 60 },
                    { 5, null, 1, "Beauty", "Skin Care Kit, containing skin care and hair care products", "/Images/Beauty/Beauty5.png", "Skin Care Kit", 30m, 85 },
                    { 6, null, 3, "Electronic", "Air Pods - in-ear wireless headphones", "/Images/Electronic/Electronics1.png", "Air Pods", 100m, 120 },
                    { 7, null, 3, "Electronic", "On-ear Golden Headphones - these headphones are not wireless", "/Images/Electronic/Electronics2.png", "On-ear Golden Headphones", 40m, 200 },
                    { 8, null, 3, "Electronic", "On-ear Black Headphones - these headphones are not wireless", "/Images/Electronic/Electronics3.png", "On-ear Black Headphones", 40m, 300 },
                    { 9, null, 3, "Electronic", "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod", "/Images/Electronic/Electronic4.png", "Sennheiser Digital Camera with Tripod", 600m, 20 },
                    { 10, null, 3, "Electronic", "Canon Digital Camera - High quality digital camera provided by Canon", "/Images/Electronic/Electronic5.png", "Canon Digital Camera", 500m, 15 },
                    { 11, null, 3, "Electronic", "Gameboy - Provided by Nintendo", "/Images/Electronic/technology6.png", "Nintendo Gameboy", 100m, 60 },
                    { 12, null, 2, "Furniture", "Very comfortable black leather office chair", "/Images/Furniture/Furniture1.png", "Black Leather Office Chair", 50m, 212 },
                    { 13, null, 2, "Furniture", "Very comfortable pink leather office chair", "/Images/Furniture/Furniture2.png", "Pink Leather Office Chair", 50m, 112 },
                    { 14, null, 2, "Furniture", "Very comfortable lounge chair", "/Images/Furniture/Furniture3.png", "Lounge Chair", 70m, 90 },
                    { 15, null, 2, "Furniture", "Very comfortable Silver lounge chair", "/Images/Furniture/Furniture4.png", "Silver Lounge Chair", 120m, 95 },
                    { 16, null, 2, "Furniture", "White and blue Porcelain Table Lamp", "/Images/Furniture/Furniture6.png", "Porcelain Table Lamp", 15m, 100 },
                    { 17, null, 2, "Furniture", "Office Table Lamp", "/Images/Furniture/Furniture7.png", "Office Table Lamp", 20m, 73 },
                    { 18, null, 4, "Shoes", "Comfortable Puma Sneakers in most sizes", "/Images/Shoes/Shoes1.png", "Puma Sneakers", 100m, 50 },
                    { 19, null, 4, "Shoes", "Colorful trainsers - available in most sizes", "/Images/Shoes/Shoes2.png", "Colorful Trainers", 150m, 60 },
                    { 20, null, 4, "Shoes", "Blue Nike Trainers - available in most sizes", "/Images/Shoes/Shoes3.png", "Blue Nike Trainers", 200m, 70 },
                    { 21, null, 4, "Shoes", "Colorful Hummel Trainers - available in most sizes", "/Images/Shoes/Shoes4.png", "Colorful Hummel Trainers", 120m, 120 },
                    { 22, null, 4, "Shoes", "Red Nike Trainers - available in most sizes", "/Images/Shoes/Shoes5.png", "Red Nike Trainers", 200m, 100 },
                    { 23, null, 4, "Shoes", "Birkenstock Sandles - available in most sizes", "/Images/Shoes/Shoes6.png", "Birkenstock Sandles", 50m, 150 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Anrede", "CreatedDate", "E_MailAdresse", "HausNummer", "KundenNummer", "Land", "Nachname", "Ort", "PLZ", "Strasse", "UserName", "Vorname" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, null, null, null, 0, null, "Bob", null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, null, null, null, 0, null, "Sarah", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestellDetailsProducts_BestellDetailsId",
                table: "BestellDetailsProducts",
                column: "BestellDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellDetailsProducts");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BestellDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
