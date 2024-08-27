using Catalog.Application.Dtos;
using Catalog.Domain.Models;
using Catalog.Domain.RepositoryContracts;
using Catalog.Domain.ValueObjects;
using LDCR.Shared;
using LDCR.Shared.Exceptions;
using LDCR.Shared.Results;
using Mapster;
using MediatR;

namespace Catalog.Application.CatalogManagement.Commands;

public class CreateNewCourseCommand : BaseCommand<CreateNewCourseCommand, Course>, IRequest<CommandResult<CourseDto>>
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public TimeSpan Duration { get; set; }
    public RepetitionRule RepetitionRule { get; set; }
    public DateTime StartDate { get; set; }
    public int SessionCount { get; set; }
    public string? SessionDefaultTopic { get; set; }
}

public class CreateNewCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateNewCourseCommand, CommandResult<CourseDto>>
{
    private readonly ICourseRepository courseRepository = courseRepository;

    public async Task<CommandResult<CourseDto>> Handle(CreateNewCourseCommand request, CancellationToken cancellationToken)
    {
        var courseId = Guid.NewGuid();
        var result = new CommandResult<CourseDto>();

        var canParseStartDateDOW = Enum.TryParse(request.StartDate.DayOfWeek.ToString(), out RepetitionRule startDateDOW);

        if (!canParseStartDateDOW || startDateDOW == RepetitionRule.Unknown)
            throw new ValidationException("Can't parse given date to weekday");

        if ((startDateDOW & request.RepetitionRule) == RepetitionRule.Unknown)
            throw new ValidationException("The given start day doesn't fit in the repetition rules", (request.RepetitionRule.ToString(), request.StartDate.ToString()));

        var sessions = new List<Session>();

        if (request.RepetitionRule != RepetitionRule.Unknown)
        {
            var nextSessionStartDate = request.StartDate;
            for (int i = 0; i < request.SessionCount; i++)
            {
                var session = new Session()
                {
                    Topic = request.SessionDefaultTopic ?? $"{request.Name} Session",
                    CourseId = courseId,
                    StartDate = nextSessionStartDate,
                    
                };

                sessions.Add(session);

                if(i != request.SessionCount - 1)
                    nextSessionStartDate = FindNextSessionDate(request, nextSessionStartDate);
            }
        }

        var course = request.ToEntity();

        course.Sessions = sessions;

        await courseRepository.AddAsync(course, cancellationToken);

        await courseRepository.SaveChangesAsync();

        result.Result = course.Adapt<CourseDto>();

        return result;
    }

    private DateTime FindNextSessionDate(CreateNewCourseCommand request, DateTime nextSessionStartDate)
    {
        var current = nextSessionStartDate;

        switch (request.RepetitionRule)
        {
            case RepetitionRule.Everyday:
                return current.AddDays(1);
            case RepetitionRule.WeekDays:
                if (current.DayOfWeek == DayOfWeek.Friday)
                    return current.AddDays(3);
                return current.AddDays(1);
            case RepetitionRule.Weekends:
                if (current.DayOfWeek == DayOfWeek.Saturday)
                    return current.AddDays(1);
                return current.AddDays(6);
            case RepetitionRule.WeekEvenDays:
                if (current.DayOfWeek == DayOfWeek.Tuesday)
                    return current.AddDays(2);
                return current.AddDays(5);
            case RepetitionRule.WeekOddDays:
                if (current.DayOfWeek == DayOfWeek.Monday || current.DayOfWeek == DayOfWeek.Wednesday)
                    return current.AddDays(2);
                return current.AddDays(3);
            default:
                var canParse = Enum.TryParse(current.DayOfWeek.ToString(), out RepetitionRule parsedDate);
                if (canParse && request.RepetitionRule == parsedDate)
                    return current.AddDays(7);

                canParse = Enum.TryParse(request.RepetitionRule.ToString(), out DayOfWeek dayOfWeek);
                if (canParse)
                {
                    int daysToAdd = (int)dayOfWeek - (int)current.DayOfWeek;
                    if (daysToAdd < 0)
                        daysToAdd += 7;

                    return current.AddDays(daysToAdd);
                }
                throw new ArgumentException($"Can't parse the given dates source: {current}, target: {request.RepetitionRule}");
        }
    }
}

