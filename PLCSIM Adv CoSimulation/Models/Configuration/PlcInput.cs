using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class PlcInput : Device
    {
        private bool _value;
        public override bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                WritePlcInput(Tag, _value);
            }
        }

        private void WritePlcInput(string tag, bool val)
        {
            // Console.WriteLine("Write value " + _value + " to Plc tag: " + tag);
            MainInterface.PlcInstance.WriteBool(tag, val);
        }
    }
}
