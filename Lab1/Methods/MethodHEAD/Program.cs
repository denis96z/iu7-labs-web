using System;
using System.Net;

namespace MethodHEAD
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] uris = new string[]
            {
                "https://vk.com", "https://www.apple.com", "https://www.msn.com"
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
                request.Method = "HEAD";
                request.Timeout = 5000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Console.WriteLine(response.Method +
                    @" / HTTP/" + response.ProtocolVersion);
                foreach (var h in response.Headers.AllKeys)
                {
                    Console.WriteLine(h + ": " + response.Headers[h]);
                }
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
