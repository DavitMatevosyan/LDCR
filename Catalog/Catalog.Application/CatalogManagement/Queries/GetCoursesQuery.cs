using Catalog.Application.Dtos;
using Catalog.Application.Filters;
using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Shared.Results;
using MediatR;

namespace Catalog.Application.CatalogManagement.Queries;

public class GetCoursesQuery(CourseFilter filter) : BaseQuery<CourseFilter, Course>(filter), IRequest<GetCoursesResult>;


public class GetCoursesResult : BaseQueryResult
{
    public IEnumerable<Course> Courses { get; set; } = [];
}

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, GetCoursesResult>
{
    private readonly ICourseRepository courseRepository;
public GetCoursesQueryHandler(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }

    public async Task<GetCoursesResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var result = new GetCoursesResult();

        var data = await courseRepository.GetAsync(request.FilterExpression, request.Page, request.PageSize, false, cancellationToken);

        result.Courses = data;

        return result;
    }
}
