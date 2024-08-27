using System.Linq.Expressions;

namespace LDCR.Shared.Results.FilterAttributes;

public abstract class FilterAttribute(string name) : Attribute
{
    public string TargetPropertyName { get; init; } = name;

    public abstract Expression GetExpression(MemberExpression member, Expression constant);
}
