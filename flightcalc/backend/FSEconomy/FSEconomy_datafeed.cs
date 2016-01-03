using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace backend.FSEconomy
{
    class FSEconomy_datafeed
    {
        // we don't want the XML for everyone to see. Dict is the way to go...
        private string rawStringAnswer;
        private XElement rawXMLAnswer;

        private string headNodeName;
        private string elementNodeName;

        // the result that is accessible from the outside
        public List<Dictionary<string, string>> stringAnswerList { get; set; }

        public FSEconomy_datafeed(string datafeedURL, string FSEAccessKey, FSEconomy_enums.FSEconomy_datafeed_type datafeedType)
        {
            // Datafeed urls are saved without userkey in config
            string url = datafeedURL.Replace("%USERKEY%", FSEAccessKey);

            // Getting the raw datafeed
            rawStringAnswer = (new WebClient()).DownloadString(url);

            // some variables must be switched for the type of datafeed we use.
            switch (datafeedType)
            {
                case FSEconomy_enums.FSEconomy_datafeed_type.AIRCRAFT_CONFIG:
                    // topmost node wich is a single unit
                    headNodeName = "AircraftConfigItems";
                    elementNodeName = "AircraftConfig";
                    break;
                default:
                    break;
            }

            stringAnswerList = new List<Dictionary<string, string>>();
            translateXMLAnswerToDictList();
        }

        private void translateXMLAnswerToDictList()
        {
            rawXMLAnswer = XElement.Parse(rawStringAnswer);

            foreach (var aircraft in rawXMLAnswer.Elements())
            {
                Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                foreach (var el in aircraft.Elements()) {
                    tmpDict.Add(el.Name.LocalName.ToString(), el.Value.ToString());
                }
                stringAnswerList.Add(tmpDict);
                
            }
        }
    }
}
