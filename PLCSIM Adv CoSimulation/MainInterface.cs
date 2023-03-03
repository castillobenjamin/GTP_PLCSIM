using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLCSIM_Adv_CoSimulation.Models;
using Siemens.Simatic.Simulation.Runtime;
using EasyModbus;


namespace PLCSIM_Adv_CoSimulation
{
    //TODO - Delete all V1 method references after validating V2 test with PLCSIM working license
    public partial class MainInterface : Form
    {
        #region Fields
        // Public fields
        /// <summary>
        /// PLCSIM Adv. instance of the virtual controller
        /// This field is declared public static so that instances of:
        /// - PlcInput, 
        /// - PlcOutput, 
        /// - SignalFromPlc, 
        /// - SignalToPlc 
        /// can update their values directly to the Plc instance
        /// </summary>
        public static PLCInstance PlcInstance;
        // Private fields
        // Instace of the simulation interface
        private CoSimInterface simInterface;
        //Cosimulation instance
        private CoSimulation CoSimulationInstance;
        //Modbus connection
        public static ModbusCommunication CellClient;
        // V1. Old PLCSIM Adv. API interface. Still used.
        private PLCSimMainFunctions plcSimMainFunction = new PLCSimMainFunctions();
        // Boolean value for PLC communication interface
        private bool isTCP = false;
        // Check if an instance was created
        private bool instanceWasCreated = false;
        #endregion // Fields

        #region Ctor
        public MainInterface()
        {
            InitializeComponent();
            //Set default values for address area IO related combobox
            comboBox_addressArea.Items.Add("Input");
            comboBox_addressArea.Items.Add("Marker");
            comboBox_addressArea.Items.Add("Output");
            comboBox_addressArea.SelectedIndex= 0;
            //Set default values for address type IO related combobox
            comboBox_addressType.Items.Add("Bit");
            comboBox_addressType.Items.Add("Byte");
            comboBox_addressType.SelectedIndex = 0;
            //Add already created PLC instances
            UpdatePlcComboBox();
            // Modbus client
            CellClient = new ModbusCommunication();
            //Fill in Modbus parameters
            // This is the IP and port used for Miyano
            TextBox_ModbusServerIP.Text = "192.168.59.201";
            TextBox_ModbusPort.Text = "3002";
        }
        #endregion //Ctor

        #region Interface events
        private void UpdateLabels()
        {
            //Turning the PLC takes time, for now check if the object is null
            // TODO - add logic to wait for the PLC to turn on
            label_OpState.Text = plcSimMainFunction.getPlcOperatingState(comboBox_PLC_list.SelectedItem.ToString());
            label_connectionType.Text = plcSimMainFunction.getConnectionType(comboBox_PLC_list.SelectedItem.ToString());
        }
        public void UpdatePlcComboBox()
        {
            //Check for current registered PLC info and display it on combo box
            SInstanceInfo[] createdPlcInfo = SimulationRuntimeManager.RegisteredInstanceInfo;
            if (createdPlcInfo.Length != 0)
            {
                comboBox_PLC_list.Items.Clear();
                for (int i = 0; i < createdPlcInfo.Length; i++)
                {
                    comboBox_PLC_list.Items.Add(createdPlcInfo[i].Name);
                }
            }
        }
        private void ComboBox_PLC_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
            UpdateInstance();

        }
        #endregion // Interface events

        #region PLC controls
        private void Btn_createPLC_Click(object sender, EventArgs e)
        {
            //Create PLC and return a status message - V2
            CreatePLC();
            comboBox_PLC_list.SelectedIndex = comboBox_PLC_list.FindStringExact(textBox_PLC_name.Text);
            instanceWasCreated = true;
        }
        private void Btn_DeletePLC_Click(object sender, EventArgs e)
        {
            //Delete PLC and return a status message - V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.DeletePLC();
            listBox_notifications.Items.Add("PLC instance has been deleted.");
            UpdatePlcComboBox();

        }
        private void Btn_PwrON_Click(object sender, EventArgs e)
        {
            //V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.PowerOnPLC();
            listBox_notifications.Items.Add("PLC instance has been turned ON.");
            UpdateLabels();
        }
        private void Btn_PwrOFF_Click(object sender, EventArgs e)
        {
            //V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.PowerOffPLC();
            listBox_notifications.Items.Add("PLC instance has been turned off.");
            UpdateLabels();
        }
        private void Btn_Reboot_Click(object sender, EventArgs e)
        {
            //V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.ResetPLC();
            listBox_notifications.Items.Add("PLC memory has been reset.");
            UpdateLabels();
        }
        private void Btn_Run_Click(object sender, EventArgs e)
        {
            //V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.RunPLC();
            listBox_notifications.Items.Add("PLC is in RUN mode.");
            UpdateLabels();
        }
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            //V2
            PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
            PlcInstance.StopPLC();
            listBox_notifications.Items.Add("PLC is in STOP mode.");
            UpdateLabels();
        }
        #region helper methods
        private void CreatePLC()
        {
            //If TCP/IP related fields are filled in, assumes Ethernet connection is wanted and sets flag.
            if (textBox_PLC_IPaddress.Text.Length != 0 &&
                textBox_SubnetMask.Text.Length != 0 &&
                textBox_Gateway.Text.Length != 0)
            {
                isTCP = true;
            }
            //Create PLC instance
            PlcInstance = new PLCInstance(textBox_PLC_name.Text,
                isTCP,
                textBox_PLC_IPaddress.Text,
                textBox_SubnetMask.Text,
                textBox_Gateway.Text);
            //Update notificatino box
            listBox_notifications.Items.Add("Instance has been created. " +
                (isTCP ? "Connection over TCP" : "Connection over Softbus"));
            //Update list of available PLC instances
            UpdatePlcComboBox();
        }
        private void UpdateInstance()
        {
            if (!instanceWasCreated)
            {
                PlcInstance = new PLCInstance(comboBox_PLC_list.SelectedItem.ToString());
            }
        }
        #endregion // helper methods

        #endregion // PLC controls

        #region PLC Communication
        //TODO - Consider updating plc communication methods to be changeable after instance is created on V2 as well.
        private void Btn_Local_Click(object sender, EventArgs e)
        {
            listBox_notifications.Items.Add(plcSimMainFunction.changeCommToLocal(comboBox_PLC_list.SelectedItem.ToString()));
            UpdateLabels();
        }

        private void Btn_TCPIP_Click(object sender, EventArgs e)
        {
            listBox_notifications.Items.Add(plcSimMainFunction.changeCommToTCPIP(comboBox_PLC_list.SelectedItem.ToString()));
            UpdateLabels();
        }
        #endregion // PLC Communication

        #region PLC virtual time
        private void Btn_save_Click(object sender, EventArgs e)
        {
            //V1
            //listBox_notifications.Items.Add(plcSimMainFunction.setVirtualTimeFactor(comboBox_PLC_list.SelectedItem.ToString(), textBox_timeScale.Text));
            //V2
            //TODO - decide where to do the convertion from String to Double of timescale value
            PlcInstance.SetVirtualTimeFactor(textBox_timeScale.Text);
            listBox_notifications.Items.Add("Virtual time has been modified.");
        }

        private void TrackBar_timeScale_Scroll(object sender, EventArgs e)
        {
            float virtualTimeScalingFactor;
            if (trackBar_timeScale.Value <= 100) 
            {
                virtualTimeScalingFactor = trackBar_timeScale.Value / 100f;
            } else
            {
                virtualTimeScalingFactor = trackBar_timeScale.Value - 99;
            }
            textBox_timeScale.Text = virtualTimeScalingFactor.ToString();
        }
        #endregion //PLC virtual time

        #region Read/Write tag
        private void Btn_readTag_Click(object sender, EventArgs e)
        {
            listBox_notifications.Items.Add(plcSimMainFunction.readPLCTags(comboBox_PLC_list.SelectedItem.ToString()));

            //Display tag list in combo box
            int tagListLength = PLCSimMainFunctions.currentTagList.Length;

            comboBox_tagList.Items.Clear();
            for (int i=0; i < tagListLength; i++)
            {
                comboBox_tagList.Items.Add(PLCSimMainFunctions.currentTagList.GetValue(i).ToString());
            }
        }

        #region Set the tag area variable
        private void CheckBox_IO_CheckedChanged(object sender, EventArgs e)
        {
            PLCSimMainFunctions.isIO = checkBox_IO.Checked;
            checkBox_M.Checked = false;
            checkBox_CTs.Checked = false;
            checkBox_DBs.Checked = false;
        }

        private void CheckBox_M_CheckedChanged(object sender, EventArgs e)
        {
            PLCSimMainFunctions.isBitMem = checkBox_M.Checked;
            checkBox_IO.Checked = false;
            checkBox_CTs.Checked = false;
            checkBox_DBs.Checked = false;
        }

        private void CheckBox_CTs_CheckedChanged(object sender, EventArgs e)
        {
            PLCSimMainFunctions.isCTs = checkBox_CTs.Checked;
            checkBox_M.Checked = false;
            checkBox_IO.Checked = false;
            checkBox_DBs.Checked = false;
        }

        private void CheckBox_DBs_CheckedChanged(object sender, EventArgs e)
        {
            PLCSimMainFunctions.isDBs = checkBox_DBs.Checked;
            checkBox_M.Checked = false;
            checkBox_CTs.Checked = false;
            checkBox_IO.Checked = false;
        }
        #endregion // Set the tag area variable

        private void ComboBox_tagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_notifications.Items.Add(plcSimMainFunction.readPLCTagValue(
                comboBox_PLC_list.SelectedItem.ToString(), 
                comboBox_tagList.SelectedItem.ToString()));

            //Write tag value to text box
            textBox_tagValue.Text = PLCSimMainFunctions.tagValue.ToString();
        }

        private void Btn_writeTag_Click(object sender, EventArgs e)
        {
            listBox_notifications.Items.Add(plcSimMainFunction.writePLCTagValue(
                comboBox_PLC_list.SelectedItem.ToString(),
                comboBox_tagList.SelectedItem.ToString(),
                textBox_setTagValue.Text));
            //Write tag value to text box
            textBox_tagValue.Text = PLCSimMainFunctions.tagValue.ToString();
        }
        #endregion // Read/Write tag

        #region Read/Write address
        private void Btn_readFromAddress_Click(object sender, EventArgs e)
        {
            switch (comboBox_addressType.SelectedItem.ToString())
            {
                case "Bit":
                    listBox_notifications.Items.Add(plcSimMainFunction.readBitfromPLC(
                        comboBox_PLC_list.SelectedItem.ToString(),
                        textBox_IOAddress.ToString(),
                        comboBox_addressArea.SelectedItem.ToString(),
                        textBox_addressBit.ToString()));
                    textBox_addressValue.Text = PLCSimMainFunctions.addressValue;
                    break;
                case "Byte":
                    listBox_notifications.Items.Add(plcSimMainFunction.readBytefromPLC(
                        comboBox_PLC_list.SelectedItem.ToString(),
                        textBox_IOAddress.ToString(),
                        comboBox_addressArea.SelectedItem.ToString()));
                    textBox_addressValue.Text = PLCSimMainFunctions.addressValue;
                    break;
            }
        }

        private void Btn_writeToAddess_Click(object sender, EventArgs e)
        {
            switch (comboBox_addressType.SelectedItem.ToString())
            {
                case "Bit":
                    listBox_notifications.Items.Add(plcSimMainFunction.writeBitToPLC(
                        comboBox_PLC_list.SelectedItem.ToString(),
                        textBox_IOAddress.Text,
                        comboBox_addressArea.SelectedItem.ToString(),
                        textBox_addressBit.Text,
                        textBox_addressValue.Text));
                    break;
                case "Byte":
                    listBox_notifications.Items.Add(plcSimMainFunction.writeByteToPLC(
                        comboBox_PLC_list.SelectedItem.ToString(),
                        textBox_IOAddress.Text,
                        comboBox_addressArea.SelectedItem.ToString(),
                        textBox_addressValue.Text));
                    break;
            }
        }
        #endregion // Read/Write address

        #region CoSimulation
        private void Btn_StartSimulation_Click(object sender, EventArgs e)
        {
            // TODO - work on error handling for opening and closing of the SimInterface window
            try
            {
                if(comboBox_PLC_list.SelectedItem != null)
                {
                    // Connect to Modbus server
                    if(! CellClient.IsConnected())
                    {
                        ConnectModbusClient();
                    }
                    PlcInstance.currentPlcName = comboBox_PLC_list.SelectedItem.ToString();
                    // Make IO and ONLY required DB tags available
                    PlcInstance.UpdateTags();
                    CoSimulationInstance = new CoSimulation(textBox_ConfigFilePath.Text);
                    simInterface = new CoSimInterface(CoSimulationInstance);
                    simInterface.Show();
                    listBox_notifications.Items.Add("Simulation has started.");
                }
                else
                {
                    MessageBox.Show("Please create/choose a PLC instance.");
                }
            }
            catch(ArgumentException ex) 
            {
                MessageBox.Show(ex.Message + " Please choose a configuration file.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + " Please create/choose a PLC instance.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btn_BrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                textBox_ConfigFilePath.Text = filepath;
                listBox_notifications.Items.Add("File path has been selected.");
            }
        }
        private void Btn_StopSimulation_Click(object sender, EventArgs e)
        {
            // Diconnect Modbus client
            DisconnectModbusClient();
            simInterface.Close();
            simInterface.IOUpdateTimer.Stop();
            listBox_notifications.Items.Add("Simulation has been stopped.");
        }

        #region Modbus
        private void Button_ConnectCell_Click(object sender, EventArgs e)
        {
            ConnectModbusClient();
        }

        private void Button_DisconnectCell_Click(object sender, EventArgs e)
        {
            DisconnectModbusClient();
        }

        private void ConnectModbusClient()
        {
            try
            {
                CellClient.Connect(TextBox_ModbusServerIP.Text, TextBox_ModbusPort.Text);
                MessageBox.Show("Connected to ModBus server.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to connect. " + ex.Message);
            }
        }

        private void DisconnectModbusClient()
        {
            try
            {
                CellClient.Disconnect();
                MessageBox.Show("ModBus client diconnected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion //Modbus

        #endregion // CoSimulation
    }
}
