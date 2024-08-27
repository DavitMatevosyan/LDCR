using Catalog.Application.Filters;
using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using LDCR.Shared.Results;
using MediatR;

namespace Catalog.Application.CatalogManagement.Queries;

public class GetCoursesQuery(CourseFilter filter) : BaseQuery<CourseFilter, Course>(filter), IRequest<GetCoursesResult>;

public class GetCoursesResult(int page, int pageSize) : BaseQueryResult(page, pageSize)
{
    public IEnumerable<Course> Courses { get; set; } = [];
}

public class GetCoursesQueryHandler(ICourseRepository courseRepository) : IRequestHandler<GetCoursesQuery, GetCoursesResult>
{
    public async Task<GetCoursesResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var result = new GetCoursesResult(request.Page, request.PageSize);

        var data = await courseRepository.GetAsync(request.FilterExpression, request.Page, request.PageSize, false, cancellationToken);

        result.Courses = data;

        return result;
    }
}
