using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    /// <summary>
    ///How to write to register (preudocode for preprocessing):
    ///     This_object = Bitwise_AND ( this.BitPlacement,  Bool(this.Value) )
    ///     Bitwise_OR ( This_object, All_other_objects_with_same_address ) 
    ///     Write to Register once.
    ///         Write only to objects with BitPlacement == 0 ?
    /// </summary>
    public abstract class ModbusRegister
    {
        #region Properties
        /// <summary>
        /// Tag is currently unused for ModBus registers.
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Address of Modbus Holding Register.
        /// Size: 16 bits
        /// Address space: 40001 – 49999
        /// Starting address "0" is equivalent to "40001"
        /// </summary>
        public int Address { get; set; }
        /// <summary>
        /// Location of bit in Word. 0 = LSB. 15 = MSB.
        /// Used to keep track of bit associated with a single signal.
        /// </summary>
        public ushort BitPosition { get; set; }
        /// <summary>
        /// Value to be written to register.
        /// </summary>
        public abstract ushort Value { get; set; }
        #endregion // Properties
    }
}
