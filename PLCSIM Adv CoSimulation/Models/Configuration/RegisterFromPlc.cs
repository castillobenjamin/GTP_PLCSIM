using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class RegisterFromPlc : ModbusRegister
    {
        private ushort _value;
        public override ushort Value
        {
            get
            {
                _value = ReadPlcRegister(Address);
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private ushort ReadPlcRegister(int address)
        {
            // return 0;
            return MainInterface.CellClient.ReadSingleRegister(address);
        }
    }
}
