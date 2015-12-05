using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace StreamProtocol
{
    public static class AllowedSites
    {
        public enum SiteStatus { AlwaysDeny = 0, AlwaysAllow = 1, Ask = 2 };

        public static Dictionary<string, SiteStatus> GetAllSites()
        {
            var siteStatuses = new Dictionary<string, SiteStatus>();
            var doc = getDoc();
            foreach (var element in doc.Elements("site"))
                siteStatuses[element.Value] = (SiteStatus)(int)element.Attribute("status");

            return siteStatuses;
        }

        public static bool IsUrlAllowed(Uri url)
        {
            var siteDomain = url.Host.ToLower();
            switch (Status(siteDomain))
            {
                case SiteStatus.AlwaysAllow:
                    return true;
                case SiteStatus.AlwaysDeny:
                    return false;
            }

            var prompt = new AllowedSitePrompt(url);
            return prompt.IsAllowed();
        }

        public static SiteStatus Status(string siteDomain)
        {
            var doc = getDoc();
            var element = doc.Elements("site")
                          .FirstOrDefault(site => site.Value == siteDomain);

            if (element == null)
                return SiteStatus.Ask;

            return (SiteStatus)(int)element.Attribute("status");
        }

        public static void AddSite(string siteDomain, SiteStatus siteStatus)
        {
            DeleteSite(siteDomain);

            var doc = getDoc();
            doc.Add(new XElement("site", siteDomain, new XAttribute("status", (int)siteStatus)));
            saveDoc(doc);
        }

        public static void DeleteSite(string siteDomain)
        {
            Debug.WriteLine($"Removing site {siteDomain}");
            var doc = getDoc();
            doc.Elements("site")
               .Where(site => site.Value == siteDomain)
               .Remove();
            saveDoc(doc);
        }

        private static void saveDoc(XElement doc)
        {
            Debug.WriteLine("Saving site database");
            doc.Save(siteFilePath);
        }

        private static XElement getDoc()
        {
            Debug.WriteLine("Loading site database");
            var filePath = siteFilePath;

            if (File.Exists(filePath))
                return XElement.Load(filePath);
            else
                return new XElement("Root");
        }


        private static string siteFilePath
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(
                                        Environment.SpecialFolder.ApplicationData), "StreamProtocol");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path = Path.Combine(path, "sites.xml");

                Debug.WriteLine($"XML Path is {path}");

                return path;
            }
        }
    }
}
