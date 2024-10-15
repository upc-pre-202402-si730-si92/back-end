using Domain.Learning.Model.Entities;
using Domain.Security.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL("server=localhost;user=root;password=Upc123!;database=learning-center-db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // FLuent API
        builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.Title).HasMaxLength(25);

        builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.Summary).HasMaxLength(300)
            .IsRequired()
            .HasDefaultValue("Test title");

        builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.IsActive);

        builder.Entity<Section>().ToTable("Section");
        builder.Entity<User>().ToTable("User");
    }
}