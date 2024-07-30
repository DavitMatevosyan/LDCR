using Catalog.Domain.Models;
using LDCR.Domain.Contracts;

namespace Catalog.Domain.RepositoryContracts;

public interface ICourseRepository : IBaseRepository<Course>
{
}

public interface IHomeworkRepository : IBaseRepository<Homework>
{
}

public interface INoteRepository : IBaseRepository<Note>
{
}

public interface ISessionRepository : IBaseRepository<Session>
{
}

public interface ISessionReferenceRepository : IBaseRepository<SessionReference>
{
}
