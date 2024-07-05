using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    /// <summary>
    /// Generic zone.
    /// Contains the properties that are common to all types of zones.
    /// (aisles, decks, DWSs, TowerDWSs, SmallAisles)
    /// </summary>
    public class Zone
    {
        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlAttribute]
        public string Label { get; set; }

        //TODO - this is a measure taken to accomodate the maintenance area. What to do when the zone does not specify a type attribute?
        [XmlAttribute]
        public string Type { get; set; }

        public OperationBox OperationBox { get; set; }

        //Zoning
        public Zoning Zoning { get; set; }
        
        //Emergency stop
        public EmergencyStop EmergencyStopZone { get; set; }
        #endregion
    }
}