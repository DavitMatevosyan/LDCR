using LDCR.Domain.Exceptions;
using LDCR.Infrastructure.Modules;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LDCR.Infrastructure.Controllers;

public class ModuleLoader(IConfiguration configuration)
{
    private readonly IConfiguration configuration = configuration;

    public IEnumerable<BaseModule> LoadModules()
    {

        // convert to composite config class and base module class
        var moduleConfigs = configuration.GetSection("Modules").Get<List<BaseModule>>() ?? throw new ConfigurationsNotFoundException("The configurations were not found");

        List<Assembly> modules = [];
        foreach (var module in moduleConfigs)
        {
            if (module.Enabled)
                modules.Add(Assembly.Load(module.AssemblyName));
        }

        var moduleTypes = modules
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(BaseModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var moduleType in moduleTypes)
        {
            var moduleConfig = moduleConfigs.FirstOrDefault(mc => mc.AssemblyName == moduleType.AssemblyQualifiedName);

            if (moduleConfig != null)
            {
                yield return (BaseModule)Activator.CreateInstance(moduleType)!;
            }
        }

    }
}