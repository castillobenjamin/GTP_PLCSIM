using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Door
    {
        #region Fields
        private bool IsDoorReadyInputSerializes;
        #endregion // Fields

        #region Properties
        public PlcInput IsDoorLockedKeySwitch { get; set; }
        public PlcInput IsDoorClosedSensor { get; set; }
        // Ready input
        // Only in Miyano configuration, conditional deserialization
        public PlcInput IsDoorReadyInput { get; set; }
        [XmlIgnore()]
        public bool IsDoorReadyInputSpecified { get { return IsDoorReadyInputSerializes; } set { IsDoorReadyInputSerializes = value; } }
        #endregion //Properties
    }
}