using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Compost.Reflection
{
    public static class Reflector
    {
        public static T[] GetEnumValues<T>()
        {
            return (T[]) Enum.GetValues(typeof (T));
        }

        public static MemberInfo MemberInfo<TType, TReturn>(Expression<Func<TType, TReturn>> expression)
        {
            return GetMemberInfo(expression);
        }

        public static MemberInfo MemberInfo<TReturn>(Expression<Func<TReturn>> expression)
        {
            return GetMemberInfo(expression);
        }

        public static string MemberName<TType, TReturn>(Expression<Func<TType, TReturn>> expression)
        {
            return MemberInfo(expression).Name;
        }

        public static string MemberName<TReturn>(Expression<Func<TReturn>> expression)
        {
            return MemberInfo(expression).Name;
        }

        public static MethodInfo MethodInfo(Expression<Action> expression)
        {
            return GetMethodInfo(expression);
        }

        public static MethodInfo MethodInfo<TType>(Expression<Action<TType>> expression)
        {
            return GetMethodInfo(expression);
        }

        public static MethodInfo MethodInfo<TReturn>(Expression<Func<TReturn>> expression)
        {
            return GetMethodInfo(expression);
        }

        public static MethodInfo MethodInfo<TType, TReturn>(Expression<Func<TType, TReturn>> expression)
        {
            return GetMethodInfo(expression);
        }

        public static string MethodName(Expression<Action> expression)
        {
            return MethodInfo(expression).Name;
        }

        public static string MethodName<TType>(Expression<Action<TType>> expression)
        {
            return MethodInfo(expression).Name;
        }

        public static string MethodName<TReturn>(Expression<Func<TReturn>> expression)
        {
            return MethodInfo(expression).Name;
        }

        public static string MethodName<TType, TReturn>(Expression<Func<TType, TReturn>> expression)
        {
            return MethodInfo(expression).Name;
        }

        private static MemberInfo GetMemberInfo<TDelegat>(Expression<TDelegat> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
                return memberExpression.Member;

            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
                if (memberExpression != null)
                    return memberExpression.Member;
            }

            var constantExpression = expression.Body as ConstantExpression;
            if (constantExpression != null)
                throw new NotAMemberException(
                    "The supplied expression uses a constant. " +
                    "Member information cannot be retrieved from a constant expression. " +
                    "Expression: " + expression);

            throw new NotAMemberException(expression.ToString());
        }

        private static MethodInfo GetMethodInfo<TDelegate>(Expression<TDelegate> expression)
        {
            var methodExpression = expression.Body as MethodCallExpression;
            if (methodExpression != null)
                return methodExpression.Method;

            throw new NotAMethodException(expression.ToString());
        }
    }

    public class NotAMemberException : Exception
    {
        public NotAMemberException() {}

        public NotAMemberException(string message) : base(message) {}

        public NotAMemberException(string message, Exception innerException) : base(message, innerException) {}
    }

    public class NotAMethodException : Exception
    {
        public NotAMethodException() {}

        public NotAMethodException(string message) : base(message) {}

        public NotAMethodException(string message, Exception innerException) : base(message, innerException) {}
    }
}