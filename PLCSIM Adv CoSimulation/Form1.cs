using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Simatic.Simulation.Runtime;


namespace PLCSIM_Adv_CoSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_createPLC_Click(object sender, EventArgs e)
        {
            SimulationRuntimeManager.RegisterInstance(textBox_PLC_name.Text);
        }
    }
}
