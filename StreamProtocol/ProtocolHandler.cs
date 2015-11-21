using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using Microsoft.Win32;

namespace StreamProtocol
{
    class ProtocolApplication
    {
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public string FileArguments { get; private set; }
        public bool Enabled = false;
        public bool CurrentlySelected = false;

        public ProtocolApplication(string executableName) // Fetches information from regedit
        {
            var registry = Registry.ClassesRoot.OpenSubKey($"Applications\\{executableName}", false);
            Debug.WriteLine("Opened key {0}", registry);
            if (registry == null)
                return;

            string name = (string) registry.GetValue("FriendlyAppName");
            string fileCommand = (string) registry.OpenSubKey(@"shell\open\command").GetValue(null);

            var splitter = (fileCommand[0] == '"') ? '"' : ' ';
            var index = (fileCommand[0] == '"') ? 1 : 0;
            var fc = fileCommand.Split(splitter);
            var filePath = fc[index];
            var fileArguments = (fc.Length > index + 1) ? string.Join(splitter.ToString(), fc.Skip(index + 1)) : "\"%1\"";

            initialize(name, filePath, fileArguments);
        }

        public ProtocolApplication(string name, string filePath, string fileArguments = "\"%1\"")
        {
            initialize(name, filePath, fileArguments);
        }

        private void initialize(string name, string filePath, string fileArguments)
        {
            Debug.WriteLine("Initializing ProtocolApplication name:{0} filePath:{1} fileArguments:{2}", name, filePath, fileArguments);
            Name = name;
            FilePath = filePath;
            FileArguments = fileArguments;
            Enabled = File.Exists(filePath);
            Debug.WriteLine("Is {0} enabled: {1} because of path {2}", Name, Enabled, FilePath);
        }
    }

    abstract class ProtocolHandler
    {
        public string Name;
        public string BaseScheme;
        public List<string> ApplicationExecutables;
        public List<ProtocolApplication> Applications;
        private string ExecutablePathKey = "executable";
        private string ExecutableArgumentsKey = "arguments";

        public virtual string RewriteUrl(string Url)
        {
            var newUrl = Url.Split(':');
            if (newUrl[0] == BaseScheme)
                newUrl[0] = "http";
            else
                newUrl[0] = "https";

            return string.Join(":", newUrl);
        }

        public virtual List<string> GetProtocols()
        {
            return new List<string> { $"{BaseScheme}", $"{BaseScheme}s" };
        }

        private RegistryKey getRegistry()
        {
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            return Registry.CurrentUser.CreateSubKey($"Software\\{name}\\{BaseScheme}");
        }

        private string getSelectedExecutable()
        {
            var registry = getRegistry();
            return (string)registry.GetValue(ExecutablePathKey);
        }

        public void RegisterHandler()
        {
            string UrlPrefix = ConfigurationManager.AppSettings["UrlPrefix"];
            var registry = Registry.ClassesRoot.OpenSubKey("", true);
            foreach (var proto in GetProtocols())
            {
                var subRegistry = registry.CreateSubKey($"{UrlPrefix}+{proto}");
                subRegistry
                    .CreateSubKey(@"shell\open\command")
                    .SetValue("", $"\"{System.Reflection.Assembly.GetEntryAssembly().Location}\" \"%1\"");

                subRegistry.SetValue("", "URL:Stream protocol");
                subRegistry.SetValue("URL Protocol", "");
            }
        }

        public void UnregisterHandler()
        {
            string UrlPrefix = ConfigurationManager.AppSettings["UrlPrefix"];
            var registry = Registry.ClassesRoot.OpenSubKey("", true);
            foreach (var proto in GetProtocols())
            {
                var subRegistry = registry.OpenSubKey($"{UrlPrefix}+{proto}", true);
                if (subRegistry != null)
                    subRegistry.DeleteSubKeyTree("");
            }
        }

        public void SetApplication(ProtocolApplication app)
        {
            Debug.WriteLine("Setting application");
            var registry = getRegistry();
            registry.SetValue(ExecutablePathKey, app.FilePath);
            registry.SetValue(ExecutableArgumentsKey, app.FileArguments);
        }

        public void UnsetApplication()
        {
            Debug.WriteLine("Unsetting application");
            var registry = getRegistry();
            registry.DeleteSubKeyTree("");
        }

        public List<ProtocolApplication> GetApplications() // Need to get selected application too, even if it is a selected file
        {
            var apps = new List<ProtocolApplication>();
            var currentExecutable = getSelectedExecutable();

            if (ApplicationExecutables != null)
                ApplicationExecutables.ForEach(ae => apps.Add(new ProtocolApplication(ae)));

            if (Applications != null)
                apps.AddRange(Applications);

            apps = apps.FindAll(app => app.Enabled);
            apps
                .FindAll(app => app.FilePath == currentExecutable)
                .ForEach(app => app.CurrentlySelected = true);
            

            if (!apps.Exists(app => app.CurrentlySelected) && currentExecutable != null && File.Exists(currentExecutable))
            {
                var registry = getRegistry();
                var arguments = (string)registry.GetValue(ExecutableArgumentsKey);
                var app = new ProtocolApplication(currentExecutable, currentExecutable, arguments);
                app.CurrentlySelected = true;
                apps.Add(app);
            }

            return apps;
        }

        public virtual void Execute(ProtocolApplication app, string url)
        {
            url = RewriteUrl(url);
            Process.Start(app.FilePath, app.FileArguments.Replace("%1", url));
        }
    }

    class HTTPProtocolHandler : ProtocolHandler
    {
        public HTTPProtocolHandler()
        {
            Name = "HTTP";
            BaseScheme = "http";
            ApplicationExecutables = new List<string>() { "vlc.exe", "mpc-hc.exe" };
        }
    }

    class TorrentProtocolHandler : ProtocolHandler
    {
        public TorrentProtocolHandler()
        {
            Name = "Torrent";
            BaseScheme = "torrent";

            addAdditionalApplications();
        }

        public virtual void addAdditionalApplications()
        {
            var baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var executablePath = Path.Combine(baseDirectory, "DelugeStream.exe");
            Applications = new List<ProtocolApplication> { new ProtocolApplication("Deluge Streamer", executablePath, "\"%1\" \"%2\" \"%3\"") };
        }

        public override void Execute(ProtocolApplication app, string url)
        {
            url = RewriteUrl(url);

            var newUrl = url.Split('#');

            var urlParts = new List<string> { newUrl[0] };
            
            if (newUrl.Count() > 1)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(newUrl[1]);
                
                var file = query.Get("file");
                if (file != null)
                    urlParts.Add(file);
                else
                    urlParts.Add("");

                var infohash = query.Get("infohash");
                if (infohash != null)
                    urlParts.Add(infohash);
                else
                    urlParts.Add("");
            }
            
            var fileArguments = app.FileArguments;
            for (int i = 1; i <= urlParts.Count(); i++)
                fileArguments = fileArguments.Replace($"\"%{i}\"", $"\"{urlParts[i - 1]}\"");

            Debug.WriteLine("Resulting file:{0} arguments:{1}", app.FilePath, fileArguments);
            Process.Start(app.FilePath, fileArguments);

        }

    }

    class MagnetProtocolHandler : TorrentProtocolHandler
    {
        public MagnetProtocolHandler()
        {
            Name = "Magnet";
            BaseScheme = "magnet";
        }

        public override void addAdditionalApplications() { }

        public override string RewriteUrl(string Url)
        {
            return Url;
        }

        public override List<string> GetProtocols()
        {
            return new List<string> { $"{BaseScheme}" };
        }
    }

    class ProtocolHandlerManager
    {
        public static List<ProtocolHandler> GetProtocolHandlers()
        {
            var ProtocolHandlers = new List<ProtocolHandler>();
            ProtocolHandlers.Add(new HTTPProtocolHandler());
            ProtocolHandlers.Add(new TorrentProtocolHandler());
            ProtocolHandlers.Add(new MagnetProtocolHandler());

            return ProtocolHandlers;
        }
        public static void HandleUrl(string url)
        {
            var scheme = url.Split(':')[0].ToLower();
            foreach (var ph in GetProtocolHandlers())
            {
                if (!ph.GetProtocols().Contains(scheme))
                    continue;

                var app = ph.GetApplications().Find((a) => a.CurrentlySelected);
                if (app != null)
                    ph.Execute(app, url);
            }
        }
    }
}
