using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private bool MaintAreaSerializes;
        private bool FirePreventionShutterSerializes;
        private bool FireAlarmSerializes;
        private bool ShutterCylindersSerializes;
        private bool CondensationSensorSerializes;
        #endregion // Fields

        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlElement("CellCommunication")]
        public CellCommunication CellCommunicationInstance { get; set; }
        
        [XmlElement("Panels")]
        public PanelSection PanelSection { get; set; }
        
        // Maintenance area
        // Some properties are not present depending on config, conditional deserialization
        // Emit a value even when null as long as MaintenanceAreaSpecified == true
        [XmlElement("MaintenanceArea", IsNullable = true)]
        public MaintenanceArea MaintenanceArea { get; set; }
        [XmlIgnore()]
        public bool MaintAreaSpecified { 
            get { return MaintAreaSerializes; } 
            set { MaintAreaSerializes = value; } }
        
        //Aisles
        [XmlArray("Aisles")]
        [XmlArrayItem("Aisle")]
        public List<Aisle> Aisles { get; set; }
        
        //Decks
        [XmlArray("Decks")]
        [XmlArrayItem("Deck")]
        public List<Deck> Decks { get; set; }
        
        //DWS
        //[XmlArray("DynamicWorkStations")]
        //[XmlArrayItem("DynamicWorkStation")]
        //public List<DynamicWorkStation> DynamicWorkStations { get; set; }
        
        //TowerDWS
        [XmlArray("TowerDynamicWorkStations")]
        [XmlArrayItem("TowerDynamicWorkStation")]
        public List<TowerDynamicWorkStation> TowerDynamicWorkStations { get; set; }
        
        //SmallAisle
        [XmlArray("SmallAisles")]
        [XmlArrayItem("SmallAisle")]
        public List<SmallAisle> SmallAisles { get; set; }
        
        //SWS
        [XmlArray("StaticWorkStations")]
        [XmlArrayItem("StaticWorkStation")]
        public List<StaticWorkStation> StaticWorkStations { get; set; }
        
        // Stoppers
        [XmlArray("Stoppers")]
        [XmlArrayItem("Stopper")]
        public List<Stopper> Stoppers { get; set; }
        
        //Bots
        [XmlArray("Bots")]
        [XmlArrayItem("Bot")]
        public List<Bot> Bots { get; set; }
        
        // Fire prevention shutters
        // Only present in Miyano configuration
        // [XmlElement(IsNullable = true)]
        [XmlArray("FirePreventionShutters", IsNullable = true)]
        [XmlArrayItem("FirePreventionShutter", IsNullable = true)]
         public List<FirePreventionShutter> FirePreventionShutters { get; set; }
        [XmlIgnore()]
        public bool FirePreventionShuttersSpecified { 
            get { return FirePreventionShutterSerializes; } 
            set { FirePreventionShutterSerializes = value; } }

        // Shutter cylinders
        // Only in Miyano configuration, conditional deserialization
        [XmlArray("ShutterCylinders", IsNullable = true)]
        [XmlArrayItem("ShutterCylinder", IsNullable = true)]
        public List<PlcInput> ShutterCylinders { get; set; }
        [XmlIgnore()]
        public bool ShutterCylindersSpecified { 
            get { return ShutterCylindersSerializes; } 
            set { ShutterCylindersSerializes = value; } }

        // Fire alarm
        // Only in Miyano configuration, conditional deserialization
        // Emit a value even when null as long as MaintenanceAreaSpecified == true
        [XmlElement(IsNullable = true)]
        public PlcInput FireAlarm { get; set; }
        [XmlIgnore()]
        public bool FireAlarmSpecified { 
            get { return FireAlarmSerializes; } 
            set { FireAlarmSerializes = value; } }

        // Condensation sensor
        [XmlElement(IsNullable = true)]
        public PlcInput CondensationSensor { get; set; }
        [XmlIgnore()]
        public bool CondensationSensorSpecified {
            get { return CondensationSensorSerializes; }
            set { CondensationSensorSerializes = value; } }

        // Buzzer reset button
        [XmlElement("BuzzerReset")]
        public PlcInput BuzzerReset { get; set; }

        // Boolean value to check stopper sensor logic. Difference in Alpen/Miyano
        public bool IsStopperSensorInverted { get; set; }
        #endregion // Properties
    }
}
