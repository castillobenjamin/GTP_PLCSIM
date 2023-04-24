using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Models
{
    /// <summary>
    /// This is a dummy class to simulate the plc instance during a CELL only simulation.
    /// </summary>
    internal class DummyPlcInstance : PlcInstanceInterface
    {
        #region Fields
        private string currentPlcName;
        #endregion // Fields
        #region Ctor
        public DummyPlcInstance(string plcName)
        {
            currentPlcName = plcName;
        }
        #endregion // Ctor

        #region Public Methods

        #region PLC config
        public void UpdateInterface(string plcName)
        {
            currentPlcName = plcName;
        }
        public void UpdateTags()
        {
        }
        public string GetOperatingState()
        {
            return "Dummy string";
        }
        #endregion // PLC config

        #region PLC controls
        public void PowerOnPLC()
        {
        }
        public void PowerOffPLC()
        {
        }
        public void RunPLC()
        {
        }
        public void StopPLC()
        {
        }
        public void DeletePLC()
        {
        }
        public void ResetPLC()
        {
        }
        #endregion //PLC controls

        #region Read/Write
        public void WriteBool(string tag, bool value)
        {
        }
        public bool ReadBool(string tag)
        {
            return false;
        }
        public void WriteByte(string tag, byte value)
        {
        }
        public byte ReadByte(string tag)
        {
            return 0;
        }
        #endregion // Read/Write

        #endregion // Public Methods
    }
}
