using System;
using System.Linq.Expressions;

namespace Net.Shared.Extensions.Expression;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
    {
        var invokedExpression = System.Linq.Expressions.Expression.Invoke(secondExpression, firstExpression.Parameters);
        var combinedExpression = System.Linq.Expressions.Expression.AndAlso(firstExpression.Body, invokedExpression);
        return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(combinedExpression, firstExpression.Parameters);
    }
}
