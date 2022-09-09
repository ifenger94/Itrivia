using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Helpers
{
    public static class ExpressionMethods
    {
        public enum ExpressionOperation
        {
            AND,
            OR
        }

        public static Expression<Func<T, bool>> ExpressionAppend<T>(ExpressionOperation operation, Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            switch (operation)
            {
                case ExpressionOperation.AND:
                    return BuilderExpression(left, right, ExpressionOperation.AND);
                case ExpressionOperation.OR:
                    return BuilderExpression(left, right, ExpressionOperation.OR);
                default:
                    break;
            }

            return null;
        }

        public static Expression<Func<T, bool>> BuilderExpression<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b, ExpressionOperation operation)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body;

            if (operation == ExpressionOperation.AND)
                body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            else
                body = Expression.OrElse(a.Body, visitor.Visit(b.Body));

            return Expression.Lambda<Func<T, bool>>(body, p);
        }
    }

    internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression newValue;
            if (subst.TryGetValue(node, out newValue))
            {
                return newValue;
            }
            return node;
        }
    }
}
