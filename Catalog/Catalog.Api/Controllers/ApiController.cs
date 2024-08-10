using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator mediator = mediator;
}
