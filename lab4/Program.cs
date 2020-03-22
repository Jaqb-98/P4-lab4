using System;
using RestSharp;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var st = new Stopwatch();


            var google = new Website("https://www.google.com");
            var ath = new Website("https://ath.bielsko.pl");
            var fb = new Website("https://facebook.com");
            var wiki = new Website("https://en.wikipedia.org/");
            var anyapi = new Website("https://any-api.com");
            var plany = new Website("https://plany.ath.bielsko.pl");

            var tasks = new List<Task<IRestResponse>>();

            st.Start();

            tasks.Add(google.DownloadAsync("/"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(ath.DownloadAsync("/"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(fb.DownloadAsync("/"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(wiki.DownloadAsync("/wiki/.NET_Core"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(anyapi.DownloadAsync("/"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(plany.DownloadAsync("/plan.php?type=0&id=12647"));
            Console.WriteLine(st.Elapsed);
            tasks.Add(ath.DownloadAsync("/graficzne-formy-przekazu-informacji/"));
            Console.WriteLine(st.Elapsed);

            Console.WriteLine("---------------------------------");
            //Console.WriteLine(Task.WhenAny(tasks).Result.Result.Content);
            Console.WriteLine(st.Elapsed);
            var htmlCodes = Task.WhenAll(tasks).Result;
            foreach (var site in htmlCodes)
            {
                Console.WriteLine(site.Content.Length);
            }
            Console.WriteLine(st.Elapsed);
            st.Stop();

          
        }
    }
}
