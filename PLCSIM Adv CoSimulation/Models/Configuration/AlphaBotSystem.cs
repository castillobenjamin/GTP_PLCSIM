using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    [Serializable]
    [XmlRoot("AlphaBotSystem")]
    public class AlphaBotSystem
    {
        #region Fields
        private bool EvacAndMaintAreaSerializes;
        private bool FirePreventionShutterSerializes;
        private bool FireAlarmSerializes;
        private bool ShutterCylindersSerializes;
        #endregion // Fields

        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement("CellCommunication")]
        public CellCommunication CellCommunicationInstance { get; set; }
        [XmlElement("Panels")]
        public PanelSection PanelSection { get; set; }
        // Evacuation and Maintenance area combined
        // Some components are not present depending on config, conditional deserialization
        [XmlElement("EvacuationAndMaintenanceArea", IsNullable = true)] // Emit a value even when null as long as MaintenanceAreaSpecified == true
        public EvacuationAndMaintenanceArea EvacAndMaintArea { get; set; }
        [XmlIgnore()]
        public bool EvacAndMaintAreaSpecified { get { return EvacAndMaintAreaSerializes; } set { EvacAndMaintAreaSerializes = value; } }
        //Aisles
        [XmlArray("Aisles")]
        [XmlArrayItem("Aisle")]
        public List<Aisle> Aisles { get; set; }
        //Decks
        [XmlArray("Decks")]
        [XmlArrayItem("Deck")]
        public List<Deck> Decks { get; set; }
        //DWS
        [XmlArray("DynamicWorkStations")]
        [XmlArrayItem("DynamicWorkStation")]
        public List<DynamicWorkStation> DynamicWorkStations { get; set; }
        //SWS
        [XmlArray("StaticWorkStations")]
        [XmlArrayItem("StaticWorkStation")]
        public List<StaticWorkStation> StaticWorkStations { get; set; }
        // Stoppers
        [XmlArray("Stoppers")]
        [XmlArrayItem("Stopper")]
        public List<Stopper> Stoppers { get; set; }
        // TODO - Aparently no more issues. Need more testing
        // Fire prevention shutters
        // Only present in Miyano configuration
        // [XmlElement(IsNullable = true)]
        [XmlArray("FirePreventionShutters", IsNullable = true)]
        [XmlArrayItem("FirePreventionShutter", IsNullable = true)]
         public List<FirePreventionShutter> FirePreventionShutters { get; set; }
        [XmlIgnore()]
        public bool FirePreventionShuttersSpecified { get { return FirePreventionShutterSerializes; } set { FirePreventionShutterSerializes = value; } }
        // Shutter cylinders
        // Only in Miyano configuration, conditional deserialization
        [XmlArray("ShutterCylinders", IsNullable = true)]
        [XmlArrayItem("ShutterCylinder", IsNullable = true)]
        public List<PlcInput> ShutterCylinders { get; set; }
        [XmlIgnore()]
        public bool ShutterCylindersSpecified { get { return ShutterCylindersSerializes; } set { ShutterCylindersSerializes = value; } }
        // Fire alarm
        // Only in Miyano configuration, conditional deserialization
        [XmlElement(IsNullable = true)] // Emit a value even when null as long as MaintenanceAreaSpecified == true
        public FireAlarm FireAlarm { get; set; }
        [XmlIgnore()]
        public bool FireAlarmSpecified { get { return FireAlarmSerializes; } set { FireAlarmSerializes = value; } }
        // Boolean value to check stopper sensor logic. Difference in Alpen/Miyano
        public bool IsStopperSensorInverted { get; set; }
        #endregion // Properties
    }
}
