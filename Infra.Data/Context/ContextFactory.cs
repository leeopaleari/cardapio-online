using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CardapioOnline.Infra.Data;

public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        string apiDirectory = Path.Combine(parentDirectory, "API");
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(apiDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}