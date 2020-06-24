using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GTA.Client.SellingDrugs.Models;
using Newtonsoft.Json;

namespace GTA.Client.SellingDrugs.Services
{
    public static class ConfigService
    {
        private static readonly Dictionary<string, object> _configStore = new Dictionary<string, object>();
       
        public static Config LoadConfig(string location, string key)
        {
            if (_configStore.ContainsKey(key))
            {
                return (Config) _configStore[key];
            }
            else
            {
                XDocument xdoc = XDocument.Load(location);
                var config = new Config()
                {
                    TimeToSell = int.Parse(xdoc?.Element("Settings")?.Element("TimeToSell")?.Value ?? "5")
                };
                return config;
            }
        }
    }
}
