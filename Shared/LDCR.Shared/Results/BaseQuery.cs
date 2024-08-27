using LDCR.Domain.BaseEntities;
using LDCR.Shared.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace LDCR.Shared.Results;

public class BaseQuery<T, E> where T : FilterModel where E : EntityModel
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

            ParameterExpression parameter = Expression.Parameter(typeof(E), "filter");
            Expression expression = Expression.Constant(true);

            var properties = filter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // add condition checks for int - string - datetime - in child expression add RepetitionRule - timespan
                if (property.GetValue(filter) is null)
                    continue;

                var filterType = property.GetCustomAttribute<FilterAttribute>(false);

                if (filterType is null)
                    continue;

                MemberExpression prop = Expression.Property(parameter, property.Name);
                ConstantExpression value = Expression.Constant(property.GetValue(filter));

                Expression condition;

                if (prop.Type.IsGenericType && prop.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var nullableValue = Expression.Convert(value, prop.Type);
                    condition = filterType.GetExpression(prop, nullableValue);
                }
                else
                {
                    condition = filterType.GetExpression(prop, value);
                }

                expression = Expression.AndAlso(expression, condition);
            }

            Expression<Func<E, bool>> lambda = Expression.Lambda<Func<E, bool>>(expression, parameter);

            return lambda;
        }
        catch (Exception)
        {
            // add logger log
            throw new InvalidFilterExpressionException<E>(FilterExpression);
        }
    }
}

public abstract class BaseQueryResult
{

}