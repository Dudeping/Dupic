using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRequestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");

            using (HttpWebResponse reSponse = (HttpWebResponse)webRequest.GetResponse())
            {
                if (reSponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = reSponse.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string html = reader.ReadToEnd();
                        Console.WriteLine(html);
                    }
                }
                else
                {
                    Console.WriteLine("服务器返回错误：" +  reSponse.StatusCode);
                }
            }

            Console.ReadKey();
        }
    }
}
