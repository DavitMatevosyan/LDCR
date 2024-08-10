using Microsoft.AspNetCore.Builder;

namespace LDCR.Infrastructure.Modules;

public abstract class BaseModule
{
    public ModuleSettings ModuleSettings { get; set; } = null!;

    public virtual void RegisterServices(WebApplicationBuilder builder)
    {
        if (ModuleSettings.DatabaseEnabled)
            AddDatabaseEngine(builder);

        if (ModuleSettings.ElasticEnabled)
        {
            // elastic here
        }

        if (ModuleSettings.MediatrEnabled)
        {

        }
    }

    public virtual void ConfigureMiddlewares(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseExceptionHandler();
        app.UseAuthorization();
        app.MapControllers();
    }

    protected abstract void AddDatabaseEngine(WebApplicationBuilder builder);
}
