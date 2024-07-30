using Catalog.Domain.RepositoryContracts;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Repositories;

namespace Catalog.Web.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        => services
            .AddScoped<CatalogDbContext>()
            .AddScoped<ICourseRepository, CourseRepository>()
            .AddScoped<IHomeworkRepository, HomeworkRepository>()
            .AddScoped<INoteRepository, NoteRepository>()
            .AddScoped<ISessionRepository, SessionRepository>()
            .AddScoped<ISessionReferenceRepository, SessionReferenceRepository>();
}
