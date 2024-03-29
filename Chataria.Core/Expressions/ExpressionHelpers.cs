﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Chataria.Core
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lamba">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Set the underlying properties value to given value from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</</typeparam>
        /// <param name="lamba">The expression</param>
        /// /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            // converts a lambda () => some.Property, to some.Property
             var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
