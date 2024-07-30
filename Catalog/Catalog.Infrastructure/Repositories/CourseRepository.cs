using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Infrastructure.Implementations;

namespace Catalog.Infrastructure.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(CatalogDbContext context) : base(context)
    {
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

