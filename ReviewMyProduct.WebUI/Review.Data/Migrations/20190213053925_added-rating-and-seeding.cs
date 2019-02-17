using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Review.Data.Migrations
{
    public partial class addedratingandseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Good",
                table: "Comments",
                newName: "numThumbsUp");

            migrationBuilder.RenameColumn(
                name: "Bad",
                table: "Comments",
                newName: "numThumbsDown");

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThumbsUp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ratings_RatingId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Users_RatingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RatingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "numThumbsUp",
                table: "Comments",
                newName: "Good");

            migrationBuilder.RenameColumn(
                name: "numThumbsDown",
                table: "Comments",
                newName: "Bad");
        }
    }
}
