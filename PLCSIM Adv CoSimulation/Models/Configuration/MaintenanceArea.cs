using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class MaintenanceArea
    {
        #region Properties
        public PlcInput BotPresent { get; set; } // BOT sensor
        
        public RegisterFromPlc BotHPtoCell { get; set; } // BOT HP register to CELL
        
        // Input for the third notch of the key switch.
        // Having it here is not ideal, but it is the easiest implementation
        public PlcInput KeySwMaint { get; set; }   

        public PlcInput StopperOpenBtn { get; set; }

        public PlcInput StopperCloseBtn { get; set; }
        
        public Stopper Stopper { get; set; }

        public Contactor Contactor { get; set; }
        #endregion // Properties
    }
}