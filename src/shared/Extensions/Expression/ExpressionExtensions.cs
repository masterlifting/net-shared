using System;
using System.Linq.Expressions;

namespace Net.Shared.Extensions.Expression;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));

        var body1 = ReplaceParameter(expr1.Body, expr1.Parameters[0], parameter);
        var body2 = ReplaceParameter(expr2.Body, expr2.Parameters[0], parameter);

        var combinedBody = System.Linq.Expressions.Expression.AndAlso(body1, body2);

        return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
    }

    private static System.Linq.Expressions.Expression ReplaceParameter(
        System.Linq.Expressions.Expression body,
        ParameterExpression original,
        ParameterExpression replacement) =>
            new ParameterReplacerVisitor(original, replacement).Visit(body);

    private class ParameterReplacerVisitor(ParameterExpression original, ParameterExpression replacement) : ExpressionVisitor
    {
        private readonly ParameterExpression _original = original;
        private readonly ParameterExpression _replacement = replacement;

        protected override System.Linq.Expressions.Expression VisitParameter(ParameterExpression node) =>
            node == _original ? _replacement : base.VisitParameter(node);
    }
}
