using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Stopper
    {
        #region Properties
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        public PlcOutput PlcOpenOut { get; set; }
		public PlcOutput PlcCloseOut { get; set; }
        public PlcOutput PlcResetAlarmOut { get; set; }

        public PlcInput IsOpenSensor { get; set; }
		public PlcInput IsClosedSensor { get; set; }
        public PlcInput Alarm { get; set; }
        public RegisterToPlc OpenCommandFromCell { get; set; }
        public RegisterToPlc CloseCommandFromCell { get; set; }
        public RegisterFromPlc IsOpenStatusToCell { get; set; }
        public RegisterFromPlc IsClosedStatusToCell { get; set; }
        public RegisterFromPlc ErrorSignalToCell { get; set; }
		public RegisterFromPlc TimeOverSignalToCell { get; set; }
        #endregion //Properties
    }
}