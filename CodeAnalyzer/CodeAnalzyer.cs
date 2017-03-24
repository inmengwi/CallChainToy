using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeAnalyzer.Core
{
    public class Analyzer
    {
        public IList<SyntaxNode> GetMatchPattern(MemberDeclarationSyntax methodSyntax, string StaticClassName,  string methodName)
        {
            var results = new List<SyntaxNode>();


            foreach (var node in methodSyntax.DescendantNodes().OfType<InvocationExpressionSyntax>())
            {
                var express = node.Expression;
                if (express is IdentifierNameSyntax)
                {
                    IdentifierNameSyntax identifierName = node.Expression as IdentifierNameSyntax; // identifierName is your method name
                }

                if (express is MemberAccessExpressionSyntax)
                {
                    MemberAccessExpressionSyntax memberAccessExpressionSyntax = node.Expression as MemberAccessExpressionSyntax;

                    if(
                        memberAccessExpressionSyntax.Name.ToString() == methodName
                    )
                    {
                        if(memberAccessExpressionSyntax.Expression is IdentifierNameSyntax)
                        {
                            var idns = memberAccessExpressionSyntax.Expression as IdentifierNameSyntax;

                            if (idns.Identifier.Text.Equals(StaticClassName))
                            {
                                if (memberAccessExpressionSyntax.Parent is InvocationExpressionSyntax)
                                {
                                    var ies = memberAccessExpressionSyntax.Parent as InvocationExpressionSyntax;
                                    var find = ies.ArgumentList.Arguments[0];

                                    results.Add(find);
                                }
                            }
                        }
                    }
                }
            }

            return results;
        }
    }
}