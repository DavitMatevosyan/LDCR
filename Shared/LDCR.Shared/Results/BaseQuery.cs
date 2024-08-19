using LDCR.Shared.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace LDCR.Shared.Results;

public abstract class BaseQuery<T> where T : IFilter
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    protected Expression<Func<T, bool>>? FilterExpression { get; init; }

    public Func<T, bool> Predicate =>
        FilterExpression?.Compile() ?? throw new InvalidFilterExpressionException<T>(FilterExpression!);

    protected virtual Expression<Func<T, bool>> BuildFilterExpression(T filter)
    {
        if (filter == null)
            return t => true;

        ParameterExpression parameter = Expression.Parameter(typeof(T), "filter");
        Expression expression = Expression.Constant(true);

        var properties = filter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            // add condition checks for int - string - datetime - in child expression add RepetitionRule - timespan

            MemberExpression prop = Expression.Property(parameter, property.Name);
            ConstantExpression value = Expression.Constant(property.GetValue(filter));
            BinaryExpression condition = Expression.Equal(prop, value);

            expression = Expression.AndAlso(expression, condition);
        }

        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);

        return lambda;
    }
}

public abstract class BaseQueryResult
{

}