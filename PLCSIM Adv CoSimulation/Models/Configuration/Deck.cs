using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Deck
    {
        #region Fields
        private bool ScaffoldSerializes;
        #endregion // Fields

        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        public OperationBox OperationBox { get; set; }
        public Door Door { get; set; }

        // Scaffold
        // Not present in Miyano configuration, conditional deserialization
        // NOTE - No scaffold in any configuration, consider removing
        [XmlElement(IsNullable = true)] // Emit a value even when null as long as ScaffoldSpecified == true
        public PlcInput Scaffold { get; set; }

        [XmlIgnore()] 
        public bool ScaffoldSpecified { get { return ScaffoldSerializes; } set { ScaffoldSerializes = value; } }

        //Zoning
        public Zoning Zoning { get; set; }
        //Emergency stop
        public EmergencyStop EmergencyStopZone { get; set; }
        #endregion // Properties

        #region Ctor
            public Deck() { }
        #endregion // Ctor
    }
}