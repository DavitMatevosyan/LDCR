using LDCR.Infrastructure.Controllers;
using LDCR.Infrastructure.Modules;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LDCR.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var moduleSettings = configuration.GetSection("Modules").Get<List<ModuleSettings>>();

        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                foreach (var module in moduleSettings!)
                {
                    if (module.Enabled)
                    {
                        var moduleAssembly = Assembly.Load($"{module.Name}.Api");

                        manager.ApplicationParts.Add(new AssemblyPart(moduleAssembly));

                    }
                }
            });

        //services.AddControllers()
        //    .ConfigureApplicationPartManager(manager =>
        //    {
        //        manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        //    });

        return services;
    }
}
