using Catalog.Application.CatalogManagement.Commands;
using Catalog.Web.Dtos;
using LDCR.Infrastructure.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("Course")]
    public async Task<IActionResult> AddCourse([FromBody] CreateCourseDto dto)
    {
        CreateNewCourseCommand command = dto.ToTarget();

        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return result.ConvertToProblem();

        return Ok(result.Command);
    }
}
