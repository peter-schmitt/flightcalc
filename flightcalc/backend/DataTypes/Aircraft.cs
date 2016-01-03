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

        private string MakeModel { get; set; }
        private string Crew { get; set; }
        private string Seats { get; set; }
        private string CruiseSpeed { get; set; }
        private string GPH { get; set; }
        private string FuelType { get; set; }
        private string MTOW { get; set; }
        private string EmptyWeight { get; set; }
        private string Price { get; set; }
        private string Ext1 { get; set; }
        private string LTip { get; set; }
        private string LAux { get; set; }
        private string LMain { get; set; }
        private string Center1 { get; set; }
        private string Center2 { get; set; }
        private string Center3 { get; set; }
        private string RMain { get; set; }
        private string RAux { get; set; }
        private string RTip { get; set; }
        private string Ext2 { get; set; }
        private string Engines { get; set; }
        private string EnginePrice { get; set; }
    }
}
