using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Movie_movie_id",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_RentalHeader_rental_id",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId",
                table: "RentalHeader");

            migrationBuilder.DropColumn(
                name: "rental_date",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "return_date",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "status",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "current_rent_count",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "release_year",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "RentalHeader",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "RentalHeader",
                newName: "RentalID");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHeader_CustomerId",
                table: "RentalHeader",
                newName: "IX_RentalHeader_CustomerID");

            migrationBuilder.RenameColumn(
                name: "rental_id",
                table: "RentalDetail",
                newName: "RentalID");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "RentalDetail",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "rental_detail_id",
                table: "RentalDetail",
                newName: "RentalDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetail_rental_id",
                table: "RentalDetail",
                newName: "IX_RentalDetail_RentalID");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetail_movie_id",
                table: "RentalDetail",
                newName: "IX_RentalDetail_MovieID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movie",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Movie",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "director",
                table: "Movie",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "total_rent_count",
                table: "Movie",
                newName: "ReleaseYear");

            migrationBuilder.RenameColumn(
                name: "rental_price",
                table: "Movie",
                newName: "RentalPrice");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "Movie",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "middlename",
                table: "Customer",
                newName: "Middlename");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Customer",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Customer",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Customer",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Customer",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "membership_date",
                table: "Customer",
                newName: "MembershipDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Customer",
                newName: "CustomerID");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                collation: "LAtin1_General_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldCollation: "Latin1_General_CI_AS");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_Movie_MovieID",
                table: "RentalDetail",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetail_RentalHeader_RentalID",
                table: "RentalDetail",
                column: "RentalID",
                principalTable: "RentalHeader",
                principalColumn: "RentalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_CustomerID",
                table: "RentalHeader",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_Movie_MovieID",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetail_RentalHeader_RentalID",
                table: "RentalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_CustomerID",
                table: "RentalHeader");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "RentalHeader",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "RentalID",
                table: "RentalHeader",
                newName: "RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHeader_CustomerID",
                table: "RentalHeader",
                newName: "IX_RentalHeader_CustomerId");

            migrationBuilder.RenameColumn(
                name: "RentalID",
                table: "RentalDetail",
                newName: "rental_id");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "RentalDetail",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "RentalDetailID",
                table: "RentalDetail",
                newName: "rental_detail_id");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetail_RentalID",
                table: "RentalDetail",
                newName: "IX_RentalDetail_rental_id");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetail_MovieID",
                table: "RentalDetail",
                newName: "IX_RentalDetail_movie_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movie",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movie",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Movie",
                newName: "director");

            migrationBuilder.RenameColumn(
                name: "RentalPrice",
                table: "Movie",
                newName: "rental_price");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Movie",
                newName: "total_rent_count");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movie",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "Middlename",
                table: "Customer",
                newName: "middlename");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Customer",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Customer",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customer",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customer",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "MembershipDate",
                table: "Customer",
                newName: "membership_date");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customer",
                newName: "customer_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "rental_date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "return_date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "release_year",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                collation: "Latin1_General_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldCollation: "LAtin1_General_CI_AS");

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
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId",
                table: "RentalHeader",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
