using bookapi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bookapi.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ai => ai.AId);
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Publisher)
                .WithMany(x => x.Books);
                


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
