using LDCR.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Reflection;

namespace LDCR.Infrastructure.Modules;

public class ModuleLoader(IConfiguration configuration)
{
    private readonly IConfiguration configuration = configuration;

    public IEnumerable<BaseModule> LoadModules()
    {
        // convert to composite config class and base module class
        var moduleSettings = configuration.GetSection("Modules").Get<List<ModuleSettings>>();

        if (moduleSettings!.Count == 0)
            throw new BaseException("The configurations were not found", (int)HttpStatusCode.NotImplemented);

        List<Assembly> modules = [];
        foreach (var module in moduleSettings)
        {
            if (module.Enabled)
                modules.Add(Assembly.Load($"{module.Name}.Api"));
        }

        var moduleTypes = modules
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(BaseModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var moduleType in moduleTypes)
        {
            var moduleConfig = moduleSettings.FirstOrDefault(mc => mc.Name == moduleType.Name);

            if (moduleConfig != null)
            {
                var module = (BaseModule)Activator.CreateInstance(moduleType)!;
                module.Settings = moduleConfig;

                yield return module;
            }
        }
    }
}