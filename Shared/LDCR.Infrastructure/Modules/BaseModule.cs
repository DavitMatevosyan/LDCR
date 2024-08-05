using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LDCR.Infrastructure.Modules;

public abstract class BaseModule
{
    public required string AssemblyName { get; set; }
    public bool DatabaseEnabled { get; set; }
    public bool ElasticEnabled { get; set; }
    public bool Enabled { get; set; }
    public bool MediatrEnabled { get; set; }
    public bool MetricsEnabled { get; set; }
    public ModuleTesting Testing { get; set; }


    public virtual void RegisterServices(WebApplicationBuilder builder)
    {
        if (DatabaseEnabled)
            AddDatabaseEngine(builder);

        if (ElasticEnabled)
        {
            // elastic here
        }

        if (MediatrEnabled)
        {

        }
            


    }

    public virtual void ConfigureMiddlewares(WebApplication app)
    {

    }

    protected abstract void AddDatabaseEngine(WebApplicationBuilder builder);
}