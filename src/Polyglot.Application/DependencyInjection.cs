using System.Globalization;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Polyglot.Application.Abstractions.Behaviors;
using Polyglot.Application.Exercises.GetExercise;

namespace Polyglot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            configuration.AddOpenBehavior(typeof(QueryCachingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("ru");

        services.AddScoped<ExerciseConverter>();

        return services;
    }
}
