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
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Excutor().Execute();
            task.Wait();
        }
    }
}
