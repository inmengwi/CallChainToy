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
            string path = args[0];

            var task = new Excutor().Execute(path);
            task.Wait();
        }
    }
}
