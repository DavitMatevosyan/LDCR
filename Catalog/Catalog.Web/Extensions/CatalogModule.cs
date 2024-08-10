using Catalog.Infrastructure;
using LDCR.Infrastructure.Modules;
using LDCR.Shared.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Web.Extensions;

public class Catalog : BaseModule
{
    public override void RegisterServices(WebApplicationBuilder builder)
    {
        base.RegisterServices(builder);
        // Module specific additional services

        builder.Services.AddMediatR(config =>
        {
            config.AutoRegisterRequestProcessors = true;
            config.RegisterServicesFromAssemblies(Assembly.Load("Catalog"),
                                                  Assembly.Load("Catalog.Application"));
        });

        builder.Services.AddRepositoryServices();
    }

    public override void ConfigureMiddlewares(WebApplication app)
    {
        base.ConfigureMiddlewares(app);
        // add additional middlewares if necessary
    }

    protected override void AddDatabaseEngine(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(ModuleConstants.Catalog)));
    }
}
