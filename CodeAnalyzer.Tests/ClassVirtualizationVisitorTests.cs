using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAnalyzer.Tests
{
    [TestClass]
    public class ClassVirtualizationVisitorTests
    {
        [TestMethod]
        public async Task ProjectForClassVisitorFunctionListTest()
        {
            var compilation = await new StubTestProject().GetTestProjectObject();

            var classVisitor = new ClassVirtualizationVisitor();

            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                classVisitor.Visit(syntaxTree.GetRoot());
            }

            var classes = classVisitor.Classes;

            var classDirectInvoke = classes.Where(c => c.Identifier.Text == "DirectInvoke").First();
            //classA.Members.First().Contains()

            Assert.IsTrue(classDirectInvoke.Members.Count() == 2);
        }

        [TestMethod]
        public async Task ProjectForClassVisitorClassCounterTest()
        {
            var compilation = await new StubTestProject().GetTestProjectObject();

            var classVisitor = new ClassVirtualizationVisitor();
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                classVisitor.Visit(syntaxTree.GetRoot());
            }

            var classes = classVisitor.Classes; // list of classes in your solution
            
            Assert.IsTrue(classes.Count() == 1);
        }
    }
}
