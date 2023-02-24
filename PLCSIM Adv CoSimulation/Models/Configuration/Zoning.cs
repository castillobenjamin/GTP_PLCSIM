namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Zoning
    {
        #region Properties
        public RegisterToPlc CellCommand { get; set; }
        public RegisterFromPlc ZoningStatus { get; set; }
        #endregion //Properties
    }
}