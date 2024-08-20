using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Bot
    {
        #region Properties
        [XmlAttribute]
        public string Label { get; set; }
        public RegisterFromPlc IsCommFaultToCell {  get; set; }
        public RegisterFromPlc EstopStatusToCell { get; set; }
        public RegisterToPlc EstopCmdFromCell { get; set; }
        public RegisterToPlc ResetCommandFromCell { get; set; }
        #endregion
    }
}