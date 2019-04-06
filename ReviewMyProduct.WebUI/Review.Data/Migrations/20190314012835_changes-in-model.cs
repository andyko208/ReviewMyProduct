using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class changesinmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFromShop");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c8b30b69-0012-4a9f-b234-76bccbc60471", "97e65167-a2f3-48a1-92a5-31ade52e61d3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f859f292-331f-4d4a-aca9-75d02b93db50", "39468404-5b93-4a75-bf72-cdd632be02c6" });

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Products",
                newName: "ShopURL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5c08ac3-1b67-462e-a2de-57d1e537ac7b", "1d5e2219-8c7a-461a-b08b-05963f9fa916", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b56f20cf-1cec-45e7-8392-2192b4b98c39", "255b6003-0037-428d-8efa-8bf94a8f5869", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a5c08ac3-1b67-462e-a2de-57d1e537ac7b", "1d5e2219-8c7a-461a-b08b-05963f9fa916" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b56f20cf-1cec-45e7-8392-2192b4b98c39", "255b6003-0037-428d-8efa-8bf94a8f5869" });

            migrationBuilder.RenameColumn(
                name: "ShopURL",
                table: "Products",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFromShop",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFromShop", x => new { x.ProductId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_ProductFromShop_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFromShop_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8b30b69-0012-4a9f-b234-76bccbc60471", "97e65167-a2f3-48a1-92a5-31ade52e61d3", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f859f292-331f-4d4a-aca9-75d02b93db50", "39468404-5b93-4a75-bf72-cdd632be02c6", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFromShop_ShopId",
                table: "ProductFromShop",
                column: "ShopId");
        }
    }
}
