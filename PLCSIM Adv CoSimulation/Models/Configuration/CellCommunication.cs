using PLCSIM_Adv_CoSimulation.Models.Configuration;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    /// <summary>
    /// Class for simulating communication of the PLC with CELL.
    /// </summary>
    public class CellCommunication
    {
        #region Properties
        public RegisterToPlc IsCellConnectedPulse { get; set; }
        public RegisterToPlc ResetFromCell { get; set; }
        public RegisterToPlc CanSystemStartUp { get; set; }
        public RegisterToPlc SystemIsStartingUp { get; set; }
        public RegisterToPlc BotEvacuationComplete { get; set; }
        public RegisterToPlc RedLight { get; set; }
        public RegisterToPlc YellowLight { get; set; }
        public RegisterToPlc GreenLight { get; set; }
        public RegisterFromPlc IsPlcAutoMode { get; set; }
        public RegisterFromPlc IsPlcWarningMode { get; set; }
        #endregion

    }
}