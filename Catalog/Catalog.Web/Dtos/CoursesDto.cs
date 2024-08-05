using Catalog.Application.CatalogManagement.Commands;
using LDCR.Shared;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Dtos;

public class CreateCourseDto : BaseDto<CreateNewCourseCommand>
{
    [Length(1, 100)]
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [Length(3, 5, ErrorMessage = "Invalid Code Length")]
    public required string Code { get; set; } = null!;
}
