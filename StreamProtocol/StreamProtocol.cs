using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.Reflection;

namespace StreamProtocol
{
    class StreamProtocol
    {
        static Mutex mutex = new Mutex(true, "{72433F73-C01F-4830-8C7F-4B74D98A3F8E}");
        [STAThread]
        public static void Main(string[] args)
        {
            string UrlPrefix = ConfigurationManager.AppSettings["UrlPrefix"];
            Debug.WriteLine("Number of command line parameters = {0}", args.Length);
            if (args.Length == 1 && args[0].StartsWith($"{UrlPrefix}+"))
            {
                string url = args[0].Substring(UrlPrefix.Length + 1);
                Debug.WriteLine($"Handling url {url}");
                ProtocolHandlerManager.HandleUrl(url);
            }
            else if (args.Length == 1 && args[0] == "/register")
            {
                Debug.WriteLine("Registering protocols");
                ProtocolHandlerManager
                    .GetProtocolHandlers()
                    .ForEach((ph) => ph.RegisterHandler());
            }
            else if (args.Length == 1 && args[0] == "/unregister")
            {
                Debug.WriteLine("Unregistering protocols");
                ProtocolHandlerManager
                    .GetProtocolHandlers()
                    .ForEach((ph) => ph.UnregisterHandler());
            }
            else
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.Run(new TrayIcon());
                    mutex.ReleaseMutex();
                }
            }

        }

        static void ShowConfig()
        {

            // For read access you do not need to call OpenExeConfiguraton
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                Console.WriteLine("Key: {0}, Value: {1}", key, value);
            }
        }
    }
}