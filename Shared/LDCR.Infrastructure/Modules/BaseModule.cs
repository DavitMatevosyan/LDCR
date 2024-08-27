using LDCR.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LDCR.Infrastructure.Modules;

public abstract class BaseModule
{
    public ModuleSettings Settings { get; set; } = null!;

    public virtual void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();

        if (Settings.DatabaseEnabled)
            AddDatabaseEngine(builder);

        if (Settings.MediatrEnabled)
        {
            builder.Services.AddMediatR(config =>
            {
                config.AutoRegisterRequestProcessors = true;
                config.RegisterServicesFromAssemblies(Assembly.Load($"{Settings.Name}.Api"),
                                                      Assembly.Load($"{Settings.Name}.Application"));
            });
        }

        if (Settings.ElasticEnabled)
        {
            // elastic here
        }
        // ... continue with all settings here
    }

    public void ConfigureGlobalMiddlewares(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseExceptionHandler();
        app.UseAuthorization();
        app.MapControllers();

        app.MapControllerRoute($"{Settings.Name}Routes",
            $"/{Settings.Name}");

        app.Map($"/{Settings.Name}", ConfigureMiddlewares);
    }

    protected abstract void ConfigureMiddlewares(IApplicationBuilder app);

    protected abstract void AddDatabaseEngine(WebApplicationBuilder builder);
}
