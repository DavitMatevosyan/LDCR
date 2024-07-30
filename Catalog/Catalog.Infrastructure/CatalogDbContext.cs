using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure
{
    public class CatalogDbContext(DbContextOptions opts, IConfiguration configuration) : ModuleDbContext(opts, configuration)
    {
        protected override string Schema => "Catalog";
    }
}
