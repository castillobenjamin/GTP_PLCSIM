using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    /// <summary>
    /// This key switch is used for the maintenance area.
    /// Choose between 
    /// 1. Aisle (to perform zoning) or
    /// 2. Maint (To get inside maintenance area).
    /// </summary>
    public class KeySwitchMaint
    {
        #region Properties
        [XmlElement("AisleMode")]
        public PlcInput Aisle { get; set; }

        [XmlElement("MaintMode")]
        public PlcInput Maint { get; set; }
        #endregion // Properties
    }
}
