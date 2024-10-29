using Domain.Learning.Model.Entities;
using Domain.Security.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL(_configuration["ConnectionStrings:learningCenterConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // FLuent API
        builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.Title).HasMaxLength(25).IsRequired();

        builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.Summary).HasMaxLength(300)
            .HasDefaultValue("Test title");

       /* builder.Entity<Tutorial>().ToTable("Tutorial")
            .Property(c => c.IsActive)
            .HasDefaultValue(true);*/

        builder.Entity<Tutorial>()
            .ToTable("Tutorial")
            .Property(c => c.CreatedDate)
            .HasColumnType("TIMESTAMP")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");


        builder.Entity<Tutorial>()
            .ToTable("Tutorial")
            .HasMany(t => t.Sections) // Define the relationship
            .WithOne(s => s.Tutorial) // Specify the inverse navigation property
            .HasForeignKey(s => s.TutorialId) // Define the foreign key in Section
            .OnDelete(DeleteBehavior
                .Cascade); // Optional: define behavior on delete (Cascade means deleting a Tutorial will delete related Sections)


       /* builder.Entity<Section>().ToTable("Section")
            .Property(c => c.IsActive)
            .HasDefaultValue(true);*/

        builder.Entity<Section>()
            .ToTable("Section")
            .Property(c => c.CreatedDate)
            .HasColumnType("TIMESTAMP")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Entity<User>()
            .ToTable("User")
            .Property(c => c.CreatedDate)
            .HasColumnType("TIMESTAMP")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

      /*  builder.Entity<User>().ToTable("User")
            .Property(c => c.IsActive)
            .HasDefaultValue(true);*/
    }
}