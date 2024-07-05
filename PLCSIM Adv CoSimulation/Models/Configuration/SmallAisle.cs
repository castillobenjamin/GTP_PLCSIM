using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class SmallAisle : Zone
    {
        #region Properties
        [XmlArray("Contactors")]
        [XmlArrayItem("Contactor")]
        public List<Contactor> Contactors { get; set; }
        #endregion
    }
}