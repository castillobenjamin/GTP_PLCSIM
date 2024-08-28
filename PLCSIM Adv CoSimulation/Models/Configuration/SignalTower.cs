using System;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class SignalTower
    {
        #region Properties
        public PlcOutput Buzzer {  get; set; }
        public PlcOutput RedLed { get; set; }
        public PlcOutput YellowLed { get; set; }
        public PlcOutput GreenLed { get; set; }
        public PlcOutput WhiteLed { get; set; }
        #endregion
    }
}
