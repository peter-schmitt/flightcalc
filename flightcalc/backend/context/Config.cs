using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace backend.context
{
    /// <summary>
    /// This class handles configuration options
    /// 
    /// It is a singleton!
    /// </summary>
    public class Config
    {
        private ConfigFileHandling cfg_handling;
        public Dictionary<string, string> configuration { get; set; }
        private static Config instance;

        /// <summary>
        /// This function builds the config structure with defaults.
        /// Add new Config features here!
        /// </summary>
        private void createConfigStructure()
        {
            configuration["FSEconomy_Access_Key"] = configuration.ContainsKey("FSEconomy_Access_Key") ? configuration["FSEconomy_Access_Key"] : "";
            configuration["FSEconomy_Aircraft_configs_datafeed_URL"] = configuration.ContainsKey("FSEconomy_Aircraft_configs_datafeed_URL") ? configuration["FSEconomy_Aircraft_configs_datafeed_URL"] : "";
        }

        /// <summary>
        /// Get config from file and load configuration dictionary.
        /// </summary>
        private Config()
        {
            cfg_handling = new ConfigFileHandling();
            configuration = cfg_handling.getConfigFileContent();
            createConfigStructure();
        }

        public static Config Instance()
        {
            if (instance == null)
            {
                instance = new Config();
                return instance;
            }
            else
            {
                return instance;
            }

        }

        ~Config()
        {
            cfg_handling.setConfigFileContent(configuration);
            cfg_handling.saveConfigFile();
        }
    }
}
