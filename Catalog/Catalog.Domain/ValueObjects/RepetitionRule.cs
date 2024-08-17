namespace Catalog.Domain.ValueObjects;

[Flags]
public enum RepetitionRule
{
    Unknown = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 4,
    Thursday = 8,
    Friday = 16,
    Saturday = 32,
    Sunday = 64,

    WeekDays = Monday | Tuesday | Wednesday | Thursday | Friday,
    WeekOddDays = Monday | Wednesday | Friday,
    WeekEvenDays = Tuesday | Thursday,
    Weekends = Saturday | Sunday,
    Everyday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
}
