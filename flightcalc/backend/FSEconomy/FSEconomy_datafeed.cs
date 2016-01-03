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

        // the result that is accessible from the outside
        private Dictionary<string, string> XMLAnswerDict { get; set; }

        public FSEconomy_datafeed(string datafeed_url, string FSE_Access_Key, FSEconomy_enums.FSEconomy_datafeed_type datafeed_type)
        {
            // Datafeed urls are saved without userkey in config
            string url = datafeed_url.Replace("%USERKEY%", FSE_Access_Key);

            // Getting the raw datafeed
            rawStringAnswer = (new WebClient()).DownloadString(url);
        }

        private void translateXMLAnswerToDict()
        {
            rawXMLAnswer = XElement.Load(rawStringAnswer);


        }
    }
}
