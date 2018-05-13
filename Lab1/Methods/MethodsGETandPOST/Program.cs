using System;
using System.IO;
using System.Net;

namespace MethodsGETandPost
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] uris = new string[]
            {
                "https://www.yandex.ru", "https://www.google.com"
            };

            foreach (string uri in uris)
            {
                HandleGETRequest(uri);
                HandlePOSTRequest(uri);
            }
            Console.ReadLine();
        }

        static void HandleGETRequest(string uri)
        {
            try
            {
                Console.WriteLine(uri);

                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = 5000;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Console.WriteLine("Length: " + response.ContentLength);

                /*StreamReader reader = new StreamReader(response.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();*/
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

        static void HandlePOSTRequest(string uri)
        {
            try
            {
                Console.WriteLine(uri);

                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "POST";
                request.Timeout = 5000;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Console.WriteLine("Length: " + response.ContentLength);

                /*StreamReader reader = new StreamReader(response.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();*/
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
