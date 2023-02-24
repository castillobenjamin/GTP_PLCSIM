using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class FirePreventionShutter
    {
        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        public PlcOutput PlcOpenOut { get; set; }
        public PlcOutput PlcCloseOut { get; set; }
        public PlcInput IsOpenSensor { get; set; }
        public PlcInput IsClosedSensor { get; set; }
        //[XmlElement("IsOpenStatusToCell")]
        public RegisterFromPlc IsRailOpenToCell { get; set; }
        //[XmlElement("IsClosedStatusToCell")]
        public RegisterFromPlc IsShutterOpenToCell { get; set; }
        #endregion //Properties
    }
}
