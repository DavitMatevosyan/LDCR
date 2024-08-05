using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private protected CatalogDbContext catalogContext;

    public CourseRepository(CatalogDbContext context) : base(context)
    {
        catalogContext = context;
    }

    public async override Task<Course> AddAsync(Course entity, CancellationToken token)
    {
        if (await catalogContext.Courses.AnyAsync(x => x.Code == entity.Code, token))
            throw new InvalidOperationException($"A course with code {entity.Code} already exists");

        return await base.AddAsync(entity, token);
    }
}

public class HomeworkRepository : BaseRepository<Homework>, IHomeworkRepository
{
    public HomeworkRepository(CatalogDbContext context) : base(context)
    {
    }
}

public class NoteRepository : BaseRepository<Note>, INoteRepository
{
    public NoteRepository(CatalogDbContext context) : base(context)
    {
    }
}

public class SessionRepository : BaseRepository<Session>, ISessionRepository
{
    public SessionRepository(CatalogDbContext context) : base(context)
    {
    }
}

public class SessionReferenceRepository : BaseRepository<SessionReference>, ISessionReferenceRepository
{
    public SessionReferenceRepository(CatalogDbContext context) : base(context)
    {
    }
}

