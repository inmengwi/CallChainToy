using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForClassVisitorTest
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ByFunctionInvoke
    {
        public void Invoke()
        {
            new UseWebRequest().ByFunctionParameterInvoke("http://www.naver.com/invoke");
        }
    }
}
