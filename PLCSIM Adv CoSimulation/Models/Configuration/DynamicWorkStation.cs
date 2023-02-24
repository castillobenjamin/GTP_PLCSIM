using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class DynamicWorkStation
    {
        #region Fields
        private bool coversSerializes;
        #endregion // Fields

        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        //Estop button
        public PlcInput EmergencyBtn { get; set; }
        //Contactor
        public Contactor Contactor { get; set; }
        // DWS Covers
        [XmlArray("Covers", IsNullable = true)]
        [XmlArrayItem("Cover", IsNullable = true)]
        public List<PlcInput> Covers { get; set; }
        [XmlIgnore()]
        public bool CoversSpecified { get { return coversSerializes; } set { coversSerializes = value; } }
        //Zoning
        public Zoning Zoning { get; set; }
        //Emergency stop
        public EmergencyStop EmergencyStopZone { get; set; }
        #endregion
    }
}