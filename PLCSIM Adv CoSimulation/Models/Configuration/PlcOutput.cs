using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class PlcOutput : Device
    {
        private bool _value;
        public override bool Value
        {
            get
            {
                _value = ReadPlcOutput(Tag);
                return _value;
            }
            // The set is declared for XML serialization compatibility. The PLC output will overwrite any value set in this way.
            set
            {
                _value = value;
            }
        }

        private bool ReadPlcOutput(string tag)
        {
            // Console.WriteLine("Read PLC output tag: " + tag);
            // return false;
            return MainInterface.PlcInstance.ReadBool(tag);
        }
    }
}
