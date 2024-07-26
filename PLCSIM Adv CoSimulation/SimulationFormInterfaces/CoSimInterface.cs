using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

//TODOLIST
//TODO - use the [XmlElement(ElementName = "fields")] pattern.
//This way the name of the xml attribute and the class properties does not have to match.
//TODO - try to separate the control methods from the input logic? In case the interface changes?
//TODO - use refs and whatnot instead of passing copies of parameters.
//TODO - Think of a way to merge the RadioButton_[XXX]_CheckedChanged methods.
//TODO - check that the XML file / Modbus registers / Classes match.
//TODO - make maintenance area only visible when the Aisle 1 is displayed.
//       need to somehow connect the operation of the key switch radio buttons. (when maintenance mode is selected, deselect the "Ready" radio button
//       Also, restrict the operation so it can only be done in the intended order. (request →　ready　→ maintenance)
//       still need to ucheck the "maint" radio button when one of the other options is selected.
//TODO - make the maintenance stopper part of the list of all stoppers????
//TODO - implement missing Panel inputs (button lamps, earth faults, buzzer, voltageOn, spikeAlarm, etc).
//TODO - add missing cell communication methods.
//TODO - buzzer and signal tower logic.

/* 
 ** Changes and remarks concerning updates for Demoline v2

 * Door input.
 * The Open/Close radio buttons are not the direct input of the PLC.
 * The PLC input signals when the "door is locked". 
 * It is true only when the physical door is closed and the digital lock is active 
 * (i.e. the PLC "unlock door" output is false)
 * The radio buttons are meant to signal the physical door being open/closed.
 
 */

namespace PLCSIM_Adv_CoSimulation
{
    public partial class CoSimInterface : Form
    {
        #region Fields
        private readonly CoSimulation CoSimulationInstance;
        private Aisle currentAisle;
        private Deck currentDeck;
        //private DynamicWorkStation currentDws;
        private TowerDynamicWorkStation currentTowerDws;
        private SmallAisle currentSmallAisle;
        private Stopper currentStopper;
        private FirePreventionShutter currentShutter;
        // flag for "CELL only" simulation
        private readonly bool isCellOnlySim = false;
        // TODO - Iterate with timer for optimal value
        readonly private int timerInterval = 200;
        // The timer is public so that the main interface can stop it when the simulation is stopped.
        public Timer IOUpdateTimer = new Timer();
        // Counter to simulate the CELL pulse.
        private byte HeartBeatCounter = 0;
        /// <summary>
        /// Signals used to simulate the behaviour of the stopper sensors
        /// </summary>
        private bool StopperOpenSensorSignal = false;
        private bool StopperCloseSensorSignal = false;
        private bool StopperOpenOutputIsOn = false;
        private bool StopperCloseOutputIsOn = false;
        private Timer stopperTimer = new Timer();
        private int stopperActuationWaitTime = 2000;
        /// <summary>
        /// Signals used to simulate the behaviour of the fire shutter sensors
        /// </summary>
        // NOTE - Currently unused
        private bool ShutterOpenSensorSignal = false;
        private bool ShutterCloseSensorSignal = false;
        private bool ShutterOpenOutputIsOn = false;
        private bool ShutterCloseOutputIsOn = false;
        private Timer shutterTimer = new Timer();
        private int shutterActuationWaitTime = 1500;

        //Label config
        readonly Font activeLabelFont = 
            new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Bold);
        readonly Font inactiveLabelFont = 
            new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Strikeout);
        readonly Font errorLabelFont = 
            new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Underline);
        readonly Font emergencyLabelFont = 
            new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Bold);
        readonly Color activeLabelColor = Color.Green;
        readonly Color inactiveLabelColor = Color.Gray;
        readonly Color errorLabelColor = Color.Red;
        readonly Color emergencyLabelColor = Color.Orange;

        #endregion // Fields

        #region Initialization
        public CoSimInterface(CoSimulation coSimulationInstance, bool isCellOnlySim)
        {
            InitializeComponent();
            // Assign local private Cosimulation instance to the one passed from the main interface
            CoSimulationInstance = coSimulationInstance;
            // Populate ComboBox info
            InitializeComboBoxes();
            // Initialize private fields
            InitializeFields();
            // Initialize timer
            IOUpdateTimer.Tick += new EventHandler(TimerEventProcessor);
            IOUpdateTimer.Interval = timerInterval;
            IOUpdateTimer.Start();
            //Hide unnecessary controls
            // This method has to be CALLED AFTER InitializeFields().
            HideControls(isCellOnlySim);
            // Set initial state for interface controls
            // Initial control values are read from the XML file
            InitializeControls();
            // Assign local field
            this.isCellOnlySim = isCellOnlySim;

            // Display maintenance area controls
            DisplayMaintenanceArea();

            //Initialization complete log
            ListBox_Log.Items.Add("Showing IO interface for " + coSimulationInstance.AlphaBotSystem.Name);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        public void InitializeComboBoxes()
        {
            //Aisles
            CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(x =>
            {
                ComboBox_Aisles.Items.Add(x.Label);
            });
            // Set displayed item
            ComboBox_Aisles.SelectedIndex = 0;
            
            // Decks
            CoSimulationInstance.AlphaBotSystem.Decks.ForEach(x =>
            {
                ComboBox_Decks.Items.Add(x.Label);
            });
            ComboBox_Decks.SelectedIndex = 0;
            
            // Tower DWS
            CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(x =>
            {
                ComboBox_TowerDWS.Items.Add(x.Label);
            });
            ComboBox_TowerDWS.SelectedIndex = 0;
            
            // Small Aisle
            CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach((x) =>
            {
                ComboBox_SmallAisle.Items.Add(x.Label);
            });
            ComboBox_SmallAisle.SelectedIndex = 0;
            
            // Stoppers
            CoSimulationInstance.AlphaBotSystem.Stoppers.ForEach(x =>
            {
                ComboBox_Stoppers.Items.Add(x.Label);
            });
            ComboBox_Stoppers.SelectedIndex = 0;

            //Bots
            CoSimulationInstance.AlphaBotSystem.Stoppers.ForEach(x =>
            {
                ComboBox_Stoppers.Items.Add(x.Label);
            });
        }
        private void InitializeControls()
        {
            // Set text boxes as read only
            TextBox_ZoningStatus_Aisle.ReadOnly = true;
            TextBox_ZoningStatus_Deck.ReadOnly = true;
            TextBox_ZoningStatus_TDWS.ReadOnly = true;
            TextBox_ZoningStatus_SmallAisle.ReadOnly = true;
        }
        private void InitializeFields()
        {
            currentAisle = CoSimulationInstance.AlphaBotSystem.Aisles[ComboBox_Aisles.SelectedIndex];
            currentDeck = CoSimulationInstance.AlphaBotSystem.Decks[ComboBox_Decks.SelectedIndex];
            currentTowerDws = 
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations[
                    ComboBox_TowerDWS.SelectedIndex];
            currentSmallAisle = 
                CoSimulationInstance.AlphaBotSystem.SmallAisles[
                    ComboBox_SmallAisle.SelectedIndex];
            currentStopper = 
                CoSimulationInstance.AlphaBotSystem.Stoppers[
                    ComboBox_Stoppers.SelectedIndex];
            if (CoSimulationInstance.AlphaBotSystem.MaintAreaSpecified)
            {
                InitializeMaintArea();
            }
        }
        private void InitializeMaintArea()
        {
            // TODO: Add new initialization for maintenance area.
        }
        /// <summary>
        /// Hides controls that are not used for the current configuration
        /// </summary>
        private void HideControls(bool isCellOnlySim)
        {
            // Hide evacuation/maintenance area controls
            if (!CoSimulationInstance.AlphaBotSystem.MaintAreaSpecified)
            {
                GroupBox_MaintArea.Hide();
            }
            // Hide IO controls when "CELL Only" option is checked
            if (isCellOnlySim)
            {
                // Aisle
                GroupBox_OpBox_Aisle.Hide();
                GroupBox_Door_Aisle.Hide();
                GroupBox_SafetyBoard_Aisle.Hide();
                Label_ContactorPlcOut_AisleNorth.Hide();
                Label_ContactorFdbk_AisleNorth.Hide();
                CheckBox_ContactorFdbk_AisleNorth.Hide();
                Label_ContactorPlcOut_AisleSouth.Hide();
                Label_ContactorFdbk_AisleSouth.Hide();
                CheckBox_ContactorFdbk_AisleSouth.Hide();
                // Deck
                GroupBox_OpBox_Deck.Hide();
                GroupBox_Door_Deck.Hide();
                // Tower DWS
                GroupBox_OpBox_TDWS.Hide();
                GroupBox_Door_TDWS.Hide();
                // TODO add safety boards.
                // Small Aisle
                GroupBox_OpBox_SmallAisle.Hide();
                Label_ContactorPlcOut_SmallAisle.Hide();
                Label_ContactorFdbk_SmallAisle.Hide();
                CheckBox_ContactorFdbk_SmallAisle.Hide();
                // Other areas
                GroupBox_Panels.Hide();
                GroupBox_Sensor_Stopper.Hide();
                GroupBox_Q_Stopper.Hide();
                Label_ContactorPlcOut_MaintArea.Hide();
                Label_ContactorFdbk_MaintArea.Hide();
                CheckBox_ContactorFdbk_MaintArea.Hide();
            }
        }
        #endregion // Initialization

        #region Destructor
        ~CoSimInterface()
        {
            // Stop timer when interface is closed.
            IOUpdateTimer.Stop();
            stopperTimer.Stop();
            shutterTimer.Stop();
        }
        #endregion // Destructor

        #region Timer
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            IOUpdateTimer.Stop();
            // Restarts the timer.
            IOUpdateTimer.Enabled = true;
            // Console.WriteLine("Update Output.");
            // Update outputs
            UpdateCurrentPlcOutputs();
            // Simulate CELL pulse
            if (CheckBox_IsCellConnectedPulse.Checked)
            {
                HeartBeatCounter = Utils.CountByteUp(HeartBeatCounter);
                CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse.Value = 
                    HeartBeatCounter;
            }
        }
        #endregion // Timer

        #region System Outputs
        /// <summary>
        /// updates the PC outputs for the current interface config
        /// </summary>
        public void UpdateCurrentPlcOutputs()
        {
            // TODO - the application still crashes when updates are being downloaded from TIA Portal. FIX
            //Check if the PLC is in RUN mode to prevent errors when trying to read Outputs
            if (MainInterface.PlcInstance.GetOperatingState().Equals("Run") || isCellOnlySim)
            {
                UpdateAisleOutputs();
                UpdateDeckOutputs();
                //UpdateDwsOutputs();
                UpdateTowerDwsOutputs();
                UpdateSmallAisleOutputs();
                UpdateStopperOutputs();
                //TODO - uncomment this line once the maintenance area IO tags are added to the configuration file.
                //UpdateMaintAreaOutputs();
                // Unique controls
                Update_Label_CELLcomm_PlcStatus();
                Update_ColorLabel_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel);
                Update_Label_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.NorthPanel, 
                    Label_LedTower_NorthPanel);
                Update_Label_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.SouthPanel, 
                    Label_LedTower_SouthPanel);
                // Currently unhandled IO
                UpdateUnhandledIO();
            }
        }
        #endregion // System Outputs

        #region Aisle

        /// <summary>
        /// Updates the interface with the values of the current Aisle.
        /// Toggle buttons' status is saved.
        /// Push buttons' status is not saved.
        /// All else is saved
        /// </summary>
        private void UpdateAisleInterface()
        {
            #region Inputs
            // Estop button
            // Checkbox value = NOT(Emergency btn value)
            CheckBox_EstopBtn_Aisle.Checked = !currentAisle.OperationBox.EmergencyBtn.Value;

            // Zoning
            // TODO delete the commented code once the new implementation is tested.
            /* TO BE DELETED
            switch (currentAisle.Zoning.CellCommand.Value)
            {
                case (byte)Utils.CellCommandValues.None:
                    RadioButton_None_Aisle.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Run:
                    RadioButton_Run_Aisle.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Permit:
                    RadioButton_Permit_Aisle.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Cancel:
                    RadioButton_Cancel_Aisle.Checked = true;
                    break;
                default:
                    Console.WriteLine("The zoning command for Aisle was not recognized.");
                    break;
            }
            */
            updateZoningRadioButtons(currentAisle, ref RadioButton_None_Aisle, 
                ref RadioButton_Run_Aisle, ref RadioButton_Permit_Aisle, ref RadioButton_Cancel_Aisle);

            // Key switch
            RadioButton_Req_Aisle.Checked = currentAisle.OperationBox.KeySwitch.Req.Value;
            RadioButton_Ready_Aisle.Checked = currentAisle.OperationBox.KeySwitch.Ready.Value;

            // Door
            // Note: The isDoorClose is not a PLC input,
            // it is a boolean property used as an intermediary signal.
            RadioButton_DoorClosed_Aisle.Checked = currentAisle.Door.IsDoorClosed;
            RadioButton_DoorOpen_Aisle.Checked = !currentAisle.Door.IsDoorClosed;

            // Emergency stop
            // bool flag = currentAisle.EmergencyStopZone.CellIsCompleteFlag.Value == (byte)BooleanSignal.True;
            bool flag = Utils.ReadRegisterBit(currentAisle.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_ReqCompleteFlag_Aisle.Checked = flag;

            // Safety boards
            CheckBox_SafetyBoard_AisleNorth.Checked = currentAisle.SafetyBoards[0].Value;
            CheckBox_SafetyBoard_AisleSouth.Checked = currentAisle.SafetyBoards[1].Value;

            // Contactors
            // flagOnOff = currentAisle.Contactors[1].ContactorOnOffCommand.Value == (byte)BooleanSignal.True;
            bool flagOnOff = Utils.ReadRegisterBit(currentAisle.Contactors[0].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_AisleNorth.Checked = flagOnOff;
            flagOnOff = Utils.ReadRegisterBit(currentAisle.Contactors[1].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_AisleSouth.Checked = flagOnOff;
            CheckBox_ContactorFdbk_AisleNorth.Checked = currentAisle.Contactors[0].Feedback.Value;
            CheckBox_ContactorFdbk_AisleSouth.Checked = currentAisle.Contactors[1].Feedback.Value;

            #endregion // Inputs

            #region Outputs
            // Update outputs
            UpdateAisleOutputs();
            #endregion// Outputs

            // Log
            ListBox_Log.Items.Add("Interface updated. Now displaying " + currentAisle.Label + " data.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #region Input
        private void ComboBox_Aisles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Aisles List.
            currentAisle = CoSimulationInstance.AlphaBotSystem.Aisles[ComboBox_Aisles.SelectedIndex];
            // When the selected aisle changes, update aisle interface with the new aisle data
            UpdateAisleInterface();
            // Display maintenance area when the corresponding aisle is displayed
            DisplayMaintenanceArea();
        }

        private void CheckBox_AllAisles_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
                CheckBox_AllAisles.ForeColor = Color.Red;
            else
                CheckBox_AllAisles.ForeColor = Color.Black;
        }

        #region Opbox
        private void CheckBox_EstopBtn_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                currentAisle.OperationBox.EmergencyBtn,
                CheckBox_EstopBtn_Aisle,
                currentAisle.Label);
        }

        #region Reset btn
        private void Btn_Reset_Aisle_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.ResetBtn,
                true,
                currentAisle.Label + " Reset");
        }
        private void Btn_Reset_Aisle_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.ResetBtn,
                false,
                currentAisle.Label + " Reset");
        }
        #endregion // Reset btn

        #region Run btn
        private void Btn_Run_Aisle_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.RunBtn,
                true,
                currentAisle.Label + " run");
        }

        private void Btn_Run_Aisle_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.RunBtn,
                false,
                currentAisle.Label + " run");
        }
        #endregion // Run btn

        #region Key switch
        private void RadioButton_Ready_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_Aisle.Checked;
                });
                string isReady = RadioButton_Ready_Aisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All Aisles " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_Aisle.Checked;
                string isReady = RadioButton_Ready_Aisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentAisle.Label + " " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_Req_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.OperationBox.KeySwitch.Req.Value = RadioButton_Req_Aisle.Checked;
                });
                string isReq = RadioButton_Req_Aisle.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add("All Aisle Doors are " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.OperationBox.KeySwitch.Req.Value = RadioButton_Req_Aisle.Checked;
                string isReq = RadioButton_Req_Aisle.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add(currentAisle.Label + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // key switch

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_Aisle.Checked)
            {
                if (CheckBox_AllAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                        aisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None;
                    // Log
                    ListBox_Log.Items.Add(currentAisle.Label + " None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Permit_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Permit_Aisle.Checked)
            {
                if (CheckBox_AllAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                        aisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit;
                    // Log
                    ListBox_Log.Items.Add(currentAisle.Label + " Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Run_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Run_Aisle.Checked)
            {
                if (CheckBox_AllAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                        aisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run;
                    // Log
                    ListBox_Log.Items.Add(currentAisle.Label + " Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Cancel_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cancel_Aisle.Checked)
            {
                if (CheckBox_AllAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                        aisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel;
                    // Log
                    ListBox_Log.Items.Add(currentAisle.Label + " Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Zoning

        #region Door
        private void RadioButton_DoorClosed_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.Door.IsDoorClosed = RadioButton_DoorClosed_Aisle.Checked;
                });
                string isClosed = RadioButton_DoorClosed_Aisle.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add("All Aisle Doors are " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                //The door sensor is Normally Closed, ie True when closed.
                currentAisle.Door.IsDoorClosed = RadioButton_DoorClosed_Aisle.Checked;
                string isClosed = RadioButton_DoorClosed_Aisle.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add(currentAisle.Label + " Door is " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_DoorOpen_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            // Nothing to do here. Assume this radio button only changes when the DoorClosed changes.
        }
        #endregion // Door

        #region Emergency stop
        private void CheckBox_ReqCompleteFlag_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            // Write byte
            RegisterToPlc currentRegister = currentAisle.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ReqCompleteFlag_Aisle.Checked);
            // Log action
            string isComplete = CheckBox_ReqCompleteFlag_Aisle.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentAisle.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #region SafetyBoards
        private void CheckBox_SafetyBoard_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            // The safety board sensor is True for normal operation
            // Assume Northern safety board has index 0 and Southern safety board has index 1.
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.SafetyBoards[0].Value = CheckBox_SafetyBoard_AisleNorth.Checked;
                });
                // Log action
                string isOn = CheckBox_SafetyBoard_AisleNorth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("All North safety boards " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.SafetyBoards[0].Value = CheckBox_SafetyBoard_AisleNorth.Checked;
                // Log action
                string isOn = CheckBox_SafetyBoard_AisleNorth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add(currentAisle.Label + " North safety board " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void CheckBox_SafetyBoard_AisleSouth_CheckedChanged(object sender, EventArgs e)
        {
            // The safety board sensor is True for normal operation
            // Assume Northern safety board has index 0 and Southern safety board has index 1.
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.SafetyBoards[1].Value = CheckBox_SafetyBoard_AisleSouth.Checked;
                });
                // Log action
                string isOn = CheckBox_SafetyBoard_AisleSouth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("All South safety boards " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.SafetyBoards[1].Value = CheckBox_SafetyBoard_AisleSouth.Checked;
                // Log action
                string isOn = CheckBox_SafetyBoard_AisleSouth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add(currentAisle.Label + " South safety board " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // safety boards

        #region Contactors
        private void CheckBox_ContactorOnOff_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            // Assume Northern contactor has index 0 and Southern contactor has index 1.
            RegisterToPlc currentRegister = currentAisle.Contactors[0].ContactorOnOffCommand;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ContactorOnOff_AisleNorth.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_AisleNorth.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentAisle.Label + " North contactor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorOnOff_AisleSouth_CheckedChanged(object sender, EventArgs e)
        {
            // Assume Northern contactor has index 0 and Southern contactor has index 1.
            RegisterToPlc currentRegister = currentAisle.Contactors[1].ContactorOnOffCommand;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ContactorOnOff_AisleSouth.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_AisleSouth.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentAisle.Label + " South contactor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorFdbk_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            currentAisle.Contactors[0].Feedback.Value = CheckBox_ContactorFdbk_AisleNorth.Checked;
            if (CheckBox_ContactorFdbk_AisleNorth.Checked)
            {
                Label_ContactorFdbk_AisleNorth.ForeColor = activeLabelColor;
                Label_ContactorFdbk_AisleNorth.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorFdbk_AisleNorth.ForeColor = inactiveLabelColor;
                Label_ContactorFdbk_AisleNorth.Font = inactiveLabelFont;
            }
        }

        private void CheckBox_ContactorFdbk_AisleSouth_CheckedChanged(object sender, EventArgs e)
        {
            currentAisle.Contactors[1].Feedback.Value = CheckBox_ContactorFdbk_AisleSouth.Checked;
            if (CheckBox_ContactorFdbk_AisleSouth.Checked)
            {
                Label_ContactorFdbk_AisleSouth.ForeColor = activeLabelColor;
                Label_ContactorFdbk_AisleSouth.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorFdbk_AisleSouth.ForeColor = inactiveLabelColor;
                Label_ContactorFdbk_AisleSouth.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactors

        #endregion // Input

        #region Output
        private void UpdateAisleOutputs()
        {
            Update_Label_OpBoxLed_Aisle();
            Update_TextBox_ZoningStatus_Aisle();
            Update_Label_PlcStopRequest_Aisle();
            Update_Label_PlcIsStopStatus_Aisle();
            Update_Label_SafetyBoard_AisleNorth();
            Update_Label_SafetyBoard_AisleSouth();
            Update_Label_ContactorPlcOut_AisleNorth();
            Update_Label_ContactorPlcOut_AisleSouth();
            // TODO - delete unused methods after testing.
            //Update_Label_DoorIsLocked_Aisle();
            //Update_Label_UnlockDoor_Aisle();
            //Use these methods instead of the XX_Aisle() ones;
            Update_Label_DoorIsLocked(currentAisle, Label_DoorIsLocked_Aisle);
            Update_Label_UnlockDoor(currentAisle, Label_UnlockDoor_Aisle);
            UpdateAllAisleContactorOutputs();
        }
        private void Update_Label_OpBoxLed_Aisle()
        {
            string ledStatus;
            // Read Plc output
            if (currentAisle.OperationBox.ZoningStatusLed.Value)
            {
                Label_OpBoxLed_Aisle.ForeColor = activeLabelColor;
                Label_OpBoxLed_Aisle.Font = activeLabelFont;
                ledStatus = "ON";
            }
            else
            {
                Label_OpBoxLed_Aisle.ForeColor = inactiveLabelColor;
                Label_OpBoxLed_Aisle.Font = inactiveLabelFont;
                ledStatus = "OFF";
            }
            //Update label
            Label_OpBoxLed_Aisle.Text = "led " + ledStatus;
        }

        private void Update_TextBox_ZoningStatus_Aisle()
        {
            byte status = Utils.GetLowerByte(currentAisle.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_Aisle.Text = Utils.ZoningStatuses[status];
        }
        private void Update_Label_PlcStopRequest_Aisle()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentAisle.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_StopRequest_Aisle.ForeColor = activeLabelColor;
                Label_StopRequest_Aisle.Font = activeLabelFont;
            }
            else
            {
                Label_StopRequest_Aisle.ForeColor = inactiveLabelColor;
                Label_StopRequest_Aisle.Font = inactiveLabelFont;
            }
        }

        private void Update_Label_PlcIsStopStatus_Aisle()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentAisle.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_StopStatus_Aisle.ForeColor = activeLabelColor;
                Label_StopStatus_Aisle.Font = activeLabelFont;
            }
            else
            {
                Label_StopStatus_Aisle.ForeColor = inactiveLabelColor;
                Label_StopStatus_Aisle.Font = inactiveLabelFont;
            }
        }

        #region SafetyBoard
        private void Update_Label_SafetyBoard_AisleNorth()
        {
            // Read PLC input
            string status;
            if (currentAisle.SafetyBoards[0].Value)
            {
                status = "ON";
                Label_SafetyBoard_AisleNorth.ForeColor = activeLabelColor;
                Label_SafetyBoard_AisleNorth.Font = activeLabelFont;
            }
            else
            {
                status = "OFF";
                Label_SafetyBoard_AisleNorth.ForeColor = inactiveLabelColor;
                Label_SafetyBoard_AisleNorth.Font = inactiveLabelFont;
            }
            //Update label
            Label_SafetyBoard_AisleNorth.Text = "is " + status;
        }

        private void Update_Label_SafetyBoard_AisleSouth()
        {
            // Read PLC input
            string status;
            if (currentAisle.SafetyBoards[1].Value)
            {
                status = "ON";
                Label_Safety_AisleSouth.ForeColor = activeLabelColor;
                Label_Safety_AisleSouth.Font = activeLabelFont;
            }
            else
            {
                status = "OFF";
                Label_Safety_AisleSouth.ForeColor = inactiveLabelColor;
                Label_Safety_AisleSouth.Font = inactiveLabelFont;
            }
            //Update label
            Label_Safety_AisleSouth.Text = "is " + status;
        }
        #endregion // safety boards

        #region Door
        /// <summary>
        /// This only updates the interface based on the current PLCinput. 
        /// Not the other way around.
        /// This is a PLC input that depends on 2 signals.
        /// One is the door closed sensor.
        /// The other is the PLC unlock output.
        /// </summary>
        private void Update_Label_DoorIsLocked_Aisle()
        {
            string doorStatus;
            // Read Plc output
            // The door is locked when the door is closed and the unlock output is false.
            // TODO - check the behaviour of this if.
            if (currentAisle.Door.IsDoorClosed & !currentAisle.Door.unlockDoor.Value)
            {
                Label_DoorIsLocked_Aisle.ForeColor = activeLabelColor;
                Label_DoorIsLocked_Aisle.Font = activeLabelFont;
                doorStatus = "locked";
            }
            else
            {
                Label_DoorIsLocked_Aisle.ForeColor = emergencyLabelColor;
                Label_DoorIsLocked_Aisle.Font = emergencyLabelFont;
                doorStatus = "unlocked";
            }
            //Update label
            Label_DoorIsLocked_Aisle.Text = doorStatus;
        }
        private void Update_Label_UnlockDoor_Aisle()
        {
            string unlockStatus;
            //Read output
            if (currentAisle.Door.unlockDoor.Value)
            {
                Label_UnlockDoor_Aisle.ForeColor = activeLabelColor;
                Label_UnlockDoor_Aisle.Font = activeLabelFont;
                unlockStatus = "ON";
            }
            else
            {
                Label_UnlockDoor_Aisle.ForeColor = inactiveLabelColor;
                Label_UnlockDoor_Aisle.Font = inactiveLabelFont;
                unlockStatus = "OFF";
            }
            //Update label
            Label_DoorIsLocked_Aisle.Text = "unlock" + unlockStatus;
        }
        #endregion // Door

        #region Contactors
        private void Update_Label_ContactorPlcOut_AisleNorth()
        {
            string status;
            // Read Plc output
            if (currentAisle.Contactors[0].Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_AisleNorth.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_AisleNorth.Font = activeLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_Aisle.Checked)
                {
                    CheckBox_ContactorFdbk_AisleNorth.Checked = false;
                }
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_AisleNorth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_AisleNorth.Font = inactiveLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_Aisle.Checked)
                {
                    CheckBox_ContactorFdbk_AisleNorth.Checked = true;
                }
            }
            //Update labels
            Label_ContactorPlcOut_AisleNorth.Text = status;
        }
        private void Update_Label_ContactorPlcOut_AisleSouth()
        {
            string status;
            // Read PLC output
            if (currentAisle.Contactors[1].Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_AisleSouth.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_AisleSouth.Font = activeLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_Aisle.Checked)
                {
                    CheckBox_ContactorFdbk_AisleSouth.Checked = false;
                }
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_AisleSouth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_AisleSouth.Font = inactiveLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_Aisle.Checked)
                {
                    CheckBox_ContactorFdbk_AisleSouth.Checked = true;
                }
            }
            //Update labels
            Label_ContactorPlcOut_AisleSouth.Text = status;
        }

        /// <summary>
        /// Updates the outputs of all contactors, including the ones not being displayed on the interface.
        /// Added to accept HMI commands during simultaion.
        /// </summary>
        private void UpdateAllAisleContactorOutputs()
        {
            // Simply read all contactors and assign the inverse of the output value to the feedback value.
            if (CheckBox_FBAuto_Aisle.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                aisle.Contactors.ForEach(contactor => contactor.Feedback.Value = !contactor.Output.Value));
            }
        }
        #endregion // Contactors

        #endregion // Output

        #endregion // Aisle

        #region Deck
        /// <summary>
        /// Updates the interface with the values of the current Deck.
        /// </summary>
        private void UpdateDeckInterface()
        {
            #region Inputs
            // Estop button
            // Checkbox value = NOT(Emergency btn value)
            CheckBox_EstopBtn_Deck.Checked = !currentDeck.OperationBox.EmergencyBtn.Value;

            // Zoning
            updateZoningRadioButtons(currentDeck, ref RadioButton_None_Deck,
                ref RadioButton_Run_Deck, ref RadioButton_Permit_Deck, ref RadioButton_Cancel_Deck);


            // Key switch
            RadioButton_Req_Deck.Checked = currentDeck.OperationBox.KeySwitch.Req.Value;
            RadioButton_Ready_Aisle.Checked = currentDeck.OperationBox.KeySwitch.Ready.Value;

            // Door
            RadioButton_DoorClosed_Deck.Checked = currentDeck.Door.IsDoorClosed;
            RadioButton_DoorOpen_Deck.Checked = !currentDeck.Door.IsDoorClosed;

            // Emergency stop
            bool flag = Utils.ReadRegisterBit(currentDeck.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_ReqCompleteFlag_Deck.Checked = flag;

            #endregion // Inputs

            #region Outputs
            UpdateDeckOutputs();
            #endregion // Outputs

            // Log
            ListBox_Log.Items.Add("Interface updated. Now displaying " + currentDeck.Label + " data.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #region Input
        private void ComboBox_Decks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Deck List.
            currentDeck = CoSimulationInstance.AlphaBotSystem.Decks[ComboBox_Decks.SelectedIndex];
            // When the selected deck changes, update aisle interface with the new deck data
            UpdateDeckInterface();
        }
        private void CheckBox_AllDecks_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllDecks.Checked)
                CheckBox_AllDecks.ForeColor = Color.Red;
            else
                CheckBox_AllDecks.ForeColor = Color.Black;
        }

        #region Opbox
        private void CheckBox_EstopBtn_Deck_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                currentDeck.OperationBox.EmergencyBtn,
                CheckBox_EstopBtn_Deck,
                currentDeck.Label);
        }

        #region Reset btn
        private void Btn_Reset_Deck_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentDeck.OperationBox.ResetBtn,
                true,
                currentDeck.Label + " Reset");
        }
        private void Btn_Reset_Deck_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentDeck.OperationBox.ResetBtn,
                false,
                currentDeck.Label + " Reset");
        }
        #endregion // Reset btn

        #region Request btn
        private void Btn_Request_Deck_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentDeck.OperationBox.RunBtn,
                true,
                currentDeck.Label + " Run");
        }
        private void Btn_Request_Deck_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentDeck.OperationBox.RunBtn,
                false,
                currentDeck.Label + " Run");
        }
        #endregion // Request btn

        #region Key switch
        private void RadioButton_Ready_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllDecks.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                    deck.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_Deck.Checked);
                string isReady = RadioButton_Ready_Deck.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All Deck Doors are " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentDeck.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_Deck.Checked;
                string isReady = RadioButton_Ready_Deck.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentDeck.Label + " Door is " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_Req_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllDecks.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                {
                    deck.OperationBox.KeySwitch.Req.Value = RadioButton_Req_Deck.Checked;
                });
                string isReq = RadioButton_Req_Deck.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add("All Deck Doors are " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentDeck.OperationBox.KeySwitch.Req.Value = RadioButton_Req_Deck.Checked;
                string isReq = RadioButton_Req_Deck.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add(currentDeck.Label + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Key switch

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_Deck.Checked)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None;
                    // Log
                    ListBox_Log.Items.Add(currentDeck.Label + " None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Permit_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Permit_Deck.Checked)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit;
                    // Log
                    ListBox_Log.Items.Add(currentDeck.Label + " Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Run_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Run_Deck.Checked)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run;
                    // Log
                    ListBox_Log.Items.Add(currentDeck.Label + " Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Cancel_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cancel_Deck.Checked)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel;
                    // Log
                    ListBox_Log.Items.Add(currentDeck.Label + " Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Zoning

        #region Door
        private void RadioButton_DoorClosed_Deck_CheckedChanged(object sender, EventArgs e)
        {
            // The door sensor is Normally Closed, ie True when closed.
            if (CheckBox_AllDecks.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                    deck.Door.IsDoorClosed = RadioButton_DoorClosed_Deck.Checked);
                // Log
                string isClosed = RadioButton_DoorClosed_Deck.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add("All Deck Doors are " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                //The door sensor is Normally Closed, ie True when closed.
                currentDeck.Door.IsDoorClosed = RadioButton_DoorClosed_Deck.Checked;
                // Log
                string isClosed = RadioButton_DoorClosed_Deck.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add(currentDeck.Label + " Door is " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_DoorOpen_Deck_CheckedChanged(object sender, EventArgs e)
        {
            // Nothing to do here. Assume this radio button only changes when the DoorClosed changes.
        }

        #endregion // Door

        #region Emergency stop
        private void CheckBox_ReqCompleteFlag_Deck_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = currentDeck.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ReqCompleteFlag_Deck.Checked);
            // Log action
            string isComplete = CheckBox_ReqCompleteFlag_Deck.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentDeck.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #endregion // Input

        #region Output
        private void UpdateDeckOutputs()
        {
            Update_Label_OpBoxLed_Deck();
            Update_TextBox_ZoningStatus_Deck();
            Update_Label_PlcStopRequest_Deck();
            Update_Label_PlcIsStopStatus_Deck();
            Update_Label_DoorIsLocked(currentDeck, Label_DoorIsLocked_Deck);
            Update_Label_UnlockDoor(currentDeck, Label_UnlockDoor_Deck);
        }

        private void Update_Label_OpBoxLed_Deck()
        {
            string ledStatus;
            // Read Plc output
            if (currentDeck.OperationBox.ZoningStatusLed.Value == true)
            {
                Label_OpBoxLed_Deck.ForeColor = activeLabelColor;
                Label_OpBoxLed_Deck.Font = activeLabelFont;
                ledStatus = "ON";
            }
            else
            {
                Label_OpBoxLed_Deck.ForeColor = inactiveLabelColor;
                Label_OpBoxLed_Deck.Font = inactiveLabelFont;
                ledStatus = "OFF";
            }
            //Update label
            Label_OpBoxLed_Deck.Text = "led " + ledStatus;
        }
        private void Update_TextBox_ZoningStatus_Deck()
        {
            byte status = Utils.GetLowerByte(currentDeck.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_Deck.Text = Utils.ZoningStatuses[status];
        }
        private void Update_Label_PlcStopRequest_Deck()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentDeck.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_StopRequest_Deck.ForeColor = activeLabelColor;
                Label_StopRequest_Deck.Font = activeLabelFont;
            }
            else
            {
                Label_StopRequest_Deck.ForeColor = inactiveLabelColor;
                Label_StopRequest_Deck.Font = inactiveLabelFont;
            }
        }
        private void Update_Label_PlcIsStopStatus_Deck()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentDeck.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_StopStatus_Deck.ForeColor = activeLabelColor;
                Label_StopStatus_Deck.Font = activeLabelFont;
            }
            else
            {
                Label_StopStatus_Deck.ForeColor = inactiveLabelColor;
                Label_StopStatus_Deck.Font = inactiveLabelFont;
            }
        }
        #endregion // Output

        #endregion // Deck

        #region Tower DWS

        /// <summary>
        /// Updates the interface with the values of the current Tower DWS.
        /// Toggle buttons' status is saved.
        /// Push buttons' status is not saved.
        /// All else is saved
        /// </summary>
        private void UpdateTowerDwsInterface()
        {
            #region Inputs
            // Estop button
            // Checkbox value = NOT(Emergency btn value)
            CheckBox_EstopBtn_TDWS.Checked = !currentTowerDws.OperationBox.EmergencyBtn.Value;

            // Zoning
            updateZoningRadioButtons(currentTowerDws, ref RadioButton_None_TDWS,
                ref RadioButton_Run_TDWS, ref RadioButton_Permit_TDWS, ref RadioButton_Cancel_TDWS);

            // Key switch
            RadioButton_Req_TDWS.Checked = currentTowerDws.OperationBox.KeySwitch.Req.Value;
            RadioButton_Ready_TDWS.Checked = currentTowerDws.OperationBox.KeySwitch.Ready.Value;

            // Door
            // Note: The isDoorClose is not a PLC input,
            // it is a boolean property used as an intermediary signal.
            RadioButton_DoorOpen_TDWS.Checked = currentTowerDws.Door.IsDoorClosed;
            RadioButton_DoorClosed_TDWS.Checked = !currentTowerDws.Door.IsDoorClosed;

            // Emergency stop
            bool flag = Utils.ReadRegisterBit(currentTowerDws.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_ReqCompleteFlag_TDWS.Checked = flag;

            // Safety boards
            // Only one safety board for each Tower DWS.
            CheckBox_SafetyBoard_TDWS.Checked = currentTowerDws.SafetyBoards[0].Value;

            // Contactors
            bool flagOnOff = Utils.ReadRegisterBit(currentTowerDws.Contactors[0].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_TDWSpick.Checked = flagOnOff;
            flagOnOff = Utils.ReadRegisterBit(currentTowerDws.Contactors[1].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_TDWStower.Checked = flagOnOff;
            CheckBox_ContactorFdbk_TDWSpick.Checked = currentTowerDws.Contactors[0].Feedback.Value;
            CheckBox_ContactorFdbk_TDWStower.Checked = currentTowerDws.Contactors[1].Feedback.Value;
            #endregion // Inputs

            #region Outputs
            // Update outputs
            UpdateTowerDwsOutputs();
            #endregion// Outputs

            // Log
            ListBox_Log.Items.Add("Interface updated. Now displaying " + currentTowerDws.Label + " data.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #region Input
        private void ComboBox_TowerDWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Tower DWS list.
            currentTowerDws = 
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations[ComboBox_TowerDWS.SelectedIndex];
            // When the selected index changes, update TDWS interface with the corresponding  data
            UpdateTowerDwsInterface();
        }

        private void CheckBox_AllTDWSs_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllTDWSs.Checked)
                CheckBox_AllTDWSs.ForeColor = Color.Red;
            else
                CheckBox_AllTDWSs.ForeColor = Color.Black;
        }

        #region Opbox
        private void CheckBox_EstopBtn_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                currentTowerDws.OperationBox.EmergencyBtn,
                CheckBox_EstopBtn_TDWS,
                currentTowerDws.Label);
        }

        #region Reset btn
        private void Btn_Reset_TDWS_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentTowerDws.OperationBox.ResetBtn,
                true,
                currentTowerDws.Label + " Reset");
        }

        private void Btn_Reset_TDWS_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentTowerDws.OperationBox.ResetBtn,
                false,
                currentTowerDws.Label + " Reset");
        }
        #endregion // Reset btn

        #region Run btn
        private void Btn_Run_TDWS_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentTowerDws.OperationBox.RunBtn,
                true,
                currentTowerDws.Label + " run");
        }

        private void Btn_Run_TDWS_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentTowerDws.OperationBox.RunBtn,
                false,
                currentTowerDws.Label + " run");
        }
        #endregion // Run btn

        #region Key switch
        private void RadioButton_Ready_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllTDWSs.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                {
                    tdws.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_TDWS.Checked;
                });
                string isReady = RadioButton_Ready_TDWS.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All TDWS " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentTowerDws.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_TDWS.Checked;
                string isReady = RadioButton_Ready_TDWS.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentTowerDws.Label + " " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_Req_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllTDWSs.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                {
                    tdws.OperationBox.KeySwitch.Req.Value = RadioButton_Req_TDWS.Checked;
                });
                string isReq = RadioButton_Req_TDWS.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add("All TDWS " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentTowerDws.OperationBox.KeySwitch.Req.Value = RadioButton_Req_TDWS.Checked;
                string isReq = RadioButton_Req_TDWS.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add(currentTowerDws.Label + " " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // key switch

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_TDWS.Checked)
            {
                if (CheckBox_AllTDWSs.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                        tdws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All TDWSs updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentTowerDws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None;
                    // Log
                    ListBox_Log.Items.Add(currentTowerDws.Label + " None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Permit_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Permit_TDWS.Checked)
            {
                if (CheckBox_AllTDWSs.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                        tdws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All TDWSs updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentTowerDws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit;
                    // Log
                    ListBox_Log.Items.Add(currentTowerDws.Label + " Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Run_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Run_TDWS.Checked)
            {
                if (CheckBox_AllTDWSs.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                        tdws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All TDWSs updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentTowerDws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run;
                    // Log
                    ListBox_Log.Items.Add(currentTowerDws.Label + " Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Cancel_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cancel_TDWS.Checked)
            {
                if (CheckBox_AllTDWSs.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                        tdws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All TDWSs updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentTowerDws.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel;
                    // Log
                    ListBox_Log.Items.Add(currentTowerDws.Label + " Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Zoning

        #region Door
        private void RadioButton_DoorClosed_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllTDWSs.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                {
                    tdws.Door.IsDoorClosed = RadioButton_DoorOpen_TDWS.Checked;
                });
                string isClosed = RadioButton_DoorOpen_TDWS.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add("All TDWSs Doors are " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                //The door sensor is Normally Closed, ie True when closed.
                currentTowerDws.Door.IsDoorClosed = RadioButton_DoorOpen_TDWS.Checked;
                string isClosed = RadioButton_DoorOpen_TDWS.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add(currentTowerDws.Label + " Door is " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_DoorOpen_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            // Nothing to do here. Assume this radio button only changes when the DoorClosed changes.
        }
        #endregion // Door

        #region Emergency stop
        private void CheckBox_ReqCompleteFlag_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            // Write byte
            RegisterToPlc currentRegister = currentTowerDws.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ReqCompleteFlag_TDWS.Checked);
            // Log action
            string isComplete = CheckBox_ReqCompleteFlag_TDWS.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentTowerDws.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #region SafetyBoards
        private void CheckBox_SafetyBoard_TDWS_CheckedChanged(object sender, EventArgs e)
        {
            // The safety board sensor is True for normal operation
            // Assume safety board has index 0.
            if (CheckBox_AllTDWSs.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                {
                    tdws.SafetyBoards[0].Value = CheckBox_SafetyBoard_TDWS.Checked;
                });
                // Log action
                string isOn = CheckBox_SafetyBoard_TDWS.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("All North safety boards " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentTowerDws.SafetyBoards[0].Value = CheckBox_SafetyBoard_TDWS.Checked;
                // Log action
                string isOn = CheckBox_SafetyBoard_TDWS.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add(currentTowerDws.Label + " safety board " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // safety boards

        #region Contactors
        private void CheckBox_ContactorOnOff_TDWSpick_CheckedChanged(object sender, EventArgs e)
        {
            // Assume pick side contactor has index 0 and Tower side contactor has index 1.
            RegisterToPlc currentRegister = currentTowerDws.Contactors[0].ContactorOnOffCommand;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ContactorOnOff_TDWSpick.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_TDWSpick.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentTowerDws.Label + " pick side ctor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorOnOff_TDWStower_CheckedChanged(object sender, EventArgs e)
        {
            // Assume pick side contactor has index 0 and Tower side contactor has index 1.
            RegisterToPlc currentRegister = currentTowerDws.Contactors[1].ContactorOnOffCommand;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ContactorOnOff_TDWStower.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_TDWStower.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentTowerDws.Label + " Tower side ctor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorFdbk_TDWSpick_CheckedChanged(object sender, EventArgs e)
        {
            currentTowerDws.Contactors[0].Feedback.Value = CheckBox_ContactorFdbk_TDWSpick.Checked;
            if (CheckBox_ContactorFdbk_TDWSpick.Checked)
            {
                Label_ContactorPlcOut_TDWSpick.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_TDWSpick.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcOut_TDWSpick.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_TDWSpick.Font = inactiveLabelFont;
            }
        }

        private void CheckBox_ContactorFdbk_TDWStower_CheckedChanged(object sender, EventArgs e)
        {
            currentTowerDws.Contactors[1].Feedback.Value = CheckBox_ContactorFdbk_TDWStower.Checked;
            if (CheckBox_ContactorFdbk_TDWStower.Checked)
            {
                Label_ContactorPlcOut_TDWStower.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_TDWStower.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcOut_TDWStower.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_TDWStower.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactors

        #endregion // Input

        #region Output
        private void UpdateTowerDwsOutputs()
        {
            Update_Label_OpBoxLed_TowerDws();
            Update_TextBox_ZoningStatus_TowerDws();
            Update_Label_PlcStopRequest_TowerDws();
            Update_Label_PlcIsStopStatus_TowerDws();
            Update_Label_SafetyBoard_TowerDws();
            Update_Label_ContactorPlcOut_TowerDwsPick();
            Update_Label_ContactorPlcOut_TowerDwsTower();
            Update_Label_DoorIsLocked(currentTowerDws, Label_DoorIsLocked_TDWS);
            Update_Label_UnlockDoor(currentTowerDws, Label_UnlockDoor_TDWS);
            UpdateAllTDWSsContactorOutputs();
        }
        private void Update_Label_OpBoxLed_TowerDws()
        {
            string ledStatus;
            // Read Plc output
            if (currentTowerDws.OperationBox.ZoningStatusLed.Value)
            {
                Label_OpBoxLed_TDWS.ForeColor = activeLabelColor;
                Label_OpBoxLed_TDWS.Font = activeLabelFont;
                ledStatus = "ON";
            }
            else
            {
                Label_OpBoxLed_TDWS.ForeColor = inactiveLabelColor;
                Label_OpBoxLed_TDWS.Font = inactiveLabelFont;
                ledStatus = "OFF";
            }
            //Update label
            Label_OpBoxLed_TDWS.Text = "led " + ledStatus;
        }

        private void Update_TextBox_ZoningStatus_TowerDws()
        {
            byte status = Utils.GetLowerByte(currentTowerDws.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_TDWS.Text = Utils.ZoningStatuses[status];
        }

        private void Update_Label_PlcStopRequest_TowerDws()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentTowerDws.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_StopRequest_TDWS.ForeColor = activeLabelColor;
                Label_StopRequest_TDWS.Font = activeLabelFont;
            }
            else
            {
                Label_StopRequest_TDWS.ForeColor = inactiveLabelColor;
                Label_StopRequest_TDWS.Font = inactiveLabelFont;
            }
        }

        private void Update_Label_PlcIsStopStatus_TowerDws()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentTowerDws.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_StopStatus_TDWS.ForeColor = activeLabelColor;
                Label_StopStatus_TDWS.Font = activeLabelFont;
            }
            else
            {
                Label_StopStatus_TDWS.ForeColor = inactiveLabelColor;
                Label_StopStatus_TDWS.Font = inactiveLabelFont;
            }
        }

        #region SafetyBoard
        private void Update_Label_SafetyBoard_TowerDws()
        {
            // Read PLC input
            string status;
            if (currentTowerDws.SafetyBoards[0].Value)
            {
                status = "ON";
                Label_SafetyBoard_TDWS.ForeColor = activeLabelColor;
                Label_SafetyBoard_TDWS.Font = activeLabelFont;
            }
            else
            {
                status = "OFF";
                Label_SafetyBoard_TDWS.ForeColor = inactiveLabelColor;
                Label_SafetyBoard_TDWS.Font = inactiveLabelFont;
            }
            //Update label
            Label_SafetyBoard_TDWS.Text = "is " + status;
        }
        #endregion // safety boards

        #region Contactors
        private void Update_Label_ContactorPlcOut_TowerDwsPick()
        {
            string status;
            // Read Plc output
            if (currentTowerDws.Contactors[0].Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_TDWSpick.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_TDWSpick.Font = activeLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_TDWS.Checked)
                {
                    CheckBox_ContactorFdbk_TDWSpick.Checked = false;
                }
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_TDWSpick.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_TDWSpick.Font = inactiveLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_TDWS.Checked)
                {
                    CheckBox_ContactorFdbk_TDWSpick.Checked = true;
                }
            }
            //Update labels
            Label_ContactorPlcOut_TDWSpick.Text = status;
        }
        private void Update_Label_ContactorPlcOut_TowerDwsTower()
        {
            string status;
            // Read PLC output
            if (currentTowerDws.Contactors[1].Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_TDWStower.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_TDWStower.Font = activeLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_TDWS.Checked)
                {
                    CheckBox_ContactorFdbk_TDWStower.Checked = false;
                }
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_TDWStower.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_TDWStower.Font = inactiveLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_TDWS.Checked)
                {
                    CheckBox_ContactorFdbk_TDWStower.Checked = true;
                }
            }
            //Update labels
            Label_ContactorPlcOut_TDWStower.Text = status;
        }

        /// <summary>
        /// Updates the outputs of all contactors, including the ones not being displayed on the interface.
        /// Added to accept HMI commands during simultaion.
        /// </summary>
        private void UpdateAllTDWSsContactorOutputs()
        {
            // Simply read all contactors and assign the inverse of the output value to the feedback value.
            if (CheckBox_FBAuto_TDWS.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.TowerDynamicWorkStations.ForEach(tdws =>
                tdws.Contactors.ForEach(contactor => contactor.Feedback.Value = !contactor.Output.Value));
            }
        }
        #endregion // Contactors

        #endregion // Output

        #endregion // Tower DWS

        #region Small Aisle

        /// <summary>
        /// Updates the interface with the values of the current Small Aisle .
        /// Toggle buttons' status is saved.
        /// Push buttons' status is not saved.
        /// All else is saved
        /// </summary>
        private void UpdateSmallAisleInterface()
        {
            #region Inputs
            // Estop button
            // Checkbox value = NOT(Emergency btn value)
            CheckBox_EstopBtn_SmallAisle.Checked = !currentSmallAisle.OperationBox.EmergencyBtn.Value;

            // Zoning
            updateZoningRadioButtons(currentSmallAisle, ref RadioButton_None_SmallAisle,
                ref RadioButton_Run_SmallAisle, ref RadioButton_Permit_SmallAisle, ref RadioButton_Cancel_SmallAisle);

            // Key switch
            RadioButton_Req_SmallAisle.Checked = currentSmallAisle.OperationBox.KeySwitch.Req.Value;
            RadioButton_Ready_SmallAisle.Checked = currentSmallAisle.OperationBox.KeySwitch.Ready.Value;

            // Emergency stop
            bool flag = Utils.ReadRegisterBit(currentSmallAisle.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_ReqCompleteFlag_SmallAisle.Checked = flag;

            // Contactors
            bool flagOnOff = Utils.ReadRegisterBit(currentSmallAisle.Contactors[0].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_SmallAisle.Checked = flagOnOff;
            CheckBox_ContactorFdbk_SmallAisle.Checked = currentSmallAisle.Contactors[0].Feedback.Value;
            #endregion // Inputs

            #region Outputs
            // Update outputs
            UpdateSmallAisleOutputs();
            #endregion// Outputs

            // Log
            ListBox_Log.Items.Add("Interface updated. Now displaying " + currentSmallAisle.Label + " data.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #region Input
        private void ComboBox_SmallAisle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Tower DWS list.
            currentSmallAisle =
                CoSimulationInstance.AlphaBotSystem.SmallAisles[ComboBox_SmallAisle.SelectedIndex];
            // When the selected index changes, update SmallAisle interface with the corresponding  data
            UpdateSmallAisleInterface();
        }

        private void CheckBox_AllSmallAisles_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllSmallAisles.Checked)
                CheckBox_AllSmallAisles.ForeColor = Color.Red;
            else
                CheckBox_AllSmallAisles.ForeColor = Color.Black;
        }

        #region Opbox
        private void CheckBox_EstopBtn_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                currentSmallAisle.OperationBox.EmergencyBtn,
                CheckBox_EstopBtn_SmallAisle,
                currentSmallAisle.Label);
        }

        #region Reset btn
        private void Btn_Reset_SmallAisle_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentSmallAisle.OperationBox.ResetBtn,
                true,
                currentSmallAisle.Label + " Reset");
        }

        private void Btn_Reset_SmallAisle_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentSmallAisle.OperationBox.ResetBtn,
                false,
                currentSmallAisle.Label + " Reset");
        }
        #endregion // Reset btn

        #region Run btn
        private void Btn_Run_SmallAisle_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentSmallAisle.OperationBox.RunBtn,
                true,
                currentSmallAisle.Label + " run");
        }

        private void Btn_Run_SmallAisle_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentSmallAisle.OperationBox.RunBtn,
                false,
                currentSmallAisle.Label + " run");
        }
        #endregion // Run btn

        #region Key switch
        private void RadioButton_Ready_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllSmallAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                {
                    saisle.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_SmallAisle.Checked;
                });
                string isReady = RadioButton_Ready_SmallAisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All Small Aisles " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentSmallAisle.OperationBox.KeySwitch.Ready.Value = RadioButton_Ready_SmallAisle.Checked;
                string isReady = RadioButton_Ready_SmallAisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentSmallAisle.Label + " " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_Req_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllSmallAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                {
                    saisle.OperationBox.KeySwitch.Req.Value = RadioButton_Req_SmallAisle.Checked;
                });
                string isReq = RadioButton_Req_SmallAisle.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add("All TDWS " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentSmallAisle.OperationBox.KeySwitch.Req.Value = RadioButton_Req_SmallAisle.Checked;
                string isReq = RadioButton_Req_SmallAisle.Checked ? "Req" : "No Req";
                ListBox_Log.Items.Add(currentSmallAisle.Label + " " + isReq);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // key switch

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_SmallAisle.Checked)
            {
                if (CheckBox_AllSmallAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                        saisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All Small Aisles updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentSmallAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.None;
                    // Log
                    ListBox_Log.Items.Add(currentSmallAisle.Label + " None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }

        private void RadioButton_Permit_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Permit_SmallAisle.Checked)
            {
                if (CheckBox_AllSmallAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                        saisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All Small Aisles updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentSmallAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Permit;
                    // Log
                    ListBox_Log.Items.Add(currentSmallAisle.Label + " Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }

        private void RadioButton_Run_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Run_SmallAisle.Checked)
            {
                if (CheckBox_AllSmallAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                        saisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All Small Aisles updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentSmallAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Run;
                    // Log
                    ListBox_Log.Items.Add(currentSmallAisle.Label + " Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }

        private void RadioButton_Cancel_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cancel_SmallAisle.Checked)
            {
                if (CheckBox_AllSmallAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                        saisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All Small Aisles updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentSmallAisle.Zoning.CellCommand.Value = (byte)Utils.CellCommandValues.Cancel;
                    // Log
                    ListBox_Log.Items.Add(currentSmallAisle.Label + " Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Zoning

        #region Emergency stop
        private void CheckBox_ReqCompleteFlag_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            // Write byte
            RegisterToPlc currentRegister = currentSmallAisle.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ReqCompleteFlag_SmallAisle.Checked);
            // Log action
            string isComplete = CheckBox_ReqCompleteFlag_SmallAisle.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentSmallAisle.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #region Contactors
        private void CheckBox_ContactorOnOff_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = currentSmallAisle.Contactors[0].ContactorOnOffCommand;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_ContactorOnOff_SmallAisle.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_SmallAisle.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentSmallAisle.Label + " " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorFdbk_SmallAisle_CheckedChanged(object sender, EventArgs e)
        {
            currentSmallAisle.Contactors[0].Feedback.Value = CheckBox_ContactorFdbk_SmallAisle.Checked;
            if (CheckBox_ContactorFdbk_SmallAisle.Checked)
            {
                Label_ContactorPlcOut_SmallAisle.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_SmallAisle.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcOut_SmallAisle.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_SmallAisle.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactors

        #endregion // Input

        #region Output
        private void UpdateSmallAisleOutputs()
        {
            Update_Label_OpBoxLed_SmallAisle();
            Update_TextBox_ZoningStatus_SmallAisle();
            Update_Label_PlcStopRequest_SmallAisle();
            Update_Label_PlcIsStopStatus_SmallAisle();
            Update_Label_ContactorPlcOut_SmallAisle();
            UpdateAllSmallAislesContactorOutputs();
        }
        private void Update_Label_OpBoxLed_SmallAisle()
        {
            string ledStatus;
            // Read Plc output
            if (currentSmallAisle.OperationBox.ZoningStatusLed.Value)
            {
                Label_OpBoxLed_SmallAisle.ForeColor = activeLabelColor;
                Label_OpBoxLed_SmallAisle.Font = activeLabelFont;
                ledStatus = "ON";
            }
            else
            {
                Label_OpBoxLed_SmallAisle.ForeColor = inactiveLabelColor;
                Label_OpBoxLed_SmallAisle.Font = inactiveLabelFont;
                ledStatus = "OFF";
            }
            //Update label
            Label_OpBoxLed_SmallAisle.Text = "led " + ledStatus;
        }

        private void Update_TextBox_ZoningStatus_SmallAisle()
        {
            byte status = Utils.GetLowerByte(currentSmallAisle.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_SmallAisle.Text = Utils.ZoningStatuses[status];
        }

        private void Update_Label_PlcStopRequest_SmallAisle()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentSmallAisle.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_StopRequest_SmallAisle.ForeColor = activeLabelColor;
                Label_StopRequest_SmallAisle.Font = activeLabelFont;
            }
            else
            {
                Label_StopRequest_SmallAisle.ForeColor = inactiveLabelColor;
                Label_StopRequest_SmallAisle.Font = inactiveLabelFont;
            }
        }

        private void Update_Label_PlcIsStopStatus_SmallAisle()
        {
            // Read Plc output
            bool flag = Utils.ReadRegisterBit(currentSmallAisle.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_StopStatus_SmallAisle.ForeColor = activeLabelColor;
                Label_StopStatus_SmallAisle.Font = activeLabelFont;
            }
            else
            {
                Label_StopStatus_SmallAisle.ForeColor = inactiveLabelColor;
                Label_StopStatus_SmallAisle.Font = inactiveLabelFont;
            }
        }

        #region Contactors
        private void Update_Label_ContactorPlcOut_SmallAisle()
        {
            string status;
            // Read Plc output
            if (currentSmallAisle.Contactors[0].Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_SmallAisle.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_SmallAisle.Font = activeLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_SmallAisle.Checked)
                {
                    CheckBox_ContactorFdbk_SmallAisle.Checked = false;
                }
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_SmallAisle.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_SmallAisle.Font = inactiveLabelFont;
                //Update Feedback control too!
                if (CheckBox_FBAuto_SmallAisle.Checked)
                {
                    CheckBox_ContactorFdbk_SmallAisle.Checked = true;
                }
            }
            //Update labels
            Label_ContactorPlcOut_SmallAisle.Text = status;
        }

        /// <summary>
        /// Updates the outputs of all contactors, including the ones not being displayed on the interface.
        /// Added to accept HMI commands during simultaion.
        /// </summary>
        private void UpdateAllSmallAislesContactorOutputs()
        {
            // Simply read all contactors and assign the inverse of the output value to the feedback value.
            if (CheckBox_FBAuto_SmallAisle.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.SmallAisles.ForEach(saisle =>
                saisle.Contactors.ForEach(contactor => contactor.Feedback.Value = !contactor.Output.Value));
            }
        }
        #endregion // Contactors

        #endregion // Output

        #endregion // Small Aisle

        #region CELL communication
        #region CELL side
        private void CheckBox_IsCellConnectedPulse_CheckedChanged(object sender, EventArgs e)
        {
            // If the check box is not checked, the signal's value is 0
            if (! CheckBox_IsCellConnectedPulse.Checked)
            {
                // Update PLC input value
                CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse.Value = 0;
                ListBox_Log.Items.Add("CELL is disconnected.");
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                ListBox_Log.Items.Add("CELL is connected!");
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        #region Reset btn
        private void Btn_ResetFromCell_MouseDown(object sender, MouseEventArgs e)
        {
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.ResetFromCell.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.ResetFromCell.Value = Utils.SingleBitInWordValues[bitPos];
            ListBox_Log.Items.Add("CELL command: Reset button pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_ResetFromCell_MouseUp(object sender, MouseEventArgs e)
        {
            // Register value is zero.
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.ResetFromCell.Value = 0;
        }
        #endregion // Reset btn

        #region Radio buttons
        private void RadioButton_CanSystemStartUp_CheckedChanged(object sender, EventArgs e)
        {
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.CanSystemStartUp.Value =
                (ushort)(RadioButton_CanSystemStartUp.Checked ? Utils.SingleBitInWordValues[bitPos] : 0);
            string canStartUp = RadioButton_CanSystemStartUp.Checked ? "can start." : "is booting up.";
            ListBox_Log.Items.Add("CELL command: System " + canStartUp);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void RadioButton_SystemIsStartingUp_CheckedChanged(object sender, EventArgs e)
        {
            // Pair with RadioButton_CanSystemStartUp_CheckedChanged.
            // No logging needed here. 
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.SystemIsStartingUp.Value =
                (ushort)(RadioButton_SystemIsStartingUp.Checked ? Utils.SingleBitInWordValues[bitPos] : 0);
        }
        #endregion // Radio buttons

        // Bot evacuation complete flag.
        private void CheckBox_BotEvacComplete_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = 
                CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.BotEvacuationComplete;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_BotEvacComplete.Checked);
            // Log action
            string isOn = CheckBox_BotEvacComplete.Checked ? "TRUE." : "FALSE.";
            ListBox_Log.Items.Add("Bot evacuation flag: " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // CELL side

        #region PLC side

        private void Update_Label_CELLcomm_PlcStatus()
        {
            string plcStatus;
            RegisterFromPlc currentErrorRegister = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsPlcWarningMode;
            RegisterFromPlc currentModeRegister = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsPlcWarningMode;
            RegisterFromPlc currentAutoModeRegister = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsPlcAutoMode;

            // Read PLC output
            ushort currentErrorStatus = currentErrorRegister.Value;
            ushort errorBitPos = currentErrorRegister.BitPosition;
            ushort currentMode = currentModeRegister.Value;
            ushort modeBitPos = currentModeRegister.BitPosition;
            // IsPlcWarningMode and IsPlcAutoMode use the same registry address
            ushort autoModeBitPos = currentAutoModeRegister.BitPosition;
            // Console.WriteLine("currentErrorStatus " + currentErrorStatus);
            // Console.WriteLine("errorBitPos " + errorBitPos);
            // Console.WriteLine("currentMode " + currentMode);
            // Console.WriteLine("modeBitPos " + modeBitPos);
            // Console.WriteLine("autoModeBitPos " + autoModeBitPos);

            // If the error signal is active
            if ((currentErrorStatus & Utils.SingleBitInWordValues[errorBitPos]) != 0)
            {
                plcStatus = "Error";
                Label_CELLcomm_PlcStatus.ForeColor = errorLabelColor;
                Label_CELLcomm_PlcStatus.Font = errorLabelFont;
            }
            else if ((currentMode & Utils.SingleBitInWordValues[modeBitPos]) != 0)
            {
                plcStatus = "Warning";
                Label_CELLcomm_PlcStatus.ForeColor = emergencyLabelColor;
                Label_CELLcomm_PlcStatus.Font = emergencyLabelFont;
            }
            else if ((currentMode & Utils.SingleBitInWordValues[autoModeBitPos]) != 0)
            {
                plcStatus = "Auto";
                Label_CELLcomm_PlcStatus.ForeColor = activeLabelColor;
                Label_CELLcomm_PlcStatus.Font = activeLabelFont;
            }
            else if ((currentMode & Utils.SingleBitInWordValues[autoModeBitPos]) == 0)
            {
                plcStatus = "Manual";
                Label_CELLcomm_PlcStatus.ForeColor = activeLabelColor;
                Label_CELLcomm_PlcStatus.Font = activeLabelFont;
            }
            else
            {
                plcStatus = "Unknown";
                Label_CELLcomm_PlcStatus.ForeColor = emergencyLabelColor;
                Label_CELLcomm_PlcStatus.Font = emergencyLabelFont;
            }
            //Update labels
            Label_CELLcomm_PlcStatus.Text = "Plc " + plcStatus;
        }
        #endregion // PLC side

        #endregion // CELL communication

        #region Panels

        #region Input
        private void CheckBox_EstopBtn_DwsPanel_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.EmergencyBtn,
                CheckBox_EstopBtn_DwsPanel,
                "DWS panel");
        }

        private void Btn_Reset_DwsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn.Value = true;
            ListBox_Log.Items.Add("DWS panel Reset button pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_Reset_DwsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel.ResetBtn.Value = false;
            ListBox_Log.Items.Add("DWS panel Reset button released.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_Reset_NorthPanel_MouseDown(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.NorthPanel.ResetBtn.Value = true;
            ListBox_Log.Items.Add("North panel Reset button pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_Reset_NorthPanel_MouseUp(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.NorthPanel.ResetBtn.Value = false;
            ListBox_Log.Items.Add("North panel Reset button released.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_Reset_SouthPanel_MouseDown(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.SouthPanel.ResetBtn.Value = true;
            ListBox_Log.Items.Add("South panel Reset button pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_Reset_SouthPanel_MouseUp(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.PanelSection.SouthPanel.ResetBtn.Value = false;
            ListBox_Log.Items.Add("South panel Reset button released.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Input

        #region Led Towers
        private void Update_ColorLabel_LedTower(Models.Configuration.Panel panel)
        {
            if (panel.SignalTower.RedLed.Value)
            {
                Label_LedTowerRed_DwsPanel.Font = activeLabelFont;
                Label_LedTowerRed_DwsPanel.ForeColor = Color.Red;
            }
            else
            {
                Label_LedTowerRed_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerRed_DwsPanel.ForeColor = inactiveLabelColor;
            }
            //TODO. Update interface. Delete blue color label. Add buzzer output.
            /*
            if (panel.SignalTower.BlueLed.Value)
            {
                Label_LedTowerBlue_DwsPanel.Font = activeLabelFont;
                Label_LedTowerBlue_DwsPanel.ForeColor = Color.Blue;
            }
            else
            {
                Label_LedTowerBlue_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerBlue_DwsPanel.ForeColor = inactiveLabelColor;
            }
            */
            if (panel.SignalTower.YellowLed.Value)
            {
                Label_LedTowerYellow_DwsPanel.Font = activeLabelFont;
                Label_LedTowerYellow_DwsPanel.ForeColor = Color.Orange;
            }
            else
            {
                Label_LedTowerYellow_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerYellow_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.SignalTower.GreenLed.Value)
            {
                Label_LedTowerGreen_DwsPanel.Font = activeLabelFont;
                Label_LedTowerGreen_DwsPanel.ForeColor = Color.Green;
            }
            else
            {
                Label_LedTowerGreen_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerGreen_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.SignalTower.WhiteLed.Value)
            {
                Label_LedTowerWhite_DwsPanel.Font = activeLabelFont;
                Label_LedTowerWhite_DwsPanel.ForeColor = Color.Black;
            }
            else
            {
                Label_LedTowerWhite_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerWhite_DwsPanel.ForeColor = inactiveLabelColor;
            }
        }

        private void Update_Label_LedTower(Models.Configuration.Panel panel, Label label)
        {
            string ledString = "";
            if (panel.SignalTower.RedLed.Value)
            {
                ledString += "Rd ";
            }
            if (panel.SignalTower.YellowLed.Value)
            {
                ledString += "Yl ";
            }
            if (panel.SignalTower.GreenLed.Value)
            {
                ledString += "Gn ";
            }
            if (panel.SignalTower.WhiteLed.Value)
            {
                ledString += "Wh";
            }

            // Update label
            label.Text = ledString;
        }
        #endregion // Led towers

        #endregion // Panels

        #region Stopper
        /// <summary>
        /// Updates the interface with the values of the current Stopper.
        /// </summary>
        private void UpdateStopperInterface()
        {
            #region Inputs
            bool flag = Utils.ReadRegisterBit(currentStopper.OpenCommandFromCell);
            CheckBox_OpenCommandFromCell_Stopper.Checked = flag;
            flag =  Utils.ReadRegisterBit(currentStopper.CloseCommandFromCell);
            CheckBox_CloseCommandFromCell_Stopper.Checked = flag;

            // Sensors
            CheckBox_Alarm_Stopper.Checked = currentStopper.Alarm.Value;
            // Check if sensor logic is inverted
            if (CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted)
            {
                CheckBox_IsOpenSensor_Stopper.Checked = ! currentStopper.IsOpenSensor.Value;
                CheckBox_IsClosedSensor_Stopper.Checked = ! currentStopper.IsClosedSensor.Value;
            }
            else
            {
                CheckBox_IsOpenSensor_Stopper.Checked = currentStopper.IsOpenSensor.Value;
                CheckBox_IsClosedSensor_Stopper.Checked = currentStopper.IsClosedSensor.Value;
            }
            
            #endregion // Inputs

            UpdateStopperOutputs();
        }

        #region Input
        private void ComboBox_Stoppers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Stoppers List.
            currentStopper = CoSimulationInstance.AlphaBotSystem.Stoppers[ComboBox_Stoppers.SelectedIndex];
            // When the selected stopper changes, update stopper interface with the new stopper data
            UpdateStopperInterface();
        }

        private void CheckBox_OpenCommandFromCell_Stopper_CheckedChanged(object sender, EventArgs e)
        {
            // If the open command is active, disable the close command and vice versa.
            CheckBox_CloseCommandFromCell_Stopper.Enabled = !CheckBox_OpenCommandFromCell_Stopper.Checked;
            // Update value
            RegisterToPlc currentRegister = currentStopper.OpenCommandFromCell;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_OpenCommandFromCell_Stopper.Checked);
            // Log action
            string btnStatus = CheckBox_OpenCommandFromCell_Stopper.Checked ? "pressed." : "released.";
            ListBox_Log.Items.Add(currentStopper.Label + " Open command " + btnStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_CloseCommandFromCell_Stopper_CheckedChanged(object sender, EventArgs e)
        {
            // If the close command is active, disable the open command and vice versa.
            CheckBox_OpenCommandFromCell_Stopper.Enabled = !CheckBox_CloseCommandFromCell_Stopper.Checked;
            // Update value
            RegisterToPlc currentRegister = currentStopper.CloseCommandFromCell;
            currentRegister.Value =
                Utils.UpdateRegister(currentRegister, CheckBox_CloseCommandFromCell_Stopper.Checked);
            // Log action
            string btnStatus = CheckBox_CloseCommandFromCell_Stopper.Checked ? "pressed." : "released.";
            ListBox_Log.Items.Add(currentStopper.Label + " Close command " + btnStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_IsOpenSensor_Stopper_CheckedChanged(object sender, EventArgs e)
        {
            // If this is checked, diable the other checkbox
            CheckBox_IsClosedSensor_Stopper.Enabled = !CheckBox_IsOpenSensor_Stopper.Checked;
            // Check if sensor logic is inverted
            if (CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted)
            {
                currentStopper.IsOpenSensor.Value = ! CheckBox_IsOpenSensor_Stopper.Checked;
            }
            else
            {
                currentStopper.IsOpenSensor.Value = CheckBox_IsOpenSensor_Stopper.Checked;
            }
            string sensorStatus = CheckBox_IsClosedSensor_Stopper.Checked ? " open." : " closing.";
            ListBox_Log.Items.Add(currentStopper.Label + sensorStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_IsClosedSensor_Stopper_CheckedChanged(object sender, EventArgs e)
        {
            // If this is checked, diable the other checkbox
            CheckBox_IsOpenSensor_Stopper.Enabled = !CheckBox_IsClosedSensor_Stopper.Checked;
            if (CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted)
            {
                currentStopper.IsClosedSensor.Value = ! CheckBox_IsClosedSensor_Stopper.Checked;
            }
            else
            {
                currentStopper.IsClosedSensor.Value = CheckBox_IsClosedSensor_Stopper.Checked;
            }
            string sensorStatus = CheckBox_IsClosedSensor_Stopper.Checked ? " closed." : " opening.";
            ListBox_Log.Items.Add(currentStopper.Label +  sensorStatus) ;
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_InvAlarm_Stopper_CheckedChanged(object sender, EventArgs e)
        {
            currentStopper.Alarm.Value = CheckBox_Alarm_Stopper.Checked;
            string sensorStatus = CheckBox_Alarm_Stopper.Checked ? "OK." : "Error.";
            ListBox_Log.Items.Add(currentStopper.Label + " Inverter " + sensorStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #endregion // Input

        #region Ouput
        private void UpdateStopperOutputs()
        {
            Update_Label_IsOpenStatusToCell_Stopper();
            Update_Label_IsClosedStatusToCell_Stopper();
            Update_Label_ErrorSignalToCell_Stopper();
            Update_Label_TimeOverSignalToCell_Stopper();
            Update_Label_PlcOpenOut_Stopper();
            Update_Label_PlcCloseOut_Stopper();
            Update_Label_IsOpenSensor_Stopper();
            Update_Label_IsClosedSensor_Stopper();
            Update_AllStoppersIO();
        }

        private void Update_Label_IsOpenSensor_Stopper()
        {
            //TODO - update
            // Check sensor logic
            if (CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted)
            {
                UpdateSignalLabel(currentStopper.IsOpenSensor, Label_IsOpenSensor_Stopper);
            }
            else
            {
                UpdateSignalLabel(currentStopper.IsOpenSensor, Label_IsOpenSensor_Stopper);
            }
        }

        private void Update_Label_IsClosedSensor_Stopper()
        {
            //TODO - update
            // Check sensor logic
            if (CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted)
            {
                UpdateSignalLabel(currentStopper.IsClosedSensor, Label_IsClosedSensor_Stopper);
            }
            else
            {
                UpdateSignalLabel(currentStopper.IsClosedSensor, Label_IsClosedSensor_Stopper);
            }
        }

        private void Update_Label_IsOpenStatusToCell_Stopper()
        {
            UpdateSignalLabel(currentStopper.IsOpenStatusToCell, Label_IsOpenStatusToCell_Stopper);
        }

        private void Update_Label_IsClosedStatusToCell_Stopper()
        {
            UpdateSignalLabel(currentStopper.IsClosedStatusToCell, Label_IsClosedStatusToCell_Stopper);
        }

        private void Label_IsOpenStatusToCell_Stopper_ForeColorChanged(object sender, EventArgs e)
        {
            // Automatically uncheck Cell command check box when this output is active
            if(CheckBox_AutoStopper.Checked & Label_IsOpenStatusToCell_Stopper.ForeColor == activeLabelColor)
            {
                CheckBox_OpenCommandFromCell_Stopper.Checked = false;
            }
        }

        private void Label_IsClosedStatusToCell_Stopper_ForeColorChanged(object sender, EventArgs e)
        {
            // Automatically uncheck Cell command check box when this output is active
            if (CheckBox_AutoStopper.Checked & Label_IsClosedStatusToCell_Stopper.ForeColor == activeLabelColor)
            {
                CheckBox_CloseCommandFromCell_Stopper.Checked = false;
            }
        }

        private void Update_Label_ErrorSignalToCell_Stopper()
        {
            UpdateSignalLabel(currentStopper.ErrorSignalToCell, Label_ErrorSignalToCell_Stopper, true);
        }

        private void Update_Label_TimeOverSignalToCell_Stopper()
        {
            UpdateSignalLabel(currentStopper.TimeOverSignalToCell, Label_TimeOverSignalToCell_Stopper, true);
        }

        /// <summary>
        /// Updates the stoppers' sensors according to the output.
        /// I.e. Instantly close/open the stopper when the corresponding output is active.
        /// </summary>
        private void Update_AllStoppersIO()
        {
            CoSimulationInstance.AlphaBotSystem.Stoppers.ForEach(stopper =>
                {
                    // Only works on manual mode
                    if (!CheckBox_AutoStopper.Checked)
                    {
                        // if the close command is on
                        if (stopper.PlcCloseOut.Value 
                            & !CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted 
                            & stopper.IsOpenSensor.Value & !stopper.IsClosedSensor.Value)
                        {
                            // turn off open sensor and turn on closed sensor.
                            stopper.IsOpenSensor.Value = false;
                            stopper.IsClosedSensor.Value = true;
                        } 
                        else if (stopper.PlcCloseOut.Value 
                            & CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted 
                            & !stopper.IsOpenSensor.Value & stopper.IsClosedSensor.Value)
                        {
                            stopper.IsOpenSensor.Value = true;
                            stopper.IsClosedSensor.Value = false;
                        }

                        // if the open command is on
                        if (stopper.PlcOpenOut.Value 
                            & !CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted 
                            & !stopper.IsOpenSensor.Value & stopper.IsClosedSensor.Value)
                        {
                            // turn off closed sensor and turn on open sensor.
                            stopper.IsClosedSensor.Value = false;
                            stopper.IsOpenSensor.Value = true;
                        }
                        else if (stopper.PlcOpenOut.Value
                            & CoSimulationInstance.AlphaBotSystem.IsStopperSensorInverted 
                            & stopper.IsOpenSensor.Value & !stopper.IsClosedSensor.Value)
                        {
                            stopper.IsClosedSensor.Value = true;
                            stopper.IsOpenSensor.Value = false;
                        }
                    }
                });
        }

        #region Stopper operation simulation
        private void Update_Label_PlcOpenOut_Stopper()
        {
            // Auto mode. Check if the auto check box is checked
            // Check if the value of the PLC output has changed from false to true since the last reading
            // ie Current flag is false and current PLC output is true
            if (CheckBox_AutoStopper.Checked & !StopperOpenOutputIsOn & currentStopper.PlcOpenOut.Value)
            {
                StopperCloseSensorSignal = false;
                CheckBox_IsClosedSensor_Stopper.Checked = StopperCloseSensorSignal;
                ActuateStopper();
            }
            // Save current value for next comparison
            StopperOpenOutputIsOn = currentStopper.PlcOpenOut.Value;
            UpdateSignalLabel(currentStopper.PlcOpenOut, Label_PlcOpenOut_Stopper);
        }

        private void Update_Label_PlcCloseOut_Stopper()
        {
            //Auto mode. Check if the auto check box is checked
            // Check if the value of the PLC output has changed from false to true since the last reading
            // ie Current flag is false and current PLC output is true
            if(CheckBox_AutoStopper.Checked & !StopperCloseOutputIsOn & currentStopper.PlcCloseOut.Value)
            {
                StopperOpenSensorSignal = false;
                CheckBox_IsOpenSensor_Stopper.Checked = StopperOpenSensorSignal;
                ActuateStopper();
            }
            // Save current value for next comparison
            StopperCloseOutputIsOn = currentStopper.PlcCloseOut.Value;
            UpdateSignalLabel(currentStopper.PlcCloseOut, Label_PlcCloseOut_Stopper);
        }

        private void ActuateStopper()
        {
            // Initialize timer
            stopperTimer.Tick += new EventHandler(StopperTimerProcessor);
            stopperTimer.Interval = stopperActuationWaitTime;
            stopperTimer.Start();
        }

        private void StopperTimerProcessor(Object myObject, EventArgs myEventArgs)
        {
            stopperTimer.Stop();
            // Activate sensor
            //Check if the close signal is active
            if (currentStopper.PlcCloseOut.Value)
            {
                StopperCloseSensorSignal = true;
                CheckBox_IsClosedSensor_Stopper.Checked = StopperCloseSensorSignal;
            }
            // Check if the open signal is active
            else if (currentStopper.PlcOpenOut.Value)
            {
                StopperOpenSensorSignal = true;
                CheckBox_IsOpenSensor_Stopper.Checked = StopperOpenSensorSignal;
            }
        }

        #endregion // stopper operation simulation

        #endregion // Output

        #endregion // Stopper

        #region Bots
        //TODO add bot methods
        #endregion // Bots

        #region FirePreventionShutter
        /// <summary>
        /// Updates the interface with the values of the current Shutter.
        /// </summary>

        #endregion // FirePreventionShutter

        #region Fire Alarm
        // TODO delete if not used.
        /*
        private void CheckBox_FireAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (CoSimulationInstance.AlphaBotSystem.FireAlarm != null)
            {
                CoSimulationInstance.AlphaBotSystem.FireAlarm.IsOnSensor.Value = CheckBox_FireAlarm.Checked;
                // Log action
                string isOn = CheckBox_FireAlarm.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("Fire alarm " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        */
        #endregion // Fire Alarm

        #region Shutter cylinders

        #endregion // Shutter Cylinders

        #region Maintenance area
        //TODO update Maint area methods
        #region Input

        #region Bot HP
        private void CheckBox_BOT_HP_CheckedChanged(object sender, EventArgs e)
        {
            // Prevent Null exceptions when Maintenance area is not present.
            if (CoSimulationInstance.AlphaBotSystem.MaintenanceArea != null)
            {
                CoSimulationInstance.AlphaBotSystem.MaintenanceArea.BotPresent.Value = CheckBox_BOT_HP.Checked;
                // Log action
                string isOn = CheckBox_BOT_HP.Checked ? "not present." : "present.";
                ListBox_Log.Items.Add("BOT in HP " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Bot HP

        #region Contactor

        private void CheckBox_ContactorFdbk_MaintArea_CheckedChanged(object sender, EventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.Contactor.Feedback.Value = 
                CheckBox_ContactorFdbk_MaintArea.Checked;
            if (CheckBox_ContactorFdbk_MaintArea.Checked)
            {
                Label_ContactorFdbk_MaintArea.ForeColor = activeLabelColor;
                Label_ContactorFdbk_MaintArea.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorFdbk_MaintArea.ForeColor = inactiveLabelColor;
                Label_ContactorFdbk_MaintArea.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactor

        #region Key switch
        private void RadioButton_MaintArea_Maint_CheckedChanged(object sender, EventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.KeySwMaint.Value =
                RadioButton_MaintArea_Maint.Checked;
            // If the maintenance mode is selected, uncheck the other radio buttons.
            if (RadioButton_MaintArea_Maint.Checked)
            {
                RadioButton_Ready_Aisle.Checked = false;
                RadioButton_Req_Aisle.Checked = false;
            }
            string isMaint = RadioButton_MaintArea_Maint.Checked ? "Maint" : "not Maint";
            ListBox_Log.Items.Add(currentAisle.Label + " " + isMaint);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion

        #region Stopper control buttons
        private void Btn_OpenStopper_MouseDown(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.StopperOpenBtn.Value = true;
            ListBox_Log.Items.Add("Open stopper btn pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_OpenStopper_MouseUp(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.StopperOpenBtn.Value = false;
            ListBox_Log.Items.Add("Open stopper btn released.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_CloseStopper_MouseDown(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.StopperCloseBtn.Value = true;
            ListBox_Log.Items.Add("Close stopper btn pressed.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void Btn_CloseStopper_MouseUp(object sender, MouseEventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.MaintenanceArea.StopperCloseBtn.Value = false;
            ListBox_Log.Items.Add("Close stopper btn released.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Stopper control buttons

        #endregion // Input

        #region Output

        private void UpdateMaintAreaOutputs()
        {
            Update_Label_ContactorPlcOut_MaintArea();
            Update_Label_BotHPtoCell();
        }

        #region Contactor
        private void Update_Label_ContactorPlcOut_MaintArea()
        {
            string status;
            // Read Plc output
            if (CoSimulationInstance.AlphaBotSystem.MaintenanceArea.Contactor.Output.Value == true)
            {
                status = "ON";
                Label_ContactorPlcOut_MaintArea.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_MaintArea.Font = activeLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorFdbk_MaintArea.Checked = false;
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_MaintArea.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_MaintArea.Font = inactiveLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorFdbk_MaintArea.Checked = true;
            }
            //Update labels
            Label_ContactorPlcOut_MaintArea.Text = status;
        }


        #endregion // Contactor

        #region Bot HP
        private void Update_Label_BotHPtoCell()
        {
            if (CoSimulationInstance.AlphaBotSystem.MaintenanceArea != null)
            {
                // Read Plc output
                bool flag = Utils.ReadRegisterBit(CoSimulationInstance.AlphaBotSystem.MaintenanceArea.BotHPtoCell);
                if (flag)
                {
                    Label_BotHPtoCell.ForeColor = activeLabelColor;
                    Label_BotHPtoCell.Font = activeLabelFont;
                }
                else
                {
                    Label_BotHPtoCell.ForeColor = inactiveLabelColor;
                    Label_BotHPtoCell.Font = inactiveLabelFont;
                }
            }
        }
        #endregion // Bot HP

        #endregion // Output

        #endregion // Maintenance area

        #region SWS

        #endregion // SWS

        #region Global inputs
        private void Btn_BuzzerAck_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                CoSimulationInstance.AlphaBotSystem.BuzzerReset,
                true,
                "Buzzer reset pressed.");
        }

        private void Btn_BuzzerAck_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                CoSimulationInstance.AlphaBotSystem.BuzzerReset,
                false,
                "Buzzer reset released.");
        }

        private void CheckBox_FireAlarm_CheckedChanged(object sender, EventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.FireAlarm.Value = CheckBox_FireAlarm.Checked;
            // Log action
            string isOn = CheckBox_FireAlarm.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add("Fire alarm " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #endregion //Global inputs

        #region Common methods

        // TODO use this method.
        /// <summary>
        /// Update the value of the Zoning command radio buttons based on the values of the current zone.
        /// </summary>
        /// <param name="zone">The current zone (currentAisle, currentDeck, etc.)</param>
        /// <param name="none">The radio button object for the None command</param>
        /// <param name="run">The radio button object for the Run command</param>
        /// <param name="permit">The radio button object for the Permit command</param>
        /// <param name="cancel">The radio button object for the Cancel command</param>
        private void updateZoningRadioButtons(Zone zone, ref RadioButton none,
            ref RadioButton run, ref RadioButton permit, ref RadioButton cancel)
        {
            // Zoning
            switch (zone.Zoning.CellCommand.Value)
            {
                case (byte)Utils.CellCommandValues.None:
                    none.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Run:
                    run.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Permit:
                    permit.Checked = true;
                    break;
                case (byte)Utils.CellCommandValues.Cancel:
                    cancel.Checked = true;
                    break;
                default:
                    Console.WriteLine("The zoning command for " + zone.Label + " was not recognized.");
                    break;
            }
        }

        #region door
        /// <summary>
        /// This only updates the interface based on the current PLCinput. 
        /// Not the other way around.
        /// This is a PLC input that depends on 2 signals.
        /// One is the door closed sensor.
        /// The other is the PLC unlock output.
        /// </summary>
        private void Update_Label_DoorIsLocked(ZoneWithDoor zone, Label label)
        {
            // TODO - Shorten the strings.
            string doorStatus;
            // Read Plc output
            // The door is locked when the door is closed and the unlock output is false.
            // TODO - check the behaviour of this if.
            if (zone.Door.IsDoorClosed & !zone.Door.unlockDoor.Value)
            {
                // Update plc input.
                zone.Door.IsDoorLocked.Value = true;
                label.ForeColor = activeLabelColor;
                label.Font = activeLabelFont;
                doorStatus = "施錠";
            }
            else
            {
                zone.Door.IsDoorLocked.Value = false;
                label.ForeColor = emergencyLabelColor;
                label.Font = emergencyLabelFont;
                doorStatus = "開錠";
            }
            //Update label
            label.Text = doorStatus;
        }

        private void Update_Label_UnlockDoor(ZoneWithDoor zone, Label label)
        {
            string unlockStatus;
            //Read output
            if (zone.Door.unlockDoor.Value)
            {
                label.ForeColor = activeLabelColor;
                label.Font = activeLabelFont;
                unlockStatus = "ON";
            }
            else
            {
                label.ForeColor = inactiveLabelColor;
                label.Font = inactiveLabelFont;
                unlockStatus = "OFF";
            }
            //Update label
            label.Text = "unlock" + unlockStatus;
        }
        #endregion // Door

        /// <summary>
        /// Handles Estop button (checkbox) changes
        /// </summary>
        /// <param name="btn">object to write to</param>
        /// <param name="checkBox">control to read from</param>
        /// <param name="label">associated label</param>
        private void EstopButtonChanged(PlcInput btn, CheckBox checkBox, string label)
        {
            // The E-stop button is Normally Closed, ie True when not pressed.
            btn.Value = !checkBox.Checked;
            // Log action
            string btnStatus = checkBox.Checked ? "pressed." : "released.";
            ListBox_Log.Items.Add(label + " Estop is " + btnStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        /// <summary>
        /// Handles button (reset and request) changes
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="value"></param>
        /// <param name="label"></param>
        private void ButtonChanged(PlcInput btn, bool value, string label)
        {
            btn.Value = value;
            string isPressed = value ? "pressed." : "released.";
            ListBox_Log.Items.Add(label + " button " + isPressed);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void DisplayMaintenanceArea()
        {
            if (!currentAisle.Type.Contains("hasMaintArea"))
                GroupBox_MaintArea.Hide();
            else GroupBox_MaintArea.Show();
        }

        #region Stopper and Shutter Common methods
        private void UpdateSignalLabel(RegisterFromPlc register, Label label, bool isError = false)
        {
            // Read Plc output and update label
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            // Check if the bit is ON.
            if ((currentValue & Utils.SingleBitInWordValues[bitPos]) == Utils.SingleBitInWordValues[bitPos])
            {
                if (!isError)
                {
                    label.ForeColor = activeLabelColor;
                    label.Font = activeLabelFont;
                }
                else
                {
                    label.ForeColor = errorLabelColor;
                    label.Font = errorLabelFont;
                }
            }
            else
            {
                label.ForeColor = inactiveLabelColor;
                label.Font = inactiveLabelFont;
            }
        }

        private void UpdateSignalLabel(PlcOutput output, Label label, bool isError = false)
        {
            // Read Plc output and update label
            if (output.Value)
            {
                if (!isError)
                {
                    label.ForeColor = activeLabelColor;
                    label.Font = activeLabelFont;
                }
                else
                {
                    label.ForeColor = errorLabelColor;
                    label.Font = errorLabelFont;
                }
            }
            else
            {
                label.ForeColor = inactiveLabelColor;
                label.Font = inactiveLabelFont;
            }
        }

        private void UpdateSignalLabel(PlcInput input, Label label, bool isError = false)
        {
            // Read Plc output and update label
            if (input.Value)
            {
                if (!isError)
                {
                    label.ForeColor = activeLabelColor;
                    label.Font = activeLabelFont;
                }
                else
                {
                    label.ForeColor = errorLabelColor;
                    label.Font = errorLabelFont;
                }
            }
            else
            {
                label.ForeColor = inactiveLabelColor;
                label.Font = inactiveLabelFont;
            }
        }

        #endregion // Stopper and Shutter Common methods

        #endregion // Common methods

        #region Unhandled IO
        private void UpdateUnhandledIO()
        {
            // Nothing to do here for now.
        }
        #endregion // Unhandled IO

        private void RadioButton_MaintArea_Aisle_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
