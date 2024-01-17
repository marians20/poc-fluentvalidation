using Contracts.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Validators;

namespace Services;

public static class DiConfig
{
    public static IServiceCollection RegisterAutoMapper(
        this IServiceCollection services,
        params Type[] typesContainedInAssemblies)
    {
        foreach (var type in typesContainedInAssemblies)
        {
            services.AddAutoMapper(type.Assembly);
        }

        return services;
    }

    public static IServiceCollection RegisterFluentValidation(
        this IServiceCollection services,
        params Type[] typesContainedInAssemblies)
    {
        services.AddValidatorsFromAssemblies(
            typesContainedInAssemblies.Select(t => t.Assembly));

        services.AddScoped<IFullNameValidator, FullNameValidator>();

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddScoped<IPeopleService, PeopleService>();
}
