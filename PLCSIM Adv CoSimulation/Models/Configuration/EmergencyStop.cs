using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class EmergencyStop
    {
        #region Properties
        public RegisterToPlc CellIsCompleteFlag { get; set; }
        public RegisterFromPlc PlcStopRequest { get; set; }
        public RegisterFromPlc PlcIsStopStatus { get; set; }
        #endregion //Properties
    }
}