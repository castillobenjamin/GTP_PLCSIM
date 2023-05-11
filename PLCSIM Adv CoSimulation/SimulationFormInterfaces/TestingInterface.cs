using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
        private List<Aisle> AisleList;
        private List<Deck> DeckList;
        private List<DynamicWorkStation> DwsList;

        private readonly uint WaitTime = 500; 
        // Timers
        private Timer HeartBeatTimer = new Timer();
        private Timer OutputTimer = new Timer();
        // Interval used for all timers
        readonly private int TimerInterval = 200;
        // Stop watch
        Stopwatch WaitForPlc; // Used to wait after the execution of every instruction.
        int InstructionWaitTime = 250;
        // Counter to simulate the CELL pulse.
        private byte HeartBeatCounter = 0;
        // Output file name
        // TODO - Assign file name dynamically
        private readonly string fileName = "TestResults_TestName_ProgramVersion_Date_Time";
        // Constants
        private readonly uint MAX_INSTRUCTION_PARAMS = 3;
        // Error messages
        private readonly string AREA_NOT_RECOGNIZED = "Could not recognize the specified area.";
        private readonly string UNHANDLED_EXCEPTION = "An unhandled exception has occured.";
        private readonly string FORMAT_EXCEPTION = "The format of one or more instruction parameters is incorrect.";
        private readonly string UNRECOGNIZED_INSTRUCTION = "Instruction was not recognized.";
        #endregion // Fields

        #region Initialization
        public TestingInterface(CoSimulation coSimulationInstance)
        {
            InitializeComponent();
            CoSimulationInstance = coSimulationInstance;
            // Initialize timers
            HeartBeatTimer.Tick += new EventHandler(HeartBeatEventProcessor);
            HeartBeatTimer.Interval = TimerInterval;
            OutputTimer.Tick += new EventHandler(OutputEventProcessor);
            OutputTimer.Interval = TimerInterval;
            // Initialize instance shortcut variables
            Cell = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance;
            Stoppers = CoSimulationInstance.AlphaBotSystem.Stoppers;
            AisleList = CoSimulationInstance.AlphaBotSystem.Aisles;
            DeckList = CoSimulationInstance.AlphaBotSystem.Decks;
            DwsList = CoSimulationInstance.AlphaBotSystem.DynamicWorkStations;
        }
        #endregion // Initialization

        #region Methods

        #region Timers
        /// <summary>
        /// Timer used to simulate CELL heart beat signal.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void HeartBeatEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            HeartBeatTimer.Stop();
            // Restarts the timer.
            HeartBeatTimer.Enabled = true;
            // Simulate CELL pulse
            HeartBeatCounter = Utils.CountByteUp(HeartBeatCounter);
            Cell.IsCellConnectedPulse.Value = HeartBeatCounter;
        }

        /// <summary>
        /// Timer used to update plc output values.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void OutputEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            OutputTimer.Stop();
            OutputTimer.Enabled = true;
            // TODO - create method
            // ReadPlcOutputs();
        }
        #endregion // Timers

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

        /// <summary>
        /// Confirm the error status of the PLC
        /// </summary>
        /// <param name="errorIsExpected">"True" if Error status is expected. Else "False"</param>
        /// <returns></returns>
        private bool CellConfirmPlcErrorStatus(string errorIsExpected)
        {

            try
            {
                // TODO - add code
                return true;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Confirm the warning status of the PLC
        /// </summary>
        /// <param name="warningIsExpected">"True" if Warning status is expected. Else "False"</param>
        /// <returns></returns>
        private bool CellConfirmPlcWarningStatus(string warningIsExpected)
        {
            try
            {
                // TODO - add code
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Confirm the mode of the PLC
        /// </summary>
        /// <param name="expectedMode">"Manual" or "Auto".</param>
        /// <returns></returns>
        private bool CellConfirmPlcMode(string expectedMode)
        {
            try
            {
                // TODO - add code
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion // CELL

        #region Zoning
        /// <summary>
        /// Send zoning command. Takes a string as the area input
        /// </summary>
        /// <param name="area">For example: "aisle1", "deck4", "dws5"</param>
        /// <param name="command">Command in string form. See 'Utils/CellCommandValues' for accepted values</param>
        /// <returns></returns>
        private bool ZoningSendCommand(string area, string command)
        {
            // Local variables
            object parsedArea;
            byte parsedCommand;
            Aisle aisle;
            Deck deck;
            DynamicWorkStation dws;
            try
            {
                // Get index from area string
                parsedCommand = CellCommands[command];
                parsedArea = ConvertStringToArea(area);
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return ZoningSendCommand(aisle.Zoning, parsedCommand);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return ZoningSendCommand(deck.Zoning, parsedCommand);
                }
                else if (parsedArea is DynamicWorkStation)
                {
                    dws = (DynamicWorkStation)parsedArea;
                    return ZoningSendCommand(dws.Zoning, parsedCommand);
                }
                else
                {
                    MessageBox.Show(AREA_NOT_RECOGNIZED + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(UNHANDLED_EXCEPTION + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Send a zoning command to the corresponding area. Takes a zoning object as input.
        /// </summary>
        /// <param name="areaZoning">the "zoning" instance of an area</param>
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
        /// Read zoning status. Takes a string as area input.
        /// </summary>
        /// <param name="area">For example: "aisle1", "deck4", "dws5"</param>
        /// <param name="expectedStatus">See 'Utils/ZoningStatuses'</param>
        /// <returns></returns>
        private bool ZoningConfirmStatus(string area, string expectedStatus)
        {
            // Local variables
            byte parsedStatus;
            object parsedArea;
            Aisle aisle;
            Deck deck;
            DynamicWorkStation dws;
            try
            {
                parsedStatus = ZoningStatusBytes[expectedStatus];
                parsedArea = ConvertStringToArea(area);
                // TODO - need to make sure this conditions work
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return ZoningConfirmStatus(aisle.Zoning, parsedStatus);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return ZoningConfirmStatus(deck.Zoning, parsedStatus);
                }
                else if (parsedArea is DynamicWorkStation)
                {
                    dws = (DynamicWorkStation)parsedArea;
                    return ZoningConfirmStatus(dws.Zoning, parsedStatus);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ZoningConfirmStatus exception " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Read the zoning status of the corresponding area. Takes a zoning object as area input.
        /// </summary>
        /// <param name="areaZoning">the "zoning" instance of an area</param>
        /// <param name="expectedStatus">Accepted status values are defined in 'Utils/ZoningStatuses'</param>
        /// <returns></returns>
        private bool ZoningConfirmStatus(Zoning areaZoning, byte expectedStatus)
        {
            bool readSuccess;
            try
            {
                readSuccess = ReadOutput(areaZoning.ZoningStatus, expectedStatus);
                return readSuccess;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Executes zoning request routine for specified area. Takes a string as area input.
        /// </summary>
        /// <param name="area"></param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ZoningRequestRoutine(string area)
        {
            // Local variables
            object parsedArea;
            Aisle aisle;
            Deck deck;
            DynamicWorkStation dws;
            try
            {
                parsedArea = ConvertStringToArea(area);
                // TODO - need to make sure this conditions work
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return ZoningRequestRoutine(aisle);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return ZoningRequestRoutine(deck);
                }
                else if (parsedArea is DynamicWorkStation)
                {
                    dws = (DynamicWorkStation)parsedArea;
                    return ZoningRequestRoutine(dws);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
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
                stepOk &= ZoningConfirmStatus(aisle.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(aisle.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(aisle.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningConfirmStatus(aisle.Zoning, Utils.ZoningStatusBytes["Permit"]);
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
                stepOk &= ZoningConfirmStatus(deck.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(deck.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(deck.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningConfirmStatus(deck.Zoning, Utils.ZoningStatusBytes["Permit"]);
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
                stepOk &= ZoningConfirmStatus(dws.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                stepOk &= StopperActuateRoutine(dws.Name, "close"); // Close all stoppers for the specified area
                stepOk &= ZoningSendCommand(dws.Zoning, zoningCommand); // Send "Permit" command
                stepOk &= ZoningConfirmStatus(dws.Zoning, Utils.ZoningStatusBytes["Permit"]);
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
                    // TODO - need to wait here.
                    // TODO - Add stopper actuation logic.
                    // If using an auto stopper simulation, as soon as the output is turned on, the sensor logic is taken care of. 
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
                    // TODO - need to wait here.
                    // TODO - Add stopper actuation logic.
                    // If using an auto stopper simulation, as soon as the output is turned on, the sensor logic is taken care of. 
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
        /// Manually update the sensor input values of a given stopper.
        /// </summary>
        /// <param name="stopper"></param>
        /// <param name=""></param>
        /// <returns></returns>
        private bool StopperUpdateSensor(Stopper stopper, string sensor)
        {
            // TODO - add code. Might not need this method.
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

        #region Buttons
        /// <summary>
        /// Press/Release the Estop button of the specified zone.
        /// </summary>
        /// <param name="area">String of format "Zone#". E.g.: "Aisle2", "Deck4", etc.</param>
        /// <param name="action">"True" for Press. "False" for Release.</param>
        /// <returns></returns>
        private bool EstopBtnOperation(string area, string action)
        {
            // Local variables
            object parsedArea;
            bool parsedAction;
            Aisle aisle;
            Deck deck;
            DynamicWorkStation dws;
            try
            {
                parsedArea = ConvertStringToArea(area);
                parsedAction = Convert.ToBoolean(action);
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return UpdateInput(aisle.OperationBox.EmergencyBtn, parsedAction);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return UpdateInput(deck.OperationBox.EmergencyBtn, parsedAction);
                }
                else if (parsedArea is DynamicWorkStation)
                {
                    dws = (DynamicWorkStation)parsedArea;
                    return UpdateInput(dws.EmergencyBtn, parsedAction);
                }
                else
                {
                    MessageBox.Show(AREA_NOT_RECOGNIZED + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show(FORMAT_EXCEPTION + " " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(UNHANDLED_EXCEPTION + " " + ex.Message);
                return false;
            }
        }
        #endregion // Buttons

        #region RegEx
        /// <summary>
        /// Returns only one match of consecutive digits in the input string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private Match FindDigitsInString(String inputString)
        {
            // Use regex to find digits in the input string
            Regex regex = new Regex(@"\d+");
            // Check for one match of consecutive digits in inputString
            Match match = regex.Match(inputString);
            return match;
        }

        #endregion // RegEx

        /// <summary>
        /// Converts a string to a specific area.
        /// </summary>
        /// <param name="area">For example: "aisle1", "deck4", "dws5"</param>
        /// <returns>Returns an object that can be of type Aisle, Deck or DynamicWorkStation. Returns null if failed.</returns>
        private dynamic ConvertStringToArea(string area)
        {
            // Local variables
            int index;
            try
            {
                // Get index from area string
                index = int.Parse(FindDigitsInString(area).Value) - 1; // substract 1 from the index.
                if (area.ToLower().Contains("aisle"))
                {
                    return AisleList[index];
                }
                else if (area.ToLower().Contains("deck"))
                {
                    return DeckList[index];
                }
                else if (area.ToLower().Contains("dws"))
                {
                    return DwsList[index];
                }
                else
                {
                    MessageBox.Show(area + " not a valid area.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // TODO - delete after debugging
                MessageBox.Show("ConvertStringToArea exception " + ex.Message);
                return null;
            }
        }

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
            // Use else-if for each instruction category.
            // Use a switch-case for individual instructions in each category.
            bool executionIsSuccessful;
            string executionMessage;
            string[] results = new string[instructions.Length];
            string instruction;
            //Zoning intructions
            string[] instructionSplit = new string[MAX_INSTRUCTION_PARAMS];
            for(int i=0; i<instructions.Length; i++)
            {
                instruction = instructions[i];
                instructionSplit = instruction.Split(' ');
                executionIsSuccessful = false;
                if (instruction.Contains("Cell"))
                {
                    switch (instructionSplit[0])
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
                        case "CellConfirmPlcErrorStatus":
                            executionIsSuccessful = CellConfirmPlcErrorStatus(instructionSplit[1]);
                            break;
                        case "CellConfirmPlcWarningStatus":
                            executionIsSuccessful = CellConfirmPlcWarningStatus(instructionSplit[1]);
                            break;
                        case "CellConfirmPlcMode":
                            executionIsSuccessful = CellConfirmPlcMode(instructionSplit[1]);
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
                // For zoning instructions
                // Zoning instructinos syntax
                // "Function ZoneN Command"
                // E.g.: "ZoningConfirmStatus Aisle1 Waiting"
                else if (instruction.Contains("Zoning"))
                {
                    switch (instructionSplit[0])
                    {
                        case "ZoningSendCommand":
                            executionIsSuccessful = ZoningSendCommand(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ZoningConfirmStatus":
                            executionIsSuccessful = ZoningConfirmStatus(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ZoningRequestRoutine":
                            executionIsSuccessful = ZoningRequestRoutine(instructionSplit[1]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' instruction was not recognized.");
                            break;
                    }
                }
                else if (instruction.Contains("EstopBtnOperation"))
                {
                    executionIsSuccessful= EstopBtnOperation(instructionSplit[1], instructionSplit[2]);
                }
                else if (instruction.Contains("Stopper"))
                {
                    // TODO - add code
                }
                else if (instruction.Contains("Wait"))
                {
                    // Do nothing here.
                    // Use this instruction in case extra time is needed.
                    executionIsSuccessful = true;
                }
                else
                {
                    switch (instruction)
                    {
                        // TODO - delete case. Currently here for testing purposes.
                        case "DummyInstruction":
                            executionIsSuccessful = false;
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UNRECOGNIZED_INSTRUCTION);
                            // code block
                            break;
                    }
                }
                // Log execution results
                executionMessage = instruction 
                    + " - Execution " 
                    + (executionIsSuccessful ? "complete." : "failed.");
                ListBox_Log.Items.Add(executionMessage);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                results[i] = executionMessage;
                // Initialize stopwatch
                WaitForPlc = Stopwatch.StartNew();
                while (WaitForPlc.ElapsedMilliseconds < InstructionWaitTime)
                {
                    // Wait for the plc to do its thing.
                }
            }
            // Return a string with the results of the test run.
            return results;
        }

        #endregion // Test execution

        #endregion // Methods
    }
}
