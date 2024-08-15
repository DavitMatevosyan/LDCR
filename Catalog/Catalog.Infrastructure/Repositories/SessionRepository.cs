using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Infrastructure.Implementations;

namespace Catalog.Infrastructure.Repositories;

public class SessionRepository(CatalogDbContext context) : BaseRepository<Session>(context), ISessionRepository
{

}
