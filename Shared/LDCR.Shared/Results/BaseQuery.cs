using LDCR.Domain.BaseEntities;
using LDCR.Shared.Exceptions;
using LDCR.Shared.Results.FilterAttributes;
using System.Linq.Expressions;
using System.Reflection;

namespace LDCR.Shared.Results;

public class BaseQuery<T, E>
    where T : FilterModel
    where E : EntityModel
{
    public int Page { get; init; }
    public int PageSize { get; init; }

    public Expression<Func<E, bool>> FilterExpression { get; init; }

    public BaseQuery(T filter)
    {
        Page = filter.Page;
        PageSize = filter.PageSize;
        FilterExpression = BuildFilterExpression(filter);
    }


    protected virtual Expression<Func<E, bool>> BuildFilterExpression(T filter)
    {
        try
        {
            if (filter == null)
                return t => true;

            ParameterExpression finalExpression = Expression.Parameter(typeof(E), "filter");
            Expression expression = Expression.Constant(true);

            var properties = filter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.GetValue(filter) is null)
                    continue;

                var filterType = property.GetCustomAttribute<FilterAttribute>(false);
                if (filterType is null)
                    continue;

                MemberExpression member = Expression.Property(finalExpression, filterType.TargetPropertyName);
                ConstantExpression value = Expression.Constant(property.GetValue(filter));

                Expression condition;

                if (member.Type.IsGenericType && member.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var nullableValue = Expression.Convert(value, member.Type);
                    condition = filterType.GetExpression(member, nullableValue);
                }
                else
                {
                    condition = filterType.GetExpression(member, value);
                }

                expression = Expression.AndAlso(expression, condition);
            }

            Expression<Func<E, bool>> lambda = Expression.Lambda<Func<E, bool>>(expression, finalExpression);

            return lambda;
        }
        catch (Exception)
        {
            // add logger log
            throw new InvalidFilterExpressionException<E>(FilterExpression);
        }
    }
}

public abstract class BaseQueryResult(int page, int pageSize)
{
    public int Page { get; init; } = page;
    public int PageSize { get; init; } = pageSize;
}