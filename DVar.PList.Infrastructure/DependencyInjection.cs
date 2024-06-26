using DVar.PList.Domain.Persistence;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using DVar.PList.Infrastructure.RepositoryImplementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DVar.PList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPricelistRepository, PricelistRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomColumnRepository, CustomColumnRepository>();
        return services;
    }
}