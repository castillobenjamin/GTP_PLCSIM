using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class StaticWorkStation
    {
        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        public PlcInput EmergencyBtn { get; set; }
        #endregion //Properties
    }
}