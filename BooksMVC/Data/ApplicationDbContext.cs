using Microsoft.EntityFrameworkCore;
using BooksMVC.Models; // Make sure to include your models namespace

namespace BooksMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor to pass DbContextOptions to the base class.
        // This allows configuration (like connection string) to be passed from Program.cs.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet for your BookModel, which will map to the tbl_books table in the database.
        // The name "Books" here will be used by EF Core to pluralize and create the table name by default.
        // We will explicitly configure the table name in OnModelCreating.
        public DbSet<BookModel> Books { get; set; }

        // This method is used to configure the model that is being created.
        // We use it here to explicitly set the table name to "tbl_books".
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the BookModel to map to the "tbl_books" table.
            modelBuilder.Entity<BookModel>().ToTable("tbl_books");
        }
    }
}
