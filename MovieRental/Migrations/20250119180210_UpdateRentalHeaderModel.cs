using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRentalHeaderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_price",
                table: "RentalHeader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total_price",
                table: "RentalHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
