namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Contactor
    {
        #region Properties
        public PlcOutput ContactorOutput { get; set; }
        public PlcInput ContactorFeedback { get; set; }
        public PlcInput ContactorElbTrip1 { get; set; }
        public PlcInput ContactorElbTrip2 { get; set; }
        public RegisterToPlc ContactorOnOffCommand { get; set; }
        #endregion //Properties
    }
}