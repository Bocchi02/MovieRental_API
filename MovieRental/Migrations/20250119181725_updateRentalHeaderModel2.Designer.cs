﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieRental;

#nullable disable

namespace MovieRental.Migrations
{
    [DbContext(typeof(MovieRentalDBContext))]
    [Migration("20250119181725_updateRentalHeaderModel2")]
    partial class updateRentalHeaderModel2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieRental.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customer_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<DateTime>("membership_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MovieRental.Models.Movie", b =>
                {
                    b.Property<int>("movie_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movie_id"));

                    b.Property<int>("current_rent_count")
                        .HasColumnType("int");

                    b.Property<string>("director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("release_year")
                        .HasColumnType("int");

                    b.Property<decimal>("rental_price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<int>("total_rent_count")
                        .HasColumnType("int");

                    b.HasKey("movie_id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.Property<int>("rental_detail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rental_detail_id"));

                    b.Property<int>("movie_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("rental_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("rental_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("return_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("rental_detail_id");

                    b.HasIndex("movie_id");

                    b.HasIndex("rental_id");

                    b.ToTable("RentalDetail");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RentalId");

                    b.HasIndex("CustomerId");

                    b.ToTable("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.HasOne("MovieRental.Models.Movie", "Movie")
                        .WithMany("RentalDetails")
                        .HasForeignKey("movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieRental.Models.RentalHeader", "RentalHeader")
                        .WithMany("RentalDetails")
                        .HasForeignKey("rental_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.HasOne("MovieRental.Models.Customer", "Customer")
                        .WithMany("RentalHeader")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MovieRental.Models.Customer", b =>
                {
                    b.Navigation("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.Movie", b =>
                {
                    b.Navigation("RentalDetails");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.Navigation("RentalDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
