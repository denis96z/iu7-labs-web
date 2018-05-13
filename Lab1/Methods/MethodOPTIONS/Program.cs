using System;
using System.Net;

namespace MethodOPTIONS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] uris = new string[]
            {
                "http://mail.ru", "http://ya.ru", "https://www.rambler.ru",
                "https://www.google.ru", "https://github.com",
                "https://www.linkedin.com", "https://www.apple.com"
            };

            foreach (string uri in uris)
            {
                HandleRequest(uri);
            }
            Console.ReadLine();
        }

        static void HandleRequest(string uri)
        {
            try
            {
                Console.WriteLine(uri);

                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "OPTIONS";
                request.Timeout = 5000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Console.WriteLine(response.Method +
                    @" / HTTP/" + response.ProtocolVersion);
                Console.WriteLine("Allow: " + response.Headers["Allow"]);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}
