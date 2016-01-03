using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.DataTypes;
using backend.FSEconomy;
using backend.context;

namespace backend.Fuel_calculations
{
    public class Fuel_calculations
    {
        public Dictionary<string, Aircraft> aircraftDict = new Dictionary<string, Aircraft>();
        Config config = Config.Instance();

        public Fuel_calculations()
        {

        }

        public void populateAircraftData()
        {
            FSEconomy_datafeed feed = new FSEconomy_datafeed(config.configuration["FSEconomy_Aircraft_configs_datafeed_URL"], config.configuration["FSEconomy_Access_Key"], FSEconomy_enums.FSEconomy_datafeed_type.AIRCRAFT_CONFIG);
            foreach (Dictionary<string, string> aircraft in feed.stringAnswerList)
            {
                aircraftDict.Add(aircraft["MakeModel"], new Aircraft(aircraft));
            }
        }
    }
}
