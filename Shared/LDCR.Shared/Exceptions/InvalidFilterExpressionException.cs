using LDCR.Domain.BaseEntities;
using System.Linq.Expressions;
using System.Net;

namespace LDCR.Shared.Exceptions;

public class InvalidFilterExpressionException<E> 
    : BaseException 
    where E : EntityModel
{
    public InvalidFilterExpressionException(Expression<Func<E, bool>> filterExpression, params (string Key, string Value)[] extensionParams) 
        : base("Invalid Expression", (int)HttpStatusCode.BadRequest, extensionParams)
    {
        Extensions.Add("Name", filterExpression.Name!);

        foreach (var param in filterExpression.Parameters)
            Extensions.Add(param.Type.Name, param?.Name!);
    }
}
