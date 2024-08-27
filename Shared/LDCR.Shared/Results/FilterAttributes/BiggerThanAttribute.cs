using System.Linq.Expressions;

namespace LDCR.Shared.Results.FilterAttributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class BiggerThanAttribute(string Name, bool AllowEqual = false) : FilterAttribute(Name)
{
    public override Expression GetExpression(MemberExpression member, Expression constant)
    {
        return AllowEqual
            ? Expression.GreaterThanOrEqual(member, constant)
            : Expression.GreaterThan(member, constant);
    }
}
