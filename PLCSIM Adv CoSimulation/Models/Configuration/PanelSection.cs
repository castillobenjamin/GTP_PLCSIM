using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class PanelSection
    {
        #region Properties
        public Panel DwsPanel { get; set; }
        public Panel SouthPanel { get; set; }
        public Panel NorthPanel { get; set; }
        #endregion
    }
}
