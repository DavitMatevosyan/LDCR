using LDCR.Shared.Exceptions;
using System.Linq.Expressions;

namespace LDCR.Shared.Results.FilterAttributes;

public class ContainsAttribute(string Name) : FilterAttribute(Name)
{
    public override Expression GetExpression(MemberExpression member, Expression constant)
    {
        if (member.Type != typeof(string))
            throw new NotImplementedExpressionForTypeException();

        var type = member.Type.GetMethod("Contains", 0, [typeof(string)]) ?? throw new NotImplementedExpressionForTypeException();

        return Expression.Call(member, type, constant);
    }
}