﻿using System;
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
        public static PlcInstanceInterface PlcInstance;
        // Private fields
        // Instace of the simulation interface
        private CoSimInterface simInterface;
        //Cosimulation instance
        private CoSimulation CoSimulationInstance;
        // Instance of Testing interface
        private TestingInterface testingInterface;
        //Modbus connection
        public static ModbusCommunication CellClient;
        #endregion // Fields

        #region Ctor
        public MainInterface()
        {
            InitializeComponent();
            //Add already created PLC instances
            UpdatePlcComboBox();
            // Modbus client
            CellClient = new ModbusCommunication();
            //Fill in Modbus parameters
            // This is the IP and port used for Miyano
            TextBox_ModbusServerIP.Text = "192.168.6.201";
            TextBox_ModbusPort.Text = "3002";
        }
        #endregion //Ctor

        #region Interface events
        private void UpdateLabels()
        {
            //Turning the PLC takes time, for now check if the object is null
            label_OpState.Text = PlcInstance.GetOperatingState();
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
                comboBox_PLC_list.SelectedIndex = 0; // Select the first item in the updated list.
            }
        }
        private void ComboBox_PLC_list_SelectedIndexChanged(object sender, EventArgs e)
        {

            PlcInstance = new PLCInstance(comboBox_PLC_list.SelectedItem.ToString());
            PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
            UpdateLabels();
        }
        #endregion // Interface events

        #region PLC controls
        private void Btn_updatePlcList_Click(object sender, EventArgs e)
        {
            UpdatePlcComboBox();
        }
        private void Btn_PwrON_Click(object sender, EventArgs e)
        {
            //V2
            try
            {
                PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                PlcInstance.PowerOnPLC();
                listBox_notifications.Items.Add("PLC instance has been turned ON.");
                UpdateLabels();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + " Please choose a PLC instance.");
            }
        }
        private void Btn_PwrOFF_Click(object sender, EventArgs e)
        {
            //V2
            try
            {
                PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                PlcInstance.PowerOffPLC();
                listBox_notifications.Items.Add("PLC instance has been turned off.");
                UpdateLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please choose a PLC instance.");
            }
        }
        private void Btn_Reboot_Click(object sender, EventArgs e)
        {
            //V2
            try
            {
                PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                PlcInstance.ResetPLC();
                listBox_notifications.Items.Add("PLC memory has been reset.");
                UpdateLabels();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message + " Please choose a PLC instance."); 
            }
        }
        private void Btn_Run_Click(object sender, EventArgs e)
        {
            //V2
            try
            {
                PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                PlcInstance.RunPLC();
                listBox_notifications.Items.Add("PLC is in RUN mode.");
                UpdateLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please choose a PLC instance.");
            }
        }
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            //V2
            try
            {
                PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                PlcInstance.StopPLC();
                listBox_notifications.Items.Add("PLC is in STOP mode.");
                UpdateLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please choose a PLC instance.");
            }
        }
        #endregion // PLC controls

        #region CoSimulation
        private void Btn_StartSimulation_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to Modbus server
                if (!CellClient.IsConnected())
                {
                    ConnectModbusClient();
                }
                // If Cell only simulation is checked.
                if(CheckBox_CellOnly.Checked)
                {
                    PlcInstance = new DummyPlcInstance("dummy");
                    CoSimulationInstance = new CoSimulation(textBox_ConfigFilePath.Text);
                    simInterface = new CoSimInterface(CoSimulationInstance, CheckBox_CellOnly.Checked);
                    simInterface.Show();
                    listBox_notifications.Items.Add("Simulation has started.");
                }
                else if (comboBox_PLC_list.SelectedItem != null)
                {
                    // Make IO and ONLY required DB tags available
                    PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                    PlcInstance.UpdateTags();
                    CoSimulationInstance = new CoSimulation(textBox_ConfigFilePath.Text);
                    simInterface = new CoSimInterface(CoSimulationInstance, CheckBox_CellOnly.Checked);
                    simInterface.Show();
                    listBox_notifications.Items.Add("Simulation has started.");
                }
                else
                {
                    MessageBox.Show("Please choose a PLC instance or select 'CELL only'.");
                }
            }
            catch(ArgumentException ex) 
            {
                MessageBox.Show(ex.Message + " Please choose a configuration file.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + " Please choose a PLC instance.");
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
                // Check if connection was successful
                if (CellClient.IsConnected())
                {
                    listBox_notifications.Items.Add("Connected to Modbus server.");
                }
                else
                {
                    listBox_notifications.Items.Add("Connection failed.");
                }
            }
            catch(Exception ex)
            {
                listBox_notifications.Items.Add("Unable to connect. " + ex.Message);
            }
        }

        private void DisconnectModbusClient()
        {
            try
            {
                CellClient.Disconnect();
                listBox_notifications.Items.Add("ModBus client diconnected.");
            }
            catch (Exception ex)
            {
                listBox_notifications.Items.Add(ex.Message);
            }
        }
        #endregion //Modbus

        #endregion // CoSimulation

        #region Testing
        private void Btn_TestingLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to Modbus server
                if (!CellClient.IsConnected())
                {
                    ConnectModbusClient();
                }
                // If Cell only simulation is checked.
                if (CheckBox_CellOnly.Checked)
                {
                    // Can't run test
                    MessageBox.Show("Can't open test interface on 'CELL Only' mode. Please uncheck.");
                }
                else if (comboBox_PLC_list.SelectedItem != null)
                {
                    // Make IO and ONLY required DB tags available
                    PlcInstance.UpdateInterface(comboBox_PLC_list.SelectedItem.ToString());
                    PlcInstance.UpdateTags();
                    CoSimulationInstance = new CoSimulation(textBox_ConfigFilePath.Text);
                    // TODO - Create testing class instance here
                    testingInterface = new TestingInterface(CoSimulationInstance);
                    testingInterface.Show();
                    listBox_notifications.Items.Add("Testing interface started.");
                }
                else
                {
                    MessageBox.Show("Please choose a PLC instance.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + " Please choose a configuration file.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + " Please cchoose a PLC instance.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion // Testing
    }
}
