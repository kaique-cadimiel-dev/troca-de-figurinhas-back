using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace TrocaDeFigurinhas.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Load .env from the project root (where the factory is usually called from)
        // Adjust the path if needed
        DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), "../../.env"));
        
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            // Fallback for different directory structures during migration
            DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
