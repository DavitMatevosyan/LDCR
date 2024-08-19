using Catalog.Application.CatalogManagement.Commands;
using Catalog.Domain.Models;
using Catalog.Domain.ValueObjects;
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
    public TimeSpan Duration { get; set; }
    public RepetitionRule RepetitionRule { get; set; }
    public DateTime StartDate { get; set; }
    public int SessionCount { get; set; }
    public string? SessionDefaultTopic { get; set; }
}