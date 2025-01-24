using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental
{
    public class MovieRentalDBContext : DbContext
    {
        public MovieRentalDBContext(DbContextOptions<MovieRentalDBContext> options) : base(options) {}

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<RentalHeader> RentalHeader { get; set; }
        public DbSet<RentalDetail> RentalDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.MovieID);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<RentalHeader>().HasKey(rh => rh.RentalID);
            modelBuilder.Entity<RentalDetail>().HasKey(rd  => rd.RentalDetailID);

            modelBuilder.Entity<Movie>()
                .Property(t => t.Title)
                .UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Movie>()
                .Property(rp => rp.RentalPrice)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Customer>()
                .Property(ln => ln.Lastname)
                .UseCollation("LAtin1_General_CI_AS");

            modelBuilder.Entity<Customer>()
                .Property(fn => fn.Firstname)
                .UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<RentalHeader>()
                .Property(s => s.Status)
                .HasMaxLength(20);

            modelBuilder.Entity<RentalHeader>()
                .HasOne(rh => rh.Customer)
                .WithMany(c => c.RentalHeader)
                .HasForeignKey(rh => rh.CustomerID);

            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.RentalHeader)
                .WithMany(rh => rh.RentalDetails)
                .HasForeignKey(rd => rd.RentalID);

            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.Movie)
                .WithMany(m => m.RentalDetails)
                .HasForeignKey(rd => rd.MovieID);

            modelBuilder.Entity<RentalDetail>()
                .HasIndex(rd => new { rd.RentalID, rd.MovieID })
                .IsUnique();




            //modelBuilder.Entity<Movie>()
            //    .HasKey(m => m.MovieID);
            //modelBuilder.Entity<Movie>()
            //    .Property(t => t.Title)
            //    .UseCollation("Latin1_General_CI_AS");
            //modelBuilder.Entity<Movie>()
            //    .Property(p => p.RentalPrice)
            //    .HasColumnType("decimal(10,2)");

            //modelBuilder.Entity<Customer>()
            //    .HasKey(c => c.CustomerID);
            //modelBuilder.Entity<Customer>()
            //    .Property(ln => ln.Lastname)
            //    .UseCollation("Latin1_General_CI_AS");
            //modelBuilder.Entity<Customer>()
            //    .Property(fn => fn.Firstname)
            //    .UseCollation("Latin1_General_CI_AS");

            //modelBuilder.Entity<RentalHeader>().HasKey(rh => rh.RentalID);
            //modelBuilder.Entity<RentalHeader>()
            //    .Property(s => s.Status)
            //    .HasMaxLength(20);

            //modelBuilder.Entity<RentalHeader>()
            //    .HasOne(rh => rh.Customer)
            //    .WithMany(c => c.RentalHeader)
            //    .HasForeignKey(rh => rh.CustomerID);

            //modelBuilder.Entity<RentalDetail>().HasKey(rd => rd.RentalDetailID);
            //modelBuilder.Entity<RentalDetail>()
            //    .HasOne(rd => rd.RentalHeader)
            //    .WithMany(rh => rh.RentalDetails)
            //    .HasForeignKey(rd => rd.RentalID);

            //modelBuilder.Entity<RentalDetail>()
            //    .HasOne(rd => rd.Movie)
            //    .WithMany(m => m.RentalDetails)
            //    .HasForeignKey(rd => rd.MovieID);

            //modelBuilder.Entity<RentalHeader>()
            //    .Ignore(ch => this.Customer)
            //    .Ignore(rd => this.RentalDetail);
        }
    }
}
