using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PLCSIM_Adv_CoSimulation.Models
{
    public interface PlcInstanceInterface
    {
        #region Public Methods

        #region PLC config
        void UpdateInterface(string plcName);
        void UpdateTags();
        string OperatingState();
        #endregion // PLC config

        #region PLC controls
        void PowerOnPLC();
        void PowerOffPLC();
        void RunPLC();
        void StopPLC();
        void DeletePLC();
        void ResetPLC();
        #endregion //PLC controls

        #region Read/Write
        void WriteBool(string tag, bool value);
        bool ReadBool(string tag);
        void WriteByte(string tag, byte value);
        byte ReadByte(string tag);
        #endregion // Read/Write

        #endregion // Public Methods
    }
}
