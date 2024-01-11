using CardapioOnline.Application.Interfaces;
using CardapioOnline.Application.Services;
using CardapioOnline.Infra.Data;
using CardapioOnline.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardapioOnline.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}