using Catalog.Infrastructure;
using LDCR.Infrastructure.Modules;
using LDCR.Shared.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Web.Extensions;

public class Catalog : BaseModule
{
    public override void RegisterServices(WebApplicationBuilder builder)
    {
        base.RegisterServices(builder);

        // Module specific additional services
        builder.Services.AddRepositoryServices();
    }

    protected override void ConfigureMiddlewares(IApplicationBuilder app)
    {

    }

    protected override void AddDatabaseEngine(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(ModuleConstants.Catalog)));
    }
}
