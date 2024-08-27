using System.Linq.Expressions;

namespace LDCR.Shared.Results;

public abstract class FilterModel
{
    public int Page { get; init; }
    public int PageSize { get; init; }
}


public abstract class FilterAttribute : Attribute
{
    public abstract Expression GetExpression(MemberExpression member, Expression constant);
}


[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class BiggerThanAttribute(bool AllowEqual = false) : FilterAttribute
{
    public override Expression GetExpression(MemberExpression member, Expression constant)
    {
        return AllowEqual
            ? Expression.GreaterThanOrEqual(member, constant)
            : Expression.GreaterThan(member, constant);
    }
}


[AttributeUsage(AttributeTargets.Property)]
public class SmallerThanAttribute(bool AllowEqual = false) : FilterAttribute
{
    public override Expression GetExpression(MemberExpression member, Expression constant)
    {
        return AllowEqual
            ? Expression.LessThanOrEqual(member, constant)
            : (Expression)Expression.LessThan(member, constant);
    }

}