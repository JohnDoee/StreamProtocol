using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Net;

namespace DelugeStream
{
    class DelugeStream
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 1 || args.Length > 3)
            {
                Console.WriteLine("Wrong number of arguments");
                return;
            }

            string delugeUrl = ConfigurationManager.AppSettings["delugeUrl"];
            var url = String.Format("{0}?url={1}", delugeUrl, System.Uri.EscapeDataString(args[0]));
            if (args.Length >= 2 && args[1] != "%2")
                url += "&file=" + System.Uri.EscapeDataString(args[1]);

            if (args.Length >= 3 && args[1] != "%3")
                url += "&infohash=" + System.Uri.EscapeDataString(args[2]);

            Console.WriteLine($"Opening url ${url}");
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Deluge-Streamer 1.0.0");
            try {
                client.OpenRead(url);
            } catch (WebException) { }
        }
    }
}
