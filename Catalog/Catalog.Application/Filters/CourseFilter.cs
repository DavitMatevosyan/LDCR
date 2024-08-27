using Catalog.Domain.ValueObjects;
using LDCR.Shared.Results;

namespace Catalog.Application.Filters;

public class CourseFilter : FilterModel
{
    public string? Name { get; set; }
    public string? Code { get; set; }

    [BiggerThan(true)]
    public TimeSpan? MinDuration { get; set; }

    [SmallerThan]
    public TimeSpan? MaxDuration { get; set; }
    public IEnumerable<RepetitionRule>? RepetitionRules { get; set; }
    
    [BiggerThan]
    public DateTime? StartDate { get; set; }

    [SmallerThan]
    public DateTime? EndDate { get; set; }
}