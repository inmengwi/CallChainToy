using CodeAnalyzer.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynTest
{
    public class Excutor
    {
        public async Task Execute(string slnPath)
        {
            var workspace = MSBuildWorkspace.Create();
            var solution = await workspace.OpenSolutionAsync(slnPath);

            foreach(Project project in solution.Projects)
            {
                var compilation = await project.GetCompilationAsync();

                var classVisitor = new ClassVirtualizationVisitor();
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    classVisitor.Visit(syntaxTree.GetRoot());
                }

                foreach (var classDeclare in classVisitor.Classes)
                {
                    foreach (var method in classDeclare.Members)
                    {
                        var syntaxNodes = new Analyzer().GetMatchPattern(method, "WebRequest", "Create");
                    }
                }
            }
        }
    }
}
