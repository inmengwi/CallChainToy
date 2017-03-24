using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForClassVisitorTest
{
    public class UseWebRequest
    {
        public void DirectInvoke()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.naver.com/DirectInvoke");
            request.Method = WebRequestMethods.Http.Get;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string result = reader.ReadToEnd();

            Console.WriteLine(result);
        }

        public void ByValueInvoke()
        {
            string uri = "http://www.naver.com/ByValueInvoke";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = WebRequestMethods.Http.Get;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string result = reader.ReadToEnd();

            Console.WriteLine(result);
        }

        public void ByFunctionParameterInvoke(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = WebRequestMethods.Http.Get;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string result = reader.ReadToEnd();

            Console.WriteLine(result);
        }
    }
}
