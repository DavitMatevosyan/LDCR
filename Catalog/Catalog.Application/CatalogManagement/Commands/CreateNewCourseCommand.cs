using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Shared;
using LDCR.Shared.Results;
using MediatR;

namespace Catalog.Application.CatalogManagement.Commands;

public class CreateNewCourseCommand : BaseCommand<CreateNewCourseCommand, Course>, IRequest<CommandResult>
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
        var result = new CommandResult(request);

        var course = request.ToEntity();

        await courseRepository.AddAsync(course, cancellationToken);

        return result;
    }
}

