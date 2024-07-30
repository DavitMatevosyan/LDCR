using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCatalogController : ControllerBase
    {
        [HttpGet("Project")]
        public IActionResult GetAll()
        {
            return Ok(new[] { "asd", "xzc" });
        }
    }
}
