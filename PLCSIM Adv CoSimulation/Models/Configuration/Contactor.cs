using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Contactor
    {
        #region Properties
        [XmlElement("ContactorOutput")]
        public PlcOutput Output { get; set; }
        [XmlElement("ContactorFeedback")]
        public PlcInput Feedback { get; set; }
        public RegisterToPlc ContactorOnOffCommand { get; set; }
        [XmlArray("TrippedInputs")]
        [XmlArrayItem("Tripped")]
        public List<PlcInput> TrippedInputs { get; set; }
        #endregion //Properties
    }
}