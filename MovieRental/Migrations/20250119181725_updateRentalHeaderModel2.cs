using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class updateRentalHeaderModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_customer_id",
                table: "RentalHeader");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "RentalHeader",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "return_date",
                table: "RentalHeader",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "rental_date",
                table: "RentalHeader",
                newName: "RentalDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "RentalHeader",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "rental_id",
                table: "RentalHeader",
                newName: "RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHeader_customer_id",
                table: "RentalHeader",
                newName: "IX_RentalHeader_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId",
                table: "RentalHeader",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId",
                table: "RentalHeader");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RentalHeader",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "RentalHeader",
                newName: "return_date");

            migrationBuilder.RenameColumn(
                name: "RentalDate",
                table: "RentalHeader",
                newName: "rental_date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "RentalHeader",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "RentalHeader",
                newName: "rental_id");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHeader_CustomerId",
                table: "RentalHeader",
                newName: "IX_RentalHeader_customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_customer_id",
                table: "RentalHeader",
                column: "customer_id",
                principalTable: "Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
