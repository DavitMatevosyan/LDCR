using Catalog.Domain.Models;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.Dtos;

public record CourseDto(
    string Name, 
    string Code, 
    TimeSpan Duration, 
    RepetitionRule RepetitionRule, 
    DateTime StartDate, 
    ICollection<SessionDto>? Sessions);

public record SessionDto(
    string Topic, 
    string? Description, 
    DateTime StartDate, 
    Course Course, 
    IEnumerable<SessionReference>? SessionReferences, 
    IEnumerable<Homework>? Homeworks, 
    IEnumerable<Note>? Notes);
