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
        private readonly uint WaitTime = 500; 
        // Timer
        private Timer HeartBeatTimer = new Timer();
        // Interval
        readonly private int TimerInterval = 500;
        // Counter to simulate the CELL pulse.
        private byte HeartBeatCounter = 0;
        // Output file name
        // TODO - Assign file name dynamically
        private readonly string fileName = "TestResults_TestName_ProgramVersion_Date_Time";
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

        #region Methods

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

        #region Simulation
        // TODO - add a method for every input.
        #region CELL
        private bool CellTurnOn()
        {
            try
            {
                HeartBeatTimer.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CellTurnOff()
        {
            try
            {
                HeartBeatTimer.Stop();
                return UpdateInput(CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CellStart()
        {
            try
            {
                ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.BitPosition;
                UpdateInput(CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp, 0);
                return UpdateInput(CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp, Utils.SingleBitInWordValues[bitPos]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CellStop()
        {
            try
            {
                ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.BitPosition;
                UpdateInput(CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp, 0);
                return UpdateInput(CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp, Utils.SingleBitInWordValues[bitPos]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion // CELL

        #region Subsystems

        #region Panels

        private bool DwsPanelResetPress()
        {
            try
            {
                return UpdateInput(CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool DwsPanelResetRelease()
        {
            try
            {
                return UpdateInput(CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion // Panels

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
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

        #endregion // Simulation

        #region Interface
        private void Btn_StartTest_Click(object sender, EventArgs e)
        {
            // Local Fields
            string[] instructions;
            string[] testResults;
            bool OutputOk;
            //Read file with test instructions
            try
            {
                // Get test instructions
                instructions = Utils.ConvertTextFile2List(TextBox_TestFilePath.Text);
                // Execute test instructions
                testResults = ExecuteTestInstructions(instructions);
                ListBox_Log.Items.Add(testResults);
                // TODO - output test results to a file.
                OutputOk = Utils.ConvertList2File(testResults, fileName);
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
        /// <returns>string array with the execution results</returns>
        private string[] ExecuteTestInstructions(string[] instructions)
        {
            // TODO - Add a case for every possible instruction
            // TODO - log action and results of each iteration.
            bool executionIsSuccessful;
            string executionMessage;
            string[] results = new string[instructions.Length];
            string instruction;
            for(int i=0; i<instructions.Length; i++)
            {
                instruction = instructions[i];
                executionIsSuccessful = false;
                if (instruction.Contains("Cell"))
                {
                    switch (instruction)
                    {
                        case "CellTurnOn":
                            executionIsSuccessful = CellTurnOn();
                            break;
                        case "CellStart":
                            executionIsSuccessful = CellStart();
                            break;
                        case "CellTurnOff":
                            executionIsSuccessful = CellTurnOff();
                            break;
                        case "CellStop":
                            executionIsSuccessful = CellStop();
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' instruction was not recognized.");
                            // code block
                            break;
                    }
                }
                else if (instruction.Contains("DwsPanel"))
                {
                    switch (instruction)
                    {
                        case "DwsPanelResetPress":
                            executionIsSuccessful = DwsPanelResetPress();
                            break;
                        case "DwsPanelResetRelease":
                            executionIsSuccessful = DwsPanelResetRelease();
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' instruction was not recognized.");
                            // code block
                            break;
                    }
                }
                else
                {
                    switch (instruction)
                    {
                        case "DummyInstruction":
                            executionIsSuccessful = false;
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' instruction was not recognized.");
                            // code block
                            break;
                    }
                }
                // Log execution results
                executionMessage = instruction + " - Execution " + (executionIsSuccessful ? "complete." : "failed.");
                ListBox_Log.Items.Add(executionMessage);
                results[i] = executionMessage;
                // TODO - Replace pop up window with a delay here?
                MessageBox.Show("Confirm execution.");
            }
            // Return a string with the results of the test run.
            return results;
        }

        #endregion // Test execution

        #endregion // Methods
    }
}
