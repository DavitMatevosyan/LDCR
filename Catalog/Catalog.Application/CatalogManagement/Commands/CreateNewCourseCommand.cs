using Catalog.Application.Results;
using Catalog.Domain.RepositoryContracts;
using MediatR;

namespace Catalog.Application.CatalogManagement.Commands;

public class CreateNewCourseCommand : IRequest<CommandResult>
{
    public required string Name { get; set; }
    public required string Code { get; set; }

    //public List<SessionDto> Sessions { get; set; }
}

public class CreateNewCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateNewCourseCommand, CommandResult>
{
    private readonly ICourseRepository courseRepository = courseRepository;

    public async Task<CommandResult> Handle(CreateNewCourseCommand request, CancellationToken cancellationToken)
    {

        //request.ada
        //courseRepository.AddAsync()

        throw new NotImplementedException();
    }
}

