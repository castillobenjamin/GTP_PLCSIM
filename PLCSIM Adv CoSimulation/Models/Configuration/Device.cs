using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public abstract class Device
    {
        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Address { get; set; } // Exact same format as Tia Portal 
        public abstract bool Value { get; set; }
        #endregion //Properties
    }
}