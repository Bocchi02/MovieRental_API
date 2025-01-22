using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity_rented",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "quantity_returned",
                table: "RentalDetail");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Movie",
                newName: "total_rent_count");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "RentalHeader",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "return_date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "rental_date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "RentalDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "current_rent_count",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "firstname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                collation: "Latin1_General_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RentalHeader_customer_id",
                table: "RentalHeader",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_movie_id",
                table: "RentalDetail",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetail_rental_id",
                table: "RentalDetail",
                column: "rental_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_Movie_movie_id",
                table: "RentalDetail",
                column: "movie_id",
                principalTable: "Movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_RentalHeader_rental_id",
                table: "RentalDetail",
                column: "rental_id",
                principalTable: "RentalHeader",
                principalColumn: "rental_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_customer_id",
                table: "RentalHeader",
                column: "customer_id",
                principalTable: "Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Movie_movie_id",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_RentalHeader_rental_id",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_customer_id",
                table: "RentalHeader");

            migrationBuilder.DropIndex(
                name: "IX_RentalHeader_customer_id",
                table: "RentalHeader");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_movie_id",
                table: "RentalDetail");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetail_rental_id",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "rental_date",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "status",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "current_rent_count",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "total_rent_count",
                table: "Movie",
                newName: "stock");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "RentalHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "return_date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantity_rented",
                table: "RentalDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity_returned",
                table: "RentalDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "firstname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldCollation: "Latin1_General_CI_AS");
        }
    }
}
