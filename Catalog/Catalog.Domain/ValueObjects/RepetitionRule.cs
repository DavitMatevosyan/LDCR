namespace Catalog.Domain.ValueObjects;

public enum RepetitionRule
{
    None = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 4, 
    Thursday = 8,
    Friday = 16,
    Saturday = 32,
    Sunday = 64,

    WeekDays = 31,
    Weekends = 96,
    Everyday = 127
}
