using dotNetPlayground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotNetPlayground.Data;

public class DataContextEF : DbContext
{
    public DbSet<Computer>? Computer { get; set; }

    private readonly string _config;

    public DataContextEF(IConfiguration config)
    {
        _config =
            config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string is missing or empty");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_config, options => options.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TutorialAppSchema");
        modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
    }
}
