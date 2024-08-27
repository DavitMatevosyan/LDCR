using Catalog.Application.CatalogManagement.Commands;
using Catalog.Application.CatalogManagement.Queries;
using Catalog.Application.Dtos;
using Catalog.Application.Filters;
using Catalog.Web.Dtos;
using LDCR.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Web.Controllers;

[Route("api/Catalog/")]
[ApiController]
public class CourseController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("Course")]
    [ProducesResponseType(typeof(CourseDto), statusCode: (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddCourse([FromBody] CreateCourseDto dto)
    {
        CreateNewCourseCommand command = dto.ToTarget();

        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return result.ConvertToProblem();

        return Ok(result.Result);
    }

    [HttpGet("Course")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCourses([FromQuery] CourseFilter filter)
    {
        var query = new GetCoursesQuery(filter);

        var result = await mediator.Send(query);

        //if(result.Courses is null)
        //    return result.



        return Ok(result);
    }
}
