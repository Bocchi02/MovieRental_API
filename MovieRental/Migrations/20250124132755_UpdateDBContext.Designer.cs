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
    [Migration("20250124132755_UpdateDBContext")]
    partial class UpdateDBContext
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
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("LAtin1_General_CI_AS");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MovieRental.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.HasKey("MovieID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.Property<int>("RentalDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailID"));

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("RentalID")
                        .HasColumnType("int");

                    b.HasKey("RentalDetailID");

                    b.HasIndex("MovieID");

                    b.HasIndex("RentalID", "MovieID")
                        .IsUnique();

                    b.ToTable("RentalDetail");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RentalID");

                    b.HasIndex("CustomerID");

                    b.ToTable("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalDetail", b =>
                {
                    b.HasOne("MovieRental.Models.Movie", "Movie")
                        .WithMany("RentalDetails")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieRental.Models.RentalHeader", "RentalHeader")
                        .WithMany("RentalDetails")
                        .HasForeignKey("RentalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("RentalHeader");
                });

            modelBuilder.Entity("MovieRental.Models.RentalHeader", b =>
                {
                    b.HasOne("MovieRental.Models.Customer", "Customer")
                        .WithMany("RentalHeader")
                        .HasForeignKey("CustomerID")
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
