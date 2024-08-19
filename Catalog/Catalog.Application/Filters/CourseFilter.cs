using Catalog.Domain.ValueObjects;
using LDCR.Shared.Results;

namespace Catalog.Application.Filters;

public record CourseFilter(
    string? Name, 
    string? Code, 
    TimeSpan? MinDuration, 
    TimeSpan? MaxDuration, 
    IEnumerable<RepetitionRule>? RepetitionRules, 
    DateTime? StartDate, 
    DateTime? EndDate)  : IFilter;
