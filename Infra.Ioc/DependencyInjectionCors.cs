using Microsoft.Extensions.DependencyInjection;

namespace CardapioOnline.Infra.Ioc;

public static class DependencyInjectionCors
{
    public static IServiceCollection AddInfrastructureCors(this IServiceCollection services)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("http://0.0.0.0:8100")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        return services;
    }
}