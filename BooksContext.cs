
using Microsoft.EntityFrameworkCore;

public class RepositoryContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasKey(m => m.Id);
        base.OnModelCreating(builder);
    }
}