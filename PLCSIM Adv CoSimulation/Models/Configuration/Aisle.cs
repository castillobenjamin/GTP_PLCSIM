using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Aisle
    {
        #region fields
        #endregion

        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        public OperationBox OperationBox { get; set; }
        public Door Door { get; set; }
        //Contactors
        [XmlArray("Contactors")]
        [XmlArrayItem("Contactor")]
        public List<Contactor> Contactors { get; set; }
        //Scaffolds
        [XmlArray("Scaffolds")]
        [XmlArrayItem("Scaffold")]
        public List<PlcInput> Scaffolds { get; set; }
        //Zoning
        public Zoning Zoning { get; set; }
        //Emergency stop
        public EmergencyStop EmergencyStopZone { get; set; }
        #endregion // Properties
    }
}