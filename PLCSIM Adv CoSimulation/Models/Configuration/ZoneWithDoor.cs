using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class ZoneWithDoor : Zone
    {
        #region Properties       
        public Door Door { get; set; }
        #endregion // Properties
    }
}
