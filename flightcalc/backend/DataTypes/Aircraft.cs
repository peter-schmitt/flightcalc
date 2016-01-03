using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace backend.DataTypes
{
    /// <summary>
    /// This class holds the definition of a single Airplane
    /// </summary>
    class Aircraft
    {

        public string MakeModel { get; set; }
        public string Crew { get; set; }
        public string Seats { get; set; }
        public string CruiseSpeed { get; set; }
        public string GPH { get; set; }
        public string FuelType { get; set; }
        public string MTOW { get; set; }
        public string EmptyWeight { get; set; }
        public string Price { get; set; }
        public string Ext1 { get; set; }
        public string LTip { get; set; }
        public string LAux { get; set; }
        public string LMain { get; set; }
        public string Center1 { get; set; }
        public string Center2 { get; set; }
        public string Center3 { get; set; }
        public string RMain { get; set; }
        public string RAux { get; set; }
        public string RTip { get; set; }
        public string Ext2 { get; set; }
        public string Engines { get; set; }
        public string EnginePrice { get; set; }

        public Aircraft(Dictionary<string, string> dict)
        {
            MakeModel = dict["MakeModel"];
            Crew = dict["Crew"];
            Seats = dict["Seats"];
            CruiseSpeed = dict["CruiseSpeed"];
            GPH = dict["GPH"];
            FuelType = dict["FuelType"];
            MTOW = dict["MTOW"];
            EmptyWeight = dict["EmptyWeight"];
            Price = dict["Price"];
            Ext1 = dict["Ext1"];
            LTip = dict["LTip"];
            LAux = dict["LAux"];
            LMain = dict["LMain"];
            Center1 = dict["Center1"];
            Center2 = dict["Center2"];
            Center3 = dict["Center3"];
            RMain = dict["RMain"];
            RAux = dict["RAux"];
            RTip = dict["RTip"];
            Ext2 = dict["Ext2"];
            Engines = dict["Engines"];
            EnginePrice = dict["EnginePrice"];
        }
    }
}
