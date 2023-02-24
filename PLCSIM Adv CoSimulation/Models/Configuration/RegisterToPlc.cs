using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class RegisterToPlc : ModbusRegister
    {
        private ushort _value;
        public override ushort Value 
        {
            get 
            {
                // Make sure to always get an updated value of the register.
                _value = ReadPlcRegister(Address);
                return _value;
            }
            set 
            {
                _value = value;
                WritePlcRegister(Address, _value);
            } 
        }

        private void WritePlcRegister(int address, ushort val)
        {
            // Console.WriteLine("Write value " + val + " to Register: " + address); 
            MainInterface.CellClient.WriteSingleRegister(address, val);
        }
        private ushort ReadPlcRegister(int address)
        {
            // return 0;
            return MainInterface.CellClient.ReadSingleRegister(address);
        }
    }
}
