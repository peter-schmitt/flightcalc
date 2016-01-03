using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace flightcalc.context
{
    /// <summary>
    /// This class handles reading and writing the config file
    /// </summary>
    class ConfigFileHandling
    {
        private const string configpath = "flightcalc.cfg";
        private XElement configurationFromFile;

        private void loadOrCreateConfigFile()
        {
            // Load config if there is one or create one
            if (System.IO.File.Exists(configpath))
            {
#if DEBUG 
                Console.WriteLine("found config");
#endif

                configurationFromFile = XElement.Load(configpath);

            }
            else
            {
#if DEBUG
                Console.WriteLine("created config");
#endif

                configurationFromFile = new XElement("config");
                configurationFromFile.Save(configpath);
            }
        }

        public void saveConfigFile()
        {
            configurationFromFile.Save(configpath);
        }
       
        public ConfigFileHandling()
        {
            loadOrCreateConfigFile();
        }

        ~ConfigFileHandling()
        {
            saveConfigFile();
        }

        /// <summary>
        /// Publicises the content of the config file in dictionary form.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> getConfigFileContent()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var el in configurationFromFile.Elements("CItem"))
            {
                dict.Add(el.Attribute("Name").Value.ToString(), el.Attribute("Value").Value.ToString());
            }

            return dict;
        }

        /// <summary>
        /// Set config file contents in key-value form
        /// </summary>
        /// <param name="configDict"></param>
        public void setConfigFileContent(Dictionary<string, string> configDict)
        {
            // create root element
            XElement el = new XElement("config");

            // add children nodes with config payload generated from configDict
            foreach (string key in configDict.Keys)
            {
                el.Add(new XElement("CItem", new XAttribute("Name", key), new XAttribute("Value", configDict[key])));
            }

            configurationFromFile = el;
        }
    }
}
