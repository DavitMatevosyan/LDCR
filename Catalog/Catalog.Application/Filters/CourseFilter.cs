using Catalog.Domain.Models;
using Catalog.Domain.ValueObjects;
using LDCR.Shared.Results;
using LDCR.Shared.Results.FilterAttributes;

namespace Catalog.Application.Filters;

public class CourseFilter : FilterModel
{
    [Contains(nameof(Course.Name))]
    public string? Name { get; set; }

    //[EqualsTo(nameof(Course.Code))]
    public string? Code { get; set; }

    [SmallerThan(nameof(Course.Duration))]
    public TimeSpan? MinDuration { get; set; }

    [BiggerThan(nameof(Course.Duration), true)]
    public TimeSpan? MaxDuration { get; set; }

    //[WeekDays(nameof(Course.RepetitionRule))]
    public IEnumerable<RepetitionRule>? RepetitionRules { get; set; }

    [BiggerThan(nameof(Course.StartDate), true)]
    public DateTime? MinStartDate { get; set; }

    [SmallerThan(nameof(Course.StartDate), true)]
    public DateTime? MaxStartDate { get; set; }
}