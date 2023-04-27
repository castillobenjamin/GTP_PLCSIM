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
using static PLCSIM_Adv_CoSimulation.Utilities.Utils;
using static System.Windows.Forms.LinkLabel;

namespace PLCSIM_Adv_CoSimulation
{
    public partial class TestingInterface : Form
    {
        #region Fields
        // Alphabot System shortcuts
        private readonly CoSimulation CoSimulationInstance;
        private CellCommunication Cell;
        private List<Stopper> Stoppers;

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
            //Initialize instance shortcut variables
            Cell = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance;
            Stoppers = CoSimulationInstance.AlphaBotSystem.Stoppers;
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
            Cell.IsCellConnectedPulse.Value = HeartBeatCounter;
        }
        #endregion // Timer

        #region Simulation
        // TODO - add a method for every input.
        #region CELL
        /// <summary>
        /// Turn on CELL
        /// </summary>
        /// <returns>True if successful.</returns>
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

        /// <summary>
        /// Turn off CELL
        /// </summary>
        /// <returns>True if successful.</returns>
        private bool CellTurnOff()
        {
            try
            {
                HeartBeatTimer.Stop();
                return UpdateInput(
                    Cell.IsCellConnectedPulse, 
                    0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Start system operation
        /// </summary>
        /// <returns>True if successful.</returns>
        private bool CellStart()
        {
            try
            {
                ushort bitPos =
                    Cell.SystemIsStartingUp.BitPosition;
                UpdateInput(
                    Cell.CanSystemStartUp, 
                    0);
                return UpdateInput(
                    Cell.SystemIsStartingUp, 
                    Utils.SingleBitInWordValues[bitPos]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stop system operation
        /// </summary>
        /// <returns>True if successful</returns>
        private bool CellStop()
        {
            try
            {
                ushort bitPos = 
                    Cell.CanSystemStartUp.BitPosition;
                UpdateInput(
                    Cell.SystemIsStartingUp, 
                    0);
                return UpdateInput(
                    Cell.CanSystemStartUp, 
                    Utils.SingleBitInWordValues[bitPos]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion // CELL

        #region Zoning
        /// <summary>
        /// Send a zoning command to the corresponding area.
        /// </summary>
        /// <param name="areaZoning">the "zoning" instance of </param>
        /// <param name="command">Zoning command to be sent. Accepted values are defined in 'Utils/CellCommandValues'</param>
        /// <returns>True if successful.</returns>
        private bool ZoningSendCommand(Zoning areaZoning, byte command)
        {
            bool updateSuccess;
            try
            {
                updateSuccess = UpdateInput(areaZoning.CellCommand, command);
                // Log
                return updateSuccess;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Read the zoning status of the corresponding area.
        /// </summary>
        /// <param name="areaZoning"></param>
        /// <param name="expectedStatus">Accepted status values are defined in 'Utils/ZoningStatuses'</param>
        /// <returns></returns>
        private bool ZoningReadStatus(Zoning areaZoning, byte expectedStatus)
        {
            bool readSuccess;
            try
            {
                readSuccess = ReadOutput(areaZoning.ZoningStatus, expectedStatus);
                return true;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Executes zoning request routine for specified Aisle.
        /// </summary>
        /// <param name="aisle"></param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ZoningRequestRoutine(Aisle aisle)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            byte zoningCommand = (byte)Utils.CellCommandValues.Permit;
            try
            {
                stepOk &= UpdateInput(aisle.OperationBox.RequestBtn, true); // Press request button
                // TODO - need to wait 2 seconds here
                stepOk &= UpdateInput(aisle.OperationBox.RequestBtn, true); // Release request button after specified time
                stepOk &= ZoningReadStatus(aisle.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(aisle.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(aisle.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningReadStatus(aisle.Zoning, Utils.ZoningStatusBytes["Permit"]);
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Executes zoning request routine for specified Deck.
        /// </summary>
        /// <param name="aisle"></param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ZoningRequestRoutine(Deck deck)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            byte zoningCommand = (byte)Utils.CellCommandValues.Permit;
            try
            {
                stepOk &= UpdateInput(deck.OperationBox.RequestBtn, true); // Press request button
                // TODO - need to wait 2 seconds here
                // TODO - add wait time between each step? Probably necessary to wait for PLC to update.
                stepOk &= UpdateInput(deck.OperationBox.RequestBtn, true); // Release request button after specified time
                stepOk &= ZoningReadStatus(deck.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(deck.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(deck.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningReadStatus(deck.Zoning, Utils.ZoningStatusBytes["Permit"]);
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Executes zoning request routine for specified DWS.
        /// NOTE: Because the DWS controls are on the HMI, this routine needs user interaction
        /// </summary>
        /// <param name="aisle"></param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ZoningRequestRoutine(DynamicWorkStation dws)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            byte zoningCommand = (byte)Utils.CellCommandValues.Permit;
            try
            {
                MessageBox.Show("Press Request button of " + dws.Label + " on HMI."); // Press request button
                stepOk &= ZoningReadStatus(dws.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(dws.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(dws.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningReadStatus(dws.Zoning, Utils.ZoningStatusBytes["Permit"]);
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion // Zoning

        #region Panels

        private bool DwsPanelResetPress()
        {
            try
            {
                return UpdateInput(
                    CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn,
                    true);
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
                return UpdateInput(
                    CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn, 
                    false);
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
        /// <summary>
        ///  Open or close the stoppers of the specified area.
        /// </summary>
        /// <param name="areaName">Name of the area related to stoppers to be actuated</param>
        /// <param name="action">"close" or "open"</param>
        /// <returns></returns>
        private bool StopperActuateRoutine(string areaName, string action)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            try
            {
                // Loop through stoppers
                Stoppers.ForEach(stopper =>
                {
                    // Check if the name of the current stopper includes the name of the current area.
                    if (stopper.Name.Contains(areaName))
                    {
                        // Call the corresponding function depending on the "action" parameter
                        if (action == "close")
                        {
                            stepOk = stepOk & StopperClose(stopper);
                        }
                        else if (action == "open")
                        {
                            stepOk = stepOk & StopperOpen(stopper);
                        }
                        else
                        {
                            // TODO - add code here.
                        }
                    }
                });
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Close a stopper.
        /// </summary>
        /// <param name="stopper">Stopper to be closed</param>
        /// <returns></returns>
        private bool StopperClose(Stopper stopper)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            try
            {
                // If the stopper is already closed, return true.
                if (ReadOutput(stopper.IsClosedStatusToCell, true))
                {
                    stepOk = true;
                }
                // Check if the stopper is open.
                else if (ReadOutput(stopper.IsOpenStatusToCell, true))
                {
                    stepOk &= UpdateInput(stopper.CloseCommandFromCell, true); // Send close command
                    stepOk &= ReadOutput(stopper.IsClosedStatusToCell, true); // Read the closed status signal
                }
                else
                {
                    stepOk = false;
                }
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  Open a stopper.
        /// </summary>
        /// <param name="stopper">Stopper to be open</param>
        /// <returns></returns>
        private bool StopperOpen(Stopper stopper)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            try
            {
                // If the stopper is already open, return true.
                if (ReadOutput(stopper.IsOpenStatusToCell, true))
                {
                    stepOk = true;
                }
                // Check if the stopper is closed.
                else if (ReadOutput(stopper.IsClosedStatusToCell, true))
                {
                    stepOk &= UpdateInput(stopper.OpenCommandFromCell, true); // Send open command
                    stepOk &= ReadOutput(stopper.IsClosedStatusToCell, true); // Read the closed status signal
                }
                else
                {
                    stepOk = false;
                }
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool StopperChangeClosed(Stopper stopper)
        {
            return true;
        }
        #endregion // Stoppers

        #region Evacuation rails

        #endregion // Evacuation rails

        #region Fire shutter

        #endregion // Fire shutter

        #region Common methods
        // TODO - add delay inside the common methods to wait for the PLC to take care of its business.
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

        #region Read output
        /// <summary>
        /// Checks the output signal value.
        /// </summary>
        /// <param name="output"></param>
        /// <returns>True if the output had the expected value. False if the value is different or the method fails.</returns>
        private bool ReadOutput(PlcOutput output, bool expectedValue)
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
        private bool ReadOutput(RegisterFromPlc register, bool expectedValue)
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
        /// <returns>True if the byte had the expected value. False if the value is different or the method fails.</returns>
        private bool ReadOutput(RegisterFromPlc register, byte expectedValue)
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
        #endregion // Read output

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
                executionMessage = instruction 
                    + " - Execution " 
                    + (executionIsSuccessful ? "complete." : "failed.");
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
