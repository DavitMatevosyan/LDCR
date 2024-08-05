using Catalog.Application.CatalogManagement.Commands;
using Catalog.Web.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectCatalogController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("Course")]
    public IActionResult AddCourse([FromBody] CreateCourseDto dto)
    {
        CreateNewCourseCommand command = dto.ToTarget();

        mediator.Send(command);

        return Ok(new[] { "asd", "xzc" });
    }
}
