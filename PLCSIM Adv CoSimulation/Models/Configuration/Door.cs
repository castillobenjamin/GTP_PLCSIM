using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Door
    {
        #region Properties
        // TODO - isDoorClosed is not a PLC input. It is included in the XML for deserializing convenience.
        public bool IsDoorClosed { get; set; }
        public PlcInput IsDoorLocked { get; set; }
        public PlcOutput unlockDoor { get; set; }
        #endregion //Properties
    }
}