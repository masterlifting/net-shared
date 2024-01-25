using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Net.Shared.Abstractions.Models.Settings;

namespace Net.Shared;

public static class Registrations
{
    public static IServiceCollection AddCorrelationSettings(this IServiceCollection services)
    {
        services
            .AddOptions<CorrelationSettings>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration
                    .GetSection(CorrelationSettings.SectionName)
                    .Bind(settings);
            })
            .ValidateOnStart()
            .Validate(x => x.Id != Guid.Empty, "Correlation id should not be empty.");

        return services;
    }
}
