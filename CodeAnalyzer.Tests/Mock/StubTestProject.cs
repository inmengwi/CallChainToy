using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeAnalyzer.Tests
{
    public class StubTestProject
    {
        public async Task<Compilation> GetTestProjectObject()
        {
            var slnPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "RoslynTest.sln"));

            var workspace = MSBuildWorkspace.Create();
            var solution = await workspace.OpenSolutionAsync(slnPath);

            Project project = solution.Projects.First(x => x.Name == "ProjectForClassVisitorTest");
            return await project.GetCompilationAsync();
        }
    }
}
