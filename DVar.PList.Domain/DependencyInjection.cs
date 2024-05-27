using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DVar.PList.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IValidator<Pricelist>, PricelistValidator>();

        return services;
    }
}