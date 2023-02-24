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
        // NOTE - Changed to "input" because the signal is actually a boolean value
        public RegisterToPlc SystemIsStartingUp { get; set; }
        public RegisterToPlc CanSystemStartUp { get; set; }
        public RegisterFromPlc IsPlcAutoMode { get; set; }
        public RegisterFromPlc IsPlcWarningMode { get; set; }
        public RegisterFromPlc PlcHasError { get; set; }

        // TODO - need to add 火報用・BOT退避完了 signal

        #endregion

    }
}