using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class MaintenanceArea
    {
        #region Properties
        public PlcInput BotPresent { get; set; } // BOT sensor
        
        public RegisterFromPlc BotHPtoCell { get; set; } // BOT HP register to CELL

        public RegisterToPlc DisableStopper { get; set; } //Disable maint. stopper signal from CELL

        // Maintenance area key switch
        public KeySwitchMaint KeySwitch { get; set; }
        
        // Maintenance status lamp
        [XmlElement("StatusLamp")]
        public PlcOutput Lamp { get; set; }

        public Stopper Stopper { get; set; }

        public Contactor Contactor { get; set; }
        #endregion // Properties
    }
}