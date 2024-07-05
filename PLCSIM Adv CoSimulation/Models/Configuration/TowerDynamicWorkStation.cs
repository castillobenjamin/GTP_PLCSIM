using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class TowerDynamicWorkStation : ZoneWithDoor
    {
        #region Properties
        [XmlArray("Contactors")]
        [XmlArrayItem("Contactor")]
        public List<Contactor> Contactors { get; set; }

        public PlcOutput ContactorLamp { get; set; }

        [XmlArray("SafetyBoards")]
        [XmlArrayItem("SafetyBoard")]
        public List<PlcInput> SafetyBoards { get; set; }
        #endregion

    }
}