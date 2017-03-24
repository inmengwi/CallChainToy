using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleBiz
{
    public class DirectCallBiz
    {
        public void Method(string paramA, int praramB)
        {
            string uri = "http://www.auction.co.kr";

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
