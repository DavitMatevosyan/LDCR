using System.Linq.Expressions;

namespace LDCR.Shared.Results.FilterAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class SmallerThanAttribute(string Name, bool AllowEqual = false) : FilterAttribute(Name)
{
    public override Expression GetExpression(MemberExpression member, Expression constant)
    {
        return AllowEqual
            ? Expression.LessThanOrEqual(member, constant)
            : (Expression)Expression.LessThan(member, constant);
    }
}