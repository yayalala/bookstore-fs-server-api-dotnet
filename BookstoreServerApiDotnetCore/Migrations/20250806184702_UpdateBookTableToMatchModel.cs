using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreServerApiDotnetCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookTableToMatchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Books",
                newName: "Description");
        }
    }
}
