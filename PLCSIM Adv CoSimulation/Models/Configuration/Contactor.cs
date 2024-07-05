using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Contactor
    {
        #region Properties
        public PlcOutput ContactorOutput { get; set; }
        public PlcInput ContactorFeedback { get; set; }
        public RegisterToPlc ContactorOnOffCommand { get; set; }
        [XmlArray("TrippedInputs")]
        [XmlArrayItem("Tripped")]
        public List<PlcInput> TrippedInputs { get; set; }
        #endregion //Properties
    }
}