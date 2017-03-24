using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using CodeAnalyzer.Tests.Mock;
using CodeAnalyzer.Core;

namespace CodeAnalyzer.Tests
{
    [TestClass]
    public class CodeAnalzyerTests
    {
        [TestMethod]
        public async Task FunctionTest()
        {
            var compilation = await new StubTestProject().GetTestProjectObject();

            var classVisitor = new ClassVirtualizationVisitor();
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                classVisitor.Visit(syntaxTree.GetRoot());
            }

            foreach(var classDeclare in classVisitor.Classes)
            {
                var invokeExpressionsList1 = new Analyzer().GetMatchPattern(classDeclare.Members[0], "WebRequest", "Create");
                var invokeExpressionsList2 = new Analyzer().GetMatchPattern(classDeclare.Members[1], "WebRequest", "Create");
                var invokeExpressionsList3 = new Analyzer().GetMatchPattern(classDeclare.Members[2], "WebRequest", "Create");
            }
        }
    }
}
