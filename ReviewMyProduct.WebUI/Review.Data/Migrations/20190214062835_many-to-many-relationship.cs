using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class manytomanyrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ratings_RatingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RatingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RatingId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFromShops",
                table: "ProductFromShops");

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "numThumbsDown",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "numThumbsUp",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductFromShops");

            migrationBuilder.RenameTable(
                name: "ProductFromShops",
                newName: "ProductFromShop");

            migrationBuilder.RenameColumn(
                name: "RatingCount",
                table: "Users",
                newName: "CommentId");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFromShop",
                table: "ProductFromShop",
                columns: new[] { "ProductId", "ShopId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CommentId",
                table: "Ratings",
                column: "CommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFromShop_ShopId",
                table: "ProductFromShop",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFromShop_Products_ProductId",
                table: "ProductFromShop",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFromShop_Shops_ShopId",
                table: "ProductFromShop",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Comments_CommentId",
                table: "Ratings",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFromShop_Products_ProductId",
                table: "ProductFromShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFromShop_Shops_ShopId",
                table: "ProductFromShop");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Comments_CommentId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CommentId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFromShop",
                table: "ProductFromShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductFromShop_ShopId",
                table: "ProductFromShop");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "ProductFromShop",
                newName: "ProductFromShops");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Users",
                newName: "RatingCount");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numThumbsDown",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numThumbsUp",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductFromShops",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFromShops",
                table: "ProductFromShops",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ThumbsUp" },
                values: new object[] { 1, true });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ThumbsUp" },
                values: new object[] { 2, false });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RatingId",
                table: "Users",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RatingId",
                table: "Comments",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ratings_RatingId",
                table: "Users",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
