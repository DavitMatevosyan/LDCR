using Catalog.Application.Dtos;
using Catalog.Application.Filters;
using LDCR.Shared.Results;

namespace Catalog.Application.CatalogManagement.Queries;

public class GetCoursesQuery : BaseQuery<CourseFilter>
{
    public GetCoursesQuery(int page, int pageSize, CourseFilter filter)
    {
        Page = page;
        PageSize = pageSize;
        FilterExpression = BuildFilterExpression(filter);
    }
}

public class GetCoursesQueryHandler
{
}
