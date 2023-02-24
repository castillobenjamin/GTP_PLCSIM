using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace PLCSIM_Adv_CoSimulation.Models
{
    public class ModbusCommunication
    {
        #region Fields
        public ModbusClient modbusClient;
        #endregion // Fields

        #region Ctor
        public ModbusCommunication()
        {

        }
        #endregion // Ctor

        #region Public Methods

        #region Connection
        /// <summary>
        /// Connect to Modbus slave using specified parameters.
        /// </summary>
        /// <param name="IPaddress">IP address of Modbus Server</param>
        /// <param name="port">Port used for connection</param>
        /// <returns>True if connection was successful.</returns>
        public void Connect(string IPaddress, string port)
        {
            try
            {
                modbusClient = new ModbusClient(IPaddress, int.Parse(port)); //Ip-Address and Port of Modbus-TCP-Server
                modbusClient.Connect(); //Connect to Server
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " IP: " + IPaddress + " port: " + port);
            }
        }

        public bool IsConnected()
        {
            if (modbusClient != null)
            {
                return modbusClient.Connected;
            }
            else
            {
                return false;
            }
        }

        public void Disconnect() 
        {
            try
            {
                modbusClient.Disconnect();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion // Connection

        public void WriteSingleRegister(int address, UInt16 value)
        {
            try
            {
                modbusClient.WriteSingleRegister(address, value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Write to register: " + address);
            }
        }

        public UInt16 ReadSingleRegister(int address)
        {
            try
            {
                // Make sure to read only one Register at a time
                int qty = 1;
                int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(address, qty);
                // Return first (and only) element of int structure.
                return (ushort)readHoldingRegisters[0]; // Cast ushort
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Read register: " + address);
                return 0;
            }
        }
        #endregion // Public Methods
    }
}
