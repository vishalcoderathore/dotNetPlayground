using dotNetPlayground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotNetPlayground.Data;

public class DataContextEF : DbContext
{
    public DbSet<Computer>? Computer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        if (!optionsBuilder.IsConfigured)
        {
            string? connectionString = config.GetConnectionString("DefaultConnection"); // Ensure this matches your appsettings.json
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "The connection string 'DefaultConnection' was not found."
                );
            }
            optionsBuilder.UseSqlServer(
                connectionString,
                options => options.EnableRetryOnFailure()
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TutorialAppSchema");
        modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
    }
}
