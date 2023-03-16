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
    public class EvacuationAndMaintenanceArea
    {
        #region fields
        private bool ScaffoldSerializes;
        private bool EstopSerializes;
        #endregion // fields

        #region Properties
        public OperationBox OperationBox { get; set; }
        public PlcInput BotHP { get; set; } // BOT sensor
        public RegisterFromPlc BotHPtoCell { get; set; } // BOT HP register to CELL
        public Door Door { get; set; }
        public Contactor Contactor { get; set; }
        // Only in Alpen? configuration, conditional deserialization
        [XmlElement(IsNullable = true)] // Emit a value even when null as long as MaintenanceAreaSpecified == true
        public PlcInput Scaffold { get; set; }
        [XmlIgnore()]
        public bool ScaffoldSpecified { get { return ScaffoldSerializes; } set { ScaffoldSerializes = value; } }
        //Emergency stop
        [XmlElement(IsNullable = true)]
        public EmergencyStop EmergencyStopZone { get; set; }
        [XmlIgnore()]
        public bool EmergencyStopZoneSpecified { get { return EstopSerializes; } set { EstopSerializes = value;  } }
        #endregion // Properties
    }
}