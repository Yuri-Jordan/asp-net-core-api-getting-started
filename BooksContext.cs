
using Microsoft.EntityFrameworkCore;

public class BooksContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public BooksContext(DbContextOptions<BooksContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasKey(m => m.Id);
        base.OnModelCreating(builder);
    }
}