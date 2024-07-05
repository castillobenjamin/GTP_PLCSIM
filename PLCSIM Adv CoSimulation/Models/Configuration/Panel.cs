using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Panel
    {
        #region Properties
        public PlcInput EmergencyBtn { get; set; }
        public PlcInput ResetBtn { get; set; }
        public PlcOutput ResetLamp { get; set; } // new for Demoline v2
        public PlcOutput EstopBtnLamp { get; set; } // new for Demoline v2
        [XmlArray("EarthFaults")]
        [XmlArrayItem("EarthFault")]
        public List<PlcInput> EarthFaults { get; set; }
        public PlcInput VoltageOn {  get; set; }
        public PlcInput SpikeAlarm { get; set; }    
        // TODO - create a SignalTower class for the led outputs
        public SignalTower SignalTower { get; set; }
        #endregion
    }
}