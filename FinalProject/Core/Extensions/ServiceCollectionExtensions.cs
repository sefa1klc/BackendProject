using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] models)
    {
        foreach (var model in models)
        {
            model.Load(serviceCollection);
        }
        return ServiceTool.Create(serviceCollection);
    }
}