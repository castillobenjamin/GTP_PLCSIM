using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
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
        // Alphabot System shortcut objects
        private readonly CoSimulation CoSimulationInstance;
        private CellCommunication Cell;
        private List<Stopper> Stoppers;
        private List<Aisle> AisleList;
        private List<Deck> DeckList;
        private List<DynamicWorkStation> DwsList;
        // Structures
        /// <summary>
        /// Containts a string array with each instruction's execution result.
        /// Contains a boolean variable to indicate if the test passed or failed.
        /// </summary>
        internal struct Test 
        {
            internal string[] Results { get; }
            internal bool Passed { get; }
            internal Test(string[] results, bool passed)
            {
                Results = results;
                Passed = passed;
            }
        }
        // Timers
        private System.Threading.Timer HeartBeatTimer;
        // Interval used for all timers
        readonly private int TimerInterval = 500;
        // Stop watch
        private Stopwatch stopWatch; // Used to wait after the execution of every instruction.
        private readonly int InstructionWaitTime = 250;
        private readonly int RequestWaitTime = 3000; // Zoning request wait time.
        private readonly int StopperMovingTime = 1500; //
        private readonly int StopperWaitTime = 500;
        // Output file name
        private string OutputFileName;
        // Constants
        private readonly uint MaxInstructionParams = 3;
        private readonly int MaxReadOutputTries = 10;
        // Error messages
        private readonly string AreaNotRecognized = "Could not recognize the specified area.";
        private readonly string UnhandledException = "An unhandled exception has occured.";
        private readonly string FormatException = "The format of one or more instruction parameters is incorrect.";
        private readonly string UnrecognizedInstruction = "Instruction was not recognized.";
        private readonly string StringToAreaConversion = "Unable to convert string to valid area.";
        private readonly string StopperActuationException = "An exception occured while actuating a stopper.";
        private readonly string StopperCloseException = "An exception occured while trying to close a stopper.";
        private readonly string StopperOpenException = "An exception occured while trying to open a stopper.";
        private readonly string StopperPositionUnknownToCell = "The position of the stopper is unknown.";
        private readonly string DWSRequestButtonPrompt = "Press the Request button on the HMI for specified DWS.";
        private readonly string TestPassedMessage = "All tests passed! Hooray!";
        private readonly string TestFailedMessage = "Test failed :( ";
        private readonly string SaveToFileSuccessMessage = "Test results saved in '";
        private readonly string SafeToFileFailedMessage = "Unable to save test results.";
        private readonly string TestFileNotSetMessage = " Please choose a test file.";
        #endregion // Fields

        #region Initialization
        public TestingInterface(CoSimulation coSimulationInstance)
        {
            InitializeComponent();
            CoSimulationInstance = coSimulationInstance;
            // Initialize instance shortcut variables
            Cell = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance;
            Stoppers = CoSimulationInstance.AlphaBotSystem.Stoppers;
            AisleList = CoSimulationInstance.AlphaBotSystem.Aisles;
            DeckList = CoSimulationInstance.AlphaBotSystem.Decks;
            DwsList = CoSimulationInstance.AlphaBotSystem.DynamicWorkStations;
        }
        #endregion // Initialization

        #region Methods

        #region Timers and Stopwatches
        /// <summary>
        /// Timer used to simulate CELL heart beat signal.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        class HeartBeatUpdater
        {
            private byte invokeCount;
            private byte maxCount;
            private CellCommunication cell;

            public HeartBeatUpdater(byte count, CellCommunication cell)
            {
                invokeCount = 0;
                maxCount = count;
                this.cell = cell;
            }

            // This method is called by the timer delegate.
            public void UpdateHeartBeat(Object stateInfo)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                // Simulate CELL pulse
                invokeCount++;
                cell.IsCellConnectedPulse.Value = invokeCount;
                if (invokeCount == maxCount)
                {
                    // Reset the counter and signal the waiting thread.
                    invokeCount = 0;
                    autoEvent.Set();
                }
            }
        }

        /// <summary>
        /// Wait for a set amount of time.
        /// </summary>
        /// <param name="waitTime">Time to wait (in milliseconds).</param>
        private void WaitForPlc(int waitTime)
        {
            stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < waitTime)
            {
                // Now we just have to wait.
            }
        }
        #endregion // Timers and Stopwatches

        #region FileName
        /// <summary>
        /// Set the output file name.
        /// </summary>
        /// <param name="programVersion"></param>
        /// <param name="testName"></param>
        /// <param name="testPassed"></param>
        /// <returns>String fileName</returns>
        private string SetFileName(string programVersion, string testName, bool testPassed)
        {
            string currDT = DateTime.Now.ToString("yyyy-MM-ddTHH'h'mm'm'ss's'");
            if (programVersion == string.Empty)
            {
                programVersion = "NoVersion";
            }
            if (testName == string.Empty)
            {
                testName = "NoTestName";
            }
            string fileName = programVersion + "_" + testName + "_" + currDT + "_"
                + (testPassed ? "Passed" : "Failed");
            return fileName;
        }
        #endregion // FileName

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
                // Initialize timers
                var autoEvent = new AutoResetEvent(false);
                var heartBeat = new HeartBeatUpdater(byte.MaxValue, Cell);
                HeartBeatTimer = new System.Threading.Timer(heartBeat.UpdateHeartBeat, autoEvent, TimerInterval, TimerInterval);
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
                HeartBeatTimer.Dispose();
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
                // TODO add code.
                return true;
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
                    MessageBox.Show(AreaNotRecognized + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(UnhandledException + " " + ex.Message);
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
                readSuccess = ReadOutput(areaZoning.ZoningStatus, expectedStatus, MaxReadOutputTries, InstructionWaitTime);
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
                    // TODO - update method call
                    return ZoningRequestRoutine(deck);
                }
                else if (parsedArea is DynamicWorkStation)
                {
                    dws = (DynamicWorkStation)parsedArea;
                    // TODO - update method call
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
        /// Executes zoning request routine for specified area.
        /// </summary>
        /// <param name="area">An Aisle, Deck or DWS.</param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ZoningRequestRoutine(dynamic area)
        {
            // TODO - add logs!!!!!!!!
            // TODO - add Miyano compatibility. This only works for Alpen currently.
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            byte zoningCommand = (byte)Utils.CellCommandValues.Permit;
            try
            {
                ListBox_Log.Items.Add(area.Name + " Zoning request routine started.");
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                if (area is Aisle || area is Deck)
                {
                    stepOk &= UpdateInput(area.OperationBox.RequestBtn, true); // Press request button
                    WaitForPlc(RequestWaitTime);
                    stepOk &= UpdateInput(area.OperationBox.RequestBtn, false); // Release request button after specified time
                    ListBox_Log.Items.Add(area.Name + " Request button pressed.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                    stepOk &= ZoningConfirmStatus(area.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                    stepOk &= StopperActuationRoutine(area.Name, "close"); // Close all stoppers for the specified area
                    stepOk &= ZoningSendCommand(area.Zoning, zoningCommand); // Send "Permit" command
                    WaitForPlc(RequestWaitTime);
                    stepOk &= ZoningConfirmStatus(area.Zoning, Utils.ZoningStatusBytes["Permit"]);
                    ListBox_Log.Items.Add(area.Name + " Permit status.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                // DWS is a special case. HMI input is required.
                if (area is DynamicWorkStation)
                {
                    MessageBox.Show(DWSRequestButtonPrompt, "User input required",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); // Prompt the user to press the request button
                    // Assume the user pressed the button and Requesting status is active
                    stepOk &= ZoningConfirmStatus(area.Zoning, Utils.ZoningStatusBytes["Requesting"]);
                    stepOk &= StopperActuationRoutine(area.Name, "close"); // Close all stoppers for the specified area
                    stepOk &= ZoningSendCommand(area.Zoning, zoningCommand); // Send "Permit" command
                    WaitForPlc(RequestWaitTime);
                    stepOk &= ZoningConfirmStatus(area.Zoning, Utils.ZoningStatusBytes["Permit"]);
                    ListBox_Log.Items.Add(area.Name + " Permit status.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
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
        #endregion // Zoning

        #region Zone Estop

        /// <summary>
        /// Send the "Estop processing completed" signal to the relevant area.
        /// </summary>
        /// <param name="area"></param>
        /// <param name="value">"true" or "false"</param>
        /// <returns>True if successful.</returns>
        private bool EstopSendCompletedSignal(string area, string value)
        {
            // Local variables
            dynamic parsedArea;
            bool parsedValue;
            try
            {
                // Get index from area string
                parsedArea = ConvertStringToArea(area);
                parsedValue = bool.Parse(value); // Try to parse string to bool
                if (parsedArea is Aisle || parsedArea is Deck || parsedArea is DynamicWorkStation)
                {
                    return EstopSendCompletedSignal(parsedArea.EmergencyStopZone, parsedValue);
                }
                else
                {
                    MessageBox.Show(AreaNotRecognized + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(UnhandledException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sends the input value to the corresponding EmergencyStop instance.
        /// </summary>
        /// <param name="eStop"></param>
        /// <param name="value"></param>
        /// <returns>True if successful.</returns>
        private bool EstopSendCompletedSignal(EmergencyStop eStop, bool value)
        {
            bool updateSuccess;
            try
            {
                updateSuccess = UpdateInput(eStop.CellIsCompleteFlag, value);
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
        /// Confirm the Estop request of the given area.
        /// </summary>
        /// <param name="area"></param>
        /// <param name="value"></param>
        /// <returns>True if successful.</returns>
        private bool EstopConfirmRequest(string area, string value)
        {
            // Local variables
            bool parsedValue;
            dynamic parsedArea;
            try
            {
                parsedValue = bool.Parse(value);
                parsedArea = ConvertStringToArea(area);
                if (parsedArea is Aisle || parsedArea is Deck || parsedArea is DynamicWorkStation)
                {
                    return EstopConfirmRequest(parsedArea.EmergencyStopZone, parsedValue);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// COnfirm Estop request of the given EmergencyStop instance.
        /// </summary>
        /// <param name="eStop"></param>
        /// <param name="value"></param>
        /// <returns>True if successful.</returns>
        private bool EstopConfirmRequest(EmergencyStop eStop, bool value)
        {
            bool updateSuccess;
            try
            {
                updateSuccess = ReadOutput(eStop.PlcStopRequest, value, MaxReadOutputTries, InstructionWaitTime);
                return updateSuccess;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Confirm the Estop status of the given area.
        /// </summary>
        /// <param name="area"></param>
        /// <param name="value"></param>
        /// <returns>True if successful.</returns>
        private bool EstopConfirmStatus(string area, string value)
        {
            // Local variables
            bool parsedValue;
            dynamic parsedArea;
            try
            {
                parsedValue = bool.Parse(value);
                parsedArea = ConvertStringToArea(area);
                if (parsedArea is Aisle || parsedArea is Deck || parsedArea is DynamicWorkStation)
                {
                    return EstopConfirmStatus(parsedArea.EmergencyStopZone, parsedValue);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Confirm the Estop status of the given EmergencyStop instance.
        /// </summary>
        /// <param name="eStop"></param>
        /// <param name="value"></param>
        /// <returns>True if successful.</returns>
        private bool EstopConfirmStatus(EmergencyStop eStop, bool value)
        {
            bool updateSuccess;
            try
            {
                updateSuccess = ReadOutput(eStop.PlcIsStopStatus, value, MaxReadOutputTries, InstructionWaitTime);
                return updateSuccess;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion // Zone Estop

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

        #region Signal tower
        /// <summary>
        /// Read the signal tower outputs
        /// </summary>
        /// <param name="color"></param>
        /// <param name="onOrOff">"On" or "Off"</param>
        private void ReadSignalTower(string color, string onOrOff)
        {
            // TODO - add code
        }
        #endregion // Signal tower
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
        private bool StopperActuationRoutine(string areaName, string action)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            try
            {
                ListBox_Log.Items.Add($"{areaName} Stopper actuation routine started.");
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                // Loop through stoppers
                Stoppers.ForEach(stopper =>
                {
                    // Check if the name of the current stopper includes the name of the current area.
                    // TODO - aisle1 also calls aisle 10! Fix.
                    if (stopper.Name.ToLower().Contains(areaName.ToLower()))
                    {
                        ListBox_Log.Items.Add($"Actuating {stopper.Name}");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        // Call the corresponding function depending on the "action" parameter
                        if (action.ToLower() == "close")
                        {
                            stepOk &= StopperClose(stopper);
                        }
                        else if (action.ToLower() == "open")
                        {
                            stepOk &= StopperOpen(stopper);
                        }
                        else
                        {
                            MessageBox.Show(FormatException + $"{stopper.Name}, {action}");
                        }
                    }
                });
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(StopperActuationException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Open or close specified stopper.
        /// </summary>
        /// <param name="stopperName">The stopper name as specified in XML configuration file.</param>
        /// <param name="action">"open" or "close"</param>
        /// <returns></returns>
        private bool ActuateStopper(string stopperName, string action)
        {
            bool stepOk = true;
            try
            {
                // Loop through stoppers
                Stoppers.ForEach(stopper =>
                {
                    // Check if the name of the current stopper is equal to the input string.
                    if (stopper.Name.ToLower() == stopperName.ToLower())
                    {
                        ListBox_Log.Items.Add($"Actuating {stopper.Name}");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        // Call the corresponding function depending on the "action" parameter
                        if (action.ToLower() == "close")
                        {
                            stepOk &= StopperClose(stopper);
                        }
                        else if (action.ToLower() == "open")
                        {
                            stepOk &= StopperOpen(stopper);
                        }
                        else
                        {
                            MessageBox.Show(FormatException + $"{stopper.Name}, {action}");
                        }
                    }
                });
                return stepOk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(StopperActuationException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Close a stopper.
        /// </summary>
        /// <param name="stopper">Stopper to be closed</param>
        /// <returns>True if succesful.</returns>
        private bool StopperClose(Stopper stopper)
        {
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            string stepMessage;
            try
            {
                // If the stopper is already closed, return true.
                if (ReadOutput(stopper.IsClosedStatusToCell, true, MaxReadOutputTries, InstructionWaitTime))
                {
                    stepOk = true;
                    ListBox_Log.Items.Add(stopper.Name + " is already closed.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                // Check if the stopper is open.
                else if (ReadOutput(stopper.IsOpenStatusToCell, true, MaxReadOutputTries, InstructionWaitTime))
                {
                    // TODO - remove wait
                    //WaitForPlc(StopperWaitTime);
                    stepOk &= UpdateInput(stopper.CloseCommandFromCell, true); // Send close command
                    stepMessage = stepOk ? " Close command sent." : " Fail to send close command.";
                    ListBox_Log.Items.Add(stopper.Name + stepMessage);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                    // TODO - remove wait and messagebox
                    WaitForPlc(StopperWaitTime);
                    WaitForPlc(StopperWaitTime);
                    // MessageBox.Show("Wait for PLC to turn on output.");
                    if (ReadOutput(stopper.PlcCloseOut, true, MaxReadOutputTries, InstructionWaitTime)) // Check if the close output is on
                    {
                        ListBox_Log.Items.Add(stopper.Name + " Close output on.");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        stepOk &= UpdateInput(stopper.IsOpenSensor, true); // turn off open sensor (inverted logic for Alpen)
                        // TODO - remove this wait time?
                        WaitForPlc(StopperMovingTime); // No harm in waiting... right?
                        stepOk &= UpdateInput(stopper.IsClosedSensor, false); // turn on closed sensor (inverted logic for Alpen)
                        // TODO - remove wait and messagebox
                        //WaitForPlc(StopperWaitTime);
                        stepOk &= ReadOutput(stopper.PlcCloseOut, false, MaxReadOutputTries, InstructionWaitTime); // Check close output is off
                        //WaitForPlc(StopperWaitTime);
                        // TODO - remove messagebox
                        //MessageBox.Show("Wait for PLC to send closed signal.");
                        stepOk &= ReadOutput(stopper.IsClosedStatusToCell, true, MaxReadOutputTries, InstructionWaitTime); // Read the closed status signal
                        stepOk &= UpdateInput(stopper.CloseCommandFromCell, false); // turn off close command
                        stepMessage = stepOk ? " is now closed." : " is not closed yet.";
                        ListBox_Log.Items.Add(stopper.Name + stepMessage);
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        // TODO - remove wait and messagebox
                        //WaitForPlc(StopperWaitTime);
                    }
                    else
                    {
                        ListBox_Log.Items.Add(stopper.Name + " Close output did not turn on.");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        stepOk &= false;
                    }
                }
                else // the status of the stopper is not being sent to the Modbus register
                {
                    MessageBox.Show(stopper.Name + " " + StopperPositionUnknownToCell);
                    stepOk = false;
                }
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(stopper.Name + " " + StopperCloseException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  Open a stopper.
        /// </summary>
        /// <param name="stopper">Stopper to be open</param>
        /// <returns>True if succesful.</returns>
        private bool StopperOpen(Stopper stopper)
        {
            // TODO - update logic according to stopper close method updates.
            bool stepOk = true; // Checks every step of the routine. If one steps fails, false.
            string stepMessage;
            try
            {
                // If the stopper is already open, return true.
                if (ReadOutput(stopper.IsOpenStatusToCell, true, MaxReadOutputTries, InstructionWaitTime))
                {
                    stepOk = true;
                    ListBox_Log.Items.Add(stopper.Name + " is already open.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                // Check if the stopper is closed.
                else if (ReadOutput(stopper.IsClosedStatusToCell, true, MaxReadOutputTries, InstructionWaitTime))
                {
                    // TODO - remove wait
                    //WaitForPlc(StopperWaitTime);
                    stepOk &= UpdateInput(stopper.OpenCommandFromCell, true); // Send open command
                    stepMessage = stepOk ? " Open command sent." : " Fail to send open command.";
                    ListBox_Log.Items.Add(stopper.Name + stepMessage);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                    // TODO - remove wait and messagebox
                    WaitForPlc(StopperWaitTime);
                    // MessageBox.Show("Wait for PLC to turn on output.");
                    if (ReadOutput(stopper.PlcOpenOut, true, MaxReadOutputTries, InstructionWaitTime)) // Check if the open output is on
                    {
                        ListBox_Log.Items.Add(stopper.Name + " Open output on.");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        stepOk &= UpdateInput(stopper.IsClosedSensor, true); // turn off closed sensor (inverted logic for Alpen)
                        // TODO - remove this wait time?
                        WaitForPlc(StopperMovingTime); // No harm in waiting... right?
                        stepOk &= UpdateInput(stopper.IsOpenSensor, false); // turn on open sensor (inverted logic for Alpen)
                        // TODO - remove wait and messagebox
                        //WaitForPlc(StopperWaitTime);
                        stepOk &= ReadOutput(stopper.PlcOpenOut, false, MaxReadOutputTries, InstructionWaitTime); // Check open output is off
                        //WaitForPlc(StopperWaitTime);
                        // TODO - remove messagebox
                        //MessageBox.Show("Wait for PLC to send closed signal.");
                        stepOk &= ReadOutput(stopper.IsOpenStatusToCell, true, MaxReadOutputTries, InstructionWaitTime); // Read the open status signal
                        stepOk &= UpdateInput(stopper.OpenCommandFromCell, false); // turn off open command
                        stepMessage = stepOk ? " is now open." : " is not open yet.";
                        ListBox_Log.Items.Add(stopper.Name + stepMessage);
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        // TODO - remove wait and messagebox
                        //WaitForPlc(StopperWaitTime);
                    }
                    else
                    {
                        ListBox_Log.Items.Add(stopper.Name + " Close output did not turn on.");
                        ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                        stepOk &= false;
                    }
                }
                else // the status of the stopper is not being sent to the Modbus register
                {
                    MessageBox.Show(stopper.Name + " " + StopperPositionUnknownToCell);
                    stepOk = false;
                }
                return stepOk;
            }
            catch (Exception ex)
            {
                // TODO - delete message box
                MessageBox.Show(stopper.Name + " " + StopperOpenException + " " + ex.Message);
                return false;
            }
        }

        #endregion // Stoppers

        #region Evacuation rails

        #endregion // Evacuation rails

        #region Fire shutter

        #endregion // Fire shutter

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

        #region Read output
        // TODO - Make these methods asynchronous!
        // TODO - Use multiple threads?
        /// <summary>
        /// Checks the output signal value.
        /// If the output value is not equal to expectedValue after trying nOfTries, returns false.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="expectedValue"></param>
        /// <param name="nOfTries">Maximum number of tries to read the output value</param>
        /// <param name="waitTime">Time to wait between read attempts</param>
        /// <returns>True if the output had the expected value. False if the value is different or the method fails.</returns>
        private bool ReadOutput(PlcOutput output, bool expectedValue, int nOfTries, int waitTime)
        {
            try
            {
                for (int i = 0; i < nOfTries; i++)
                {
                    if (output.Value == expectedValue) return true;
                    WaitForPlc(waitTime); // wait for PLC to update
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the value of a single bit in a register.
        /// If the output value is not equal to expectedValue after trying nOfTries, returns false.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="expectedValue"></param>
        /// <param name="nOfTries">Maximum number of tries to read the output value</param>
        /// <param name="waitTime">Time to wait between read attempts</param>
        /// <returns>True if the output had the expected value. False if the value is different or the method fails.</returns>
        private bool ReadOutput(RegisterFromPlc register, bool expectedValue, int nOfTries, int waitTime)
        {
            try
            {
                for (int i = 0; i < nOfTries; i++)
                {
                    if (Utils.ReadRegisterBit(register) == expectedValue) return true;
                    WaitForPlc(waitTime); // wait for PLC to update
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the value of a byte in a register.
        /// If the output value is not equal to expectedValue after trying nOfTries, returns false.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="expectedValue"></param>
        /// <param name="nOfTries">Maximum number of tries to read the output value</param>
        /// <param name="waitTime">Time to wait between read attempts</param>
        /// <returns>True if the output had the expected value. False if the value is different or the method fails.</returns>
        private bool ReadOutput(RegisterFromPlc register, byte expectedValue, int nOfTries, int waitTime)
        {
            try
            {
                for (int i = 0; i < nOfTries; i++)
                {
                    if (Utils.GetLowerByte(register.Value) == expectedValue) return true;
                    WaitForPlc(waitTime); // wait for PLC to update
                }
                return false;
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
        /// <param name="action">"Press" and "Release"</param>
        /// <returns>True if routine is executed successfully.</returns>
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
                /*
                 * NOTE:
                 * When the Estop is pressed, the PLC input is false.
                 */
                if (action == "Release") { parsedAction = true; }
                else if (action == "Press") { parsedAction = false; }
                else
                {
                    MessageBox.Show(FormatException + "Only 'Press' and 'Release' are accepted.");
                    return false;
                }
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
                    MessageBox.Show(AreaNotRecognized + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(FormatException + " " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(UnhandledException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Press/Release the Reset button of the specified zone.
        /// </summary>
        /// <param name="area">String of format "Zone#". E.g.: "Aisle2", "Deck4", etc.</param>
        /// <param name="action">"Press" and "Release"</param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool ResetBtnOperation(string area, string action)
        {
            // Local variables
            object parsedArea;
            bool parsedAction;
            Aisle aisle;
            Deck deck;
            try
            {
                parsedArea = ConvertStringToArea(area);
                if (action == "Release") { parsedAction = false; }
                else if (action == "Press") { parsedAction = true; }
                else
                {
                    MessageBox.Show(FormatException + "Only 'Press' and 'Release' are accepted.");
                    return false;
                }
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return UpdateInput(aisle.OperationBox.ResetBtn, parsedAction);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return UpdateInput(deck.OperationBox.ResetBtn, parsedAction);
                }
                // No reset btn on DWS
                else
                {
                    MessageBox.Show(AreaNotRecognized + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(FormatException + " " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(UnhandledException + " " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Press/Release the Request button of the specified zone.
        /// </summary>
        /// <param name="area">String of format "Zone#". E.g.: "Aisle2", "Deck4", etc.</param>
        /// <param name="action">"Press" and "Release"</param>
        /// <returns>True if routine is executed successfully.</returns>
        private bool RequestBtnOperation(string area, string action)
        {
            // Local variables
            object parsedArea;
            bool parsedAction;
            Aisle aisle;
            Deck deck;
            try
            {
                parsedArea = ConvertStringToArea(area);
                if (action == "Release") { parsedAction = false; }
                else if (action == "Press") { parsedAction = true; }
                else
                {
                    MessageBox.Show(FormatException + "Only 'Press' and 'Release' are accepted.");
                    return false;
                }
                if (parsedArea is Aisle)
                {
                    aisle = (Aisle)parsedArea;
                    return UpdateInput(aisle.OperationBox.RequestBtn, parsedAction);
                }
                else if (parsedArea is Deck)
                {
                    deck = (Deck)parsedArea;
                    return UpdateInput(deck.OperationBox.RequestBtn, parsedAction);
                }
                // No reset btn on DWS
                else
                {
                    MessageBox.Show(AreaNotRecognized + " " + parsedArea.GetType().ToString());
                    return false;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(FormatException + " " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(UnhandledException + " " + ex.Message);
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
            Regex regex = new Regex(@"\d+"); // match a digit one or more times.
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
                    MessageBox.Show(AreaNotRecognized + " " + area);
                    return null;
                }
            }
            catch (Exception ex)
            {
                // TODO - delete after debugging
                MessageBox.Show(StringToAreaConversion + " " + ex.Message);
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
            //string[] testResults;
            //bool testPassed;
            bool outputOk;
            Test testResults;
            //Read file with test instructions
            try
            {
                // Get test instructions
                instructions = Utils.ConvertTextFile2List(TextBox_TestFilePath.Text);
                // Execute test instructions
                testResults = ExecuteTestInstructions(instructions);
                if (testResults.Passed)
                {
                    ListBox_Log.Items.Add(TestPassedMessage);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    ListBox_Log.Items.Add(TestFailedMessage);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                // TODO - output test results to a file.
                OutputFileName = SetFileName(
                    TextBox_ProgramVersion.Text, TextBox_TestName.Text, testResults.Passed);
                outputOk = Utils.ConvertList2File(testResults.Results, OutputFileName);
                if (outputOk)
                {
                    MessageBox.Show(SaveToFileSuccessMessage + OutputFileName + "'");
                }
                else
                {
                    MessageBox.Show(SafeToFileFailedMessage);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + TestFileNotSetMessage);
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
        /// <returns>Test structure</returns>
        private Test ExecuteTestInstructions(string[] instructions)
        {
            // TODO - Add a case for every possible instruction
            bool testPassed = true; // Check if test execution is successful
            bool instructionPassed; // check if each instruction execution is successful
            string executionMessage;
            string[] results = new string[instructions.Length];
            string instruction;
            //Zoning intructions
            string[] instructionSplit = new string[MaxInstructionParams];
            for(int i=0; i<instructions.Length; i++)
            {
                instruction = instructions[i];
                instructionSplit = instruction.Split(' ');
                instructionPassed = false;
                if (instruction.Contains("Cell"))
                {
                    switch (instructionSplit[0])
                    {
                        case "CellTurnOn":
                            instructionPassed = CellTurnOn();
                            break;
                        case "CellStart":
                            instructionPassed = CellStart();
                            break;
                        case "CellTurnOff":
                            instructionPassed = CellTurnOff();
                            break;
                        case "CellStop":
                            instructionPassed = CellStop();
                            break;
                        case "CellConfirmPlcErrorStatus":
                            instructionPassed = CellConfirmPlcErrorStatus(instructionSplit[1]);
                            break;
                        case "CellConfirmPlcWarningStatus":
                            instructionPassed = CellConfirmPlcWarningStatus(instructionSplit[1]);
                            break;
                        case "CellConfirmPlcMode":
                            instructionPassed = CellConfirmPlcMode(instructionSplit[1]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            // code block
                            break;
                    }
                }
                else if (instruction.Contains("DwsPanel"))
                {
                    switch (instruction)
                    {
                        case "DwsPanelResetPress":
                            instructionPassed = DwsPanelResetPress();
                            break;
                        case "DwsPanelResetRelease":
                            instructionPassed = DwsPanelResetRelease();
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
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
                            instructionPassed = ZoningSendCommand(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ZoningConfirmStatus":
                            instructionPassed = ZoningConfirmStatus(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ZoningRequestRoutine":
                            instructionPassed = ZoningRequestRoutine(instructionSplit[1]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            break;
                    }
                }
                else if (instruction.Contains("Btn"))
                {
                    switch(instructionSplit[0])
                    {
                        case "EstopBtnOperation":
                            instructionPassed = EstopBtnOperation(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ResetBtnOperation":
                            instructionPassed = ResetBtnOperation(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "RequestBtnOperation":
                            instructionPassed = RequestBtnOperation(instructionSplit[1], instructionSplit[2]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            break;
                    }
                }
                else if (instruction.Contains("Estop")) // NOTE - This else if has to be after the "Btn" else if
                {
                    switch(instructionSplit[0])
                    {
                        case "EstopSendCompletedSignal":
                            instructionPassed = EstopSendCompletedSignal(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "EstopConfirmRequest":
                            instructionPassed = EstopConfirmRequest(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "EstopConfirmStatus":
                            instructionPassed = EstopConfirmStatus(instructionSplit[1], instructionSplit[2]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            break;
                    }
                }
                else if (instruction.Contains("Stopper"))
                {
                    switch(instructionSplit[0])
                    {
                        case "StopperActuationRoutine":
                            instructionPassed = StopperActuationRoutine(instructionSplit[1], instructionSplit[2]);
                            break;
                        case "ActuateStopper":
                            instructionPassed = ActuateStopper(instructionSplit[1], instructionSplit[2]);
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            // code block
                            break;
                    }
                }
                else if (instruction.Contains("Wait"))
                {
                    // Do nothing here.
                    // Use this instruction in case extra time is needed (Requesting).
                    instructionPassed = true;
                }
                else if (instruction.Contains("Pause"))
                {
                    MessageBox.Show("Test paused. Press 'OK' to continue.", "Pause", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    instructionPassed = true;
                }
                else
                {
                    // TODO - delete messagebox (used for debugging).
                    MessageBox.Show("Inside else, this instruction slipped out of all the ifs!" + instructionSplit[0]);
                    switch (instruction)
                    {
                        // TODO - delete case. Currently here for testing purposes.
                        case "DummyInstruction":
                            instructionPassed = false;
                            break;
                        default:
                            ListBox_Log.Items.Add("'" + instruction + "' " + UnrecognizedInstruction);
                            // code block
                            break;
                    }
                }
                // Log execution results
                testPassed &= instructionPassed;
                executionMessage = instruction 
                    + " - Execution " 
                    + (instructionPassed ? "complete." : "failed.");
                ListBox_Log.Items.Add(executionMessage);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                results[i] = executionMessage;
                // Wait after each instruction has been procesed.
                WaitForPlc(InstructionWaitTime);
            }
            // Return a "Test" structure with the results
            Test testResults = new Test(results, testPassed);
            return testResults;
        }

        #endregion // Test execution

        #endregion // Methods
    }
}
