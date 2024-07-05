using System.Runtime.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class OperationBox
    {
        #region Properties
        public PlcInput EmergencyBtn { get; set; }
        public PlcInput ResetBtn { get; set; }
        public PlcInput RunBtn { get; set; }
        public KeySwitch KeySwitch { get; set; }
        public PlcOutput ZoningStatusLed { get; set; }
        #endregion //Properties
    }
}