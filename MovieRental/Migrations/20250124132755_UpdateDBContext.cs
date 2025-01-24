using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_RentalID",
                table: "RentalDetail");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalID_MovieID",
                table: "RentalDetail",
                columns: new[] { "RentalID", "MovieID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_RentalID_MovieID",
                table: "RentalDetail");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_RentalID",
                table: "RentalDetail",
                column: "RentalID");
        }
    }
}
