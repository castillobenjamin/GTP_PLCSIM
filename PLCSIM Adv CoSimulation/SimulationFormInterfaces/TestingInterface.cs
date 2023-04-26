using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace PLCSIM_Adv_CoSimulation
{
    public partial class TestingInterface : Form
    {
        #region Fields
        private readonly CoSimulation CoSimulationInstance;
        private readonly int InstructionWaitTime = 500; 
        // Timer
        private Timer HeartBeatTimer = new Timer();
        // Interval
        readonly private int TimerInterval = 500;
        // Counter to simulate the CELL pulse.
        private byte HeartBeatCounter = 0;
        #endregion // Fields

        #region Initialization
        public TestingInterface(CoSimulation coSimulationInstance)
        {
            InitializeComponent();
            CoSimulationInstance = coSimulationInstance;
            // Initialize timer
            HeartBeatTimer.Tick += new EventHandler(TimerEventProcessor);
            HeartBeatTimer.Interval = TimerInterval;
        }
        #endregion // Initialization

        #region Timer
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            HeartBeatTimer.Stop();
            // Restarts the timer.
            HeartBeatTimer.Enabled = true;
            // Simulate CELL pulse
            HeartBeatCounter = Utils.CountByteUp(HeartBeatCounter);
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse.Value = HeartBeatCounter;
        }
        #endregion // Timer

        #region Configuration

        private void TextBox_ProgramVersion_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion // Configuration

        #region Methods
        // TODO - add a method for every input.
        #region CELL
        private void TurnOnCell()
        {
            HeartBeatTimer.Start();
        }

        private void TurnOffCell()
        {
            HeartBeatTimer.Stop();
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse.Value = 0;
        }

        private void StartCellOperation()
        {
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.Value = 0;
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.Value =
                Utils.SingleBitInWordValues[bitPos];
        }

        private void StopCellOperation()
        {
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.Value = 0;
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.Value =
                Utils.SingleBitInWordValues[bitPos];
        }

        #endregion // CELL

        #region Subsystems

        #region Aisles

        private void PressAisleEstopButton(int aisleNum)
        {
            bool isPressSuccessful = UpdateInput(CoSimulationInstance.AlphaBotSystem.Aisles[aisleNum].OperationBox.EmergencyBtn, true);
        }

        #endregion // Aisles

        #region Decks

        #endregion // Decks

        #region Dynamic Work Stations

        #endregion // Dynamic Work Stations

        #region Stoppers

        #endregion // Stoppers

        #region Evacuation rails

        #endregion // Evacuation rails

        #region Fire shutter

        #endregion // Fire shutter

        #endregion // Subsystems

        #region Common methods
        #region Update input
        /// <summary>
        /// Updates the input signal value.
        /// </summary>
        /// <param name="button"></param>
        /// <returns>True if the input was successfully updated. False if the method failed.</returns>
        private bool UpdateInput(PlcInput input, bool updateValue)
        {
            try
            {
                input.Value = updateValue;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates one bit of the input register.
        /// </summary>
        /// <param name="register"></param>
        /// <param name="updateValue"></param>
        /// <returns>True if the input was successfully updated. False if the method failed.</returns>
        private bool UpdateInput(RegisterToPlc register, bool updateValue)
        {
            try
            {
                register.Value = Utils.UpdateRegister(register, updateValue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the complete input register.
        /// </summary>
        /// <param name="register"></param>
        /// <param name="updateValue"></param>
        /// <returns>True if the input was successfully updated. False if the method failed.</returns>
        private bool UpdateInput(RegisterToPlc register, ushort updateValue)
        {
            try
            {
                register.Value = updateValue;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion // Update input

        #region Check output
        /// <summary>
        /// Checks the output signal value.
        /// </summary>
        /// <param name="output"></param>
        /// <returns>True if the output had the expected value. False if the value is different or the method fails.</returns>
        private bool CheckOutput(PlcOutput output, bool expectedValue)
        {
            try
            {
                if (output.Value == expectedValue) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the value of a single bit in a register.
        /// </summary>
        /// <param name="register"></param>
        /// <returns>True if the bit had the expected value. False if the value is different or the method fails.</returns>
        private bool CheckOutput(RegisterFromPlc register, bool expectedValue)
        {
            try
            {
                if (Utils.ReadRegisterBit(register) == expectedValue) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the value of a byte in a register.
        /// </summary>
        /// <param name="register"></param>
        /// <param name="expectedValue"></param>
        /// <returns>True if the bit had the expected value. False if the value is different or the method fails.</returns>
        private bool CheckOutput(RegisterFromPlc register, byte expectedValue)
        {
            try
            {
                if (Utils.GetLowerByte(register.Value) == expectedValue) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion // Check output

        #endregion // Common methods

        #region Interface
        private void Btn_StartTest_Click(object sender, EventArgs e)
        {

            // Local Fields
            string[] instructions;
            string testResults;

            // TODO - Implementation test loop

            //Read file with test instructions
            try
            {
                instructions = Utils.ConvertTextFile2List(TextBox_TestFilePath.Text);
                // Execute test instructions
                testResults = ExecuteTestInstructions(instructions);
                ListBox_Log.Items.Add(testResults);
                // TODO - output test results to a file.
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + " Please choose a test file.");
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
                TextBox_TestFilePath.Text = filepath;
                ListBox_Log.Items.Add("File path has been selected.");
            }
        }
        #endregion // Interface

        #region Test execution
        /// <summary>
        /// Runs the instructions specified on the Test file.
        /// </summary>
        /// <param name="instructions">String array </param>
        /// <returns></returns>
        private string ExecuteTestInstructions(string[] instructions)
        {
            // TODO - Add a case for every possible instruction
            // TODO - Add an execution confirmation check
            // TODO - Think of how to loop list of instructions
            // TODO - log action and results of each iteration.
            // bool executionIsSuccessful = false;
            foreach (string instruction in instructions)
            {
                ListBox_Log.Items.Add("Instruction: " + instruction);
                switch (instruction)
                {
                    case "TurnOnCell":
                        TurnOnCell();
                        ListBox_Log.Items.Add("Turn on CELL.");
                        break;
                    case "StartCellOperation":
                        StartCellOperation();
                        ListBox_Log.Items.Add("Start CELL operation.");
                        break;
                    case "TurnOffCell":
                        TurnOffCell();
                        ListBox_Log.Items.Add("Turn off CELL.");
                        break;
                    case "StopCellOperation":
                        StopCellOperation();
                        ListBox_Log.Items.Add("Stop CELL operation.");
                        break;
                    default:
                        // code block
                        break;
                }
                // TODO - remove message box and add a delay here.
                MessageBox.Show("Confirm Instruction.");
            }
            // TODO - return a string with the actual results of the test run.
            return "These are the results: _____";
        }

        #endregion // Test execution

        #endregion // Methods
    }
}
