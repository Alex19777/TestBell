﻿// <copyright file="TypePropertiesNameResolver.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bellatrix.Utilities;

public static class TypePropertiesNameResolver
{
    private static readonly string expressionCannotBeNullMessage = "The expression cannot be null.";
    private static readonly string invalidExpressionMessage = "Invalid expression.";

    public static string GetMemberName<T>(Expression<Func<T, object>> expression)
    where T : class
    {
        return GetMemberName(expression.Body);
    }

    public static List<string> GetMemberNames<T>(params Expression<Func<T, object>>[] expressions)
        where T : class
    {
        List<string> memberNames = new List<string>();
        foreach (var cExpression in expressions)
        {
            memberNames.Add(GetMemberName(cExpression.Body));
        }

        return memberNames;
    }

    private static string GetMemberName(Expression expression)
    {
        if (expression == null)
        {
            throw new ArgumentException(expressionCannotBeNullMessage);
        }

        if (expression is MemberExpression)
        {
            // Reference type property or field
            var memberExpression = (MemberExpression)expression;
            return memberExpression.Member.Name;
        }

        if (expression is MethodCallExpression)
        {
            // Reference type method
            var methodCallExpression = (MethodCallExpression)expression;
            return methodCallExpression.Method.Name;
        }

        if (expression is UnaryExpression)
        {
            // Property, field of method returning value type
            var unaryExpression = (UnaryExpression)expression;
            return GetMemberName(unaryExpression);
        }

        throw new ArgumentException(invalidExpressionMessage);
    }

    private static string GetMemberName(UnaryExpression unaryExpression)
    {
        if (unaryExpression.Operand is MethodCallExpression)
        {
            var methodExpression = (MethodCallExpression)unaryExpression.Operand;
            return methodExpression.Method.Name;
        }

        return ((MemberExpression)unaryExpression.Operand).Member.Name;
    }
}