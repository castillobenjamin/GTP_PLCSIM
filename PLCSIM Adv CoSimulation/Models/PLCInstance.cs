using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation.Models
{
    /// <summary>
    /// This class encapsulates the PLCSIM Advanced API functions.
    /// </summary>
    public class PLCInstance
    {
        #region Properties and Fields
        /// <summary>
        /// instance of PLCSIM Adv. virtual Controller
        /// </summary>
        public IInstance Instance { get; set; }

        /// <summary>
        /// IP and communication interface information of PLC instance
        /// </summary>
        private SIPSuite4 instanceIP; //= new SIPSuite4("192.168.0.101", "255.255.255.0", "0.0.0.0");
        private readonly bool isTCPIP = false;
        private readonly string IP_addr;
        private readonly string subnetMask;
        private readonly string defaultGateway;

        // current plc instance name
        public string currentPlcName;

        /// <summary>
        /// This enumeration contains all PLC areas that contain the available PLC tags.
        /// </summary>
        public enum EArea
        {
            InvalidArea = 0,
            Input = 1,
            Marker = 2,
            Output = 3,
            Counter = 4,
            Timer = 5,
            DataBlock = 6,
        }

        #endregion // Properties and Fields

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceName"></param>
        /// <param name="isTCPIP">If true, communication is based on TCP/IP</param>
        /// <param name="IP_addr">Ignored if "isTCPIP" is false</param>
        /// <param name="subnetMask">Ignored if "isTCPIP" is false</param>
        /// <param name="defaultGateway">Ignored if "isTCPIP" is false</param>
        public PLCInstance(string instanceName, bool isTCPIP= false, string IP_addr = "", string subnetMask = "", string defaultGateway = "0.0.0.0") 
        {
            Instance = SimulationRuntimeManager.RegisterInstance(instanceName);
            this.isTCPIP = isTCPIP;
            this.IP_addr = IP_addr;
            this.subnetMask = subnetMask;
            this.defaultGateway = defaultGateway;
            SetCommunicationInterface();
            currentPlcName = instanceName;
        }

        public PLCInstance(string plcName)
        {
            currentPlcName = plcName;
            // Instance.RegisterOnConfigurationChangingEvent();
        }

        #endregion // Ctor

        #region Events

        /// <summary>
        /// Event when Configuration changed of the PLC (during download)
        /// </summary>
        /// <param name="in_Sender"> PLC which fired this event</param>
        /// <param name="in_ErrorCode"> ErrorCode of Runtime of the PLC</param>
        /// <param name="in_DateTime"> DateTime when the configuration changed</param>
        private void Instance_OnConfigurationChanged(IInstance in_Sender, ERuntimeErrorCode in_ErrorCode, DateTime in_DateTime, 
            EInstanceConfigChanged in_InstanceConfigChanged, uint in_Param1, uint in_Param2, uint in_Param3, uint in_Param4)
        {
             try
            {
                Instance.UpdateTagList(ETagListDetails.IO);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion // Events

        #region Public Methods

        #region PLC config
        public void SetCommunicationInterface()
        {
            try
            {
                if (isTCPIP)
                {
                    instanceIP = new SIPSuite4(IP_addr, subnetMask, defaultGateway);
                    Instance.CommunicationInterface = ECommunicationInterface.TCPIP;
                }
                else Instance.CommunicationInterface = ECommunicationInterface.Softbus;
                Instance.OnConfigurationChanged += Instance_OnConfigurationChanged;
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void SetVirtualTimeFactor(string scaleFactor)
        {
            try
            {
                Instance.ScaleFactor = Convert.ToDouble(scaleFactor);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateTags()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                // NOTE - Only need access to IO and one DB.
                string in_DataBlockFilterList = "\"013_MCSDataRaw\"";
                Instance.UpdateTagList(ETagListDetails.IODB, false, in_DataBlockFilterList);
                //Instance.UpdateTagList(ETagListDetails.IODB, false);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public string OperatingState()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                return Instance.OperatingState.ToString();
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
                return "Error.";
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
                return "Error.";
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
                return "Error.";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "Error.";
            }
        }
        #endregion // PLC config

        #region PLC controls
        /// <summary>
        /// Power On PLCSIM Adv. Instance, set IPSuite of instance
        /// </summary>
        public void PowerOnPLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.PowerOn(60000);

                //Sets the IP suite of the network interface of a virtual controller.
                //the first argument is the ID of the network interface
                Instance.SetIPSuite((uint)Instance.ID, instanceIP, true);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Power Off PLCSIM Adv. Instance
        /// </summary>
        public void PowerOffPLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.PowerOff(6000);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Run PLCSIM Adv. Instance
        /// </summary>>
        public void RunPLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.Run(6000);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Stop PLCSIM Adv. Instance
        /// </summary>
        public void StopPLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.Stop(6000);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Delete PLCSIM Adv. Instance
        /// </summary>
        public void DeletePLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.UnregisterInstance();
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);

            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Memory Reset PLCSIM Adv. Instance
        /// </summary>
        public void ResetPLC()
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.MemoryReset();
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message);

            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion //PLC controls

        #region Read/Write
        public void WriteBool(string tag, bool value)
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.WriteBool(tag, value);
            }
            catch (SimulationInitializationException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message + " " + tag);
            }
        }
        public bool ReadBool(string tag)
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                return Instance.ReadBool(tag);
            }
            catch (SimulationInitializationException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return false;
            }
            catch (SimulationRuntimeException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return false;
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return false;
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message + " " + tag);
                return false;
            }
        }
        public void WriteByte(string tag, byte value)
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                Instance.WriteUInt8(tag, value);
            }
            catch (SimulationInitializationException plcSimException)
            {
                MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (SimulationRuntimeException plcSimException)
            {
                MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                MessageBox.Show(plcSimException.Message + " " + tag);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + tag);
            }
        }
        public byte ReadByte(string tag)
        {
            try
            {
                Instance = SimulationRuntimeManager.CreateInterface(currentPlcName);
                return Instance.ReadUInt8(tag);
            }
            
            catch (SimulationInitializationException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return 0;
            }
            catch (SimulationRuntimeException plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return 0;
            }
            catch (SimulationRuntimeWarning plcSimException)
            {
                // MessageBox.Show(plcSimException.Message + " " + tag);
                return 0;
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message + " " + tag);
                return 0;
            }
        }

        #endregion // Read/Write

        #endregion // Public Methods
    }
}
