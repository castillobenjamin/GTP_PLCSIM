using Microsoft.Win32;
using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCSIM_Adv_CoSimulation
{
    public partial class CoSimInterface : Form
    {
        #region Fields
        private readonly CoSimulation CoSimulationInstance;
        private Aisle currentAisle;
        private Deck currentDeck;
        private DynamicWorkStation currentDws;
        private Stopper currentStopper;
        private FirePreventionShutter currentShutter;
        // flag for "CELL only" simulation
        private bool isCellOnlySim = false;
        // TODO - Iterate with timer for optimal value
        readonly private int timerInterval = 200;
        // The timer is public so that the main interface can stop it when the simulation is stopped.
        public Timer IOUpdateTimer = new Timer();
        // Counter to simulate the CELL pulse.
        private byte counter = 0;
        /// <summary>
        /// Signals used to simulate the behaviour of the stopper sensors
        /// </summary>
        // NOTE - Currently unused
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

        /// <summary>
        /// CELL Zoning command values.
        /// </summary>
        private enum CellCommandValues : byte
        {
            None = 0,
            Run = 1,
            Permit = 2,
            Cancel = 3
        }

        private enum BooleanSignal : Byte
        {
            False = 0,
            True = 1,
        }

        /// <summary>
        /// Dictionary containing the value of all single bit permutations in a ushort/word variable
        /// The key is the bit position. Range [0 - 15]
        /// </summary>
        private readonly Dictionary<ushort, ushort> SingleBitInWordValues = new Dictionary<ushort, ushort>();
        /// <summary>
        /// Zoning status dictionary.
        /// </summary>
        private readonly Dictionary<int, string> ZoningStatuses = new Dictionary<int, string>();
        /// <summary>
        /// Emergency Stop current step dictionary.
        /// </summary>
        private readonly Dictionary<int, string> CurrentStep = new Dictionary<int, string>();

        //Label config
        readonly Font activeLabelFont = new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Bold);
        readonly Font inactiveLabelFont = new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Strikeout);
        readonly Font errorLabelFont = new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Underline);
        readonly Font emergencyLabelFont = new Font(Label.DefaultFont.FontFamily, (float)9, FontStyle.Bold);
        readonly Color activeLabelColor = Color.Green;
        readonly Color inactiveLabelColor = Color.Gray;
        readonly Color errorLabelColor = Color.Red;
        readonly Color emergencyLabelColor = Color.Orange;

        #endregion // Fields

        #region Initialization
        public CoSimInterface(CoSimulation coSimulationInstance, bool isCellOnlySim)
        {
            InitializeComponent();
            // Add dictionary values
            AddDictionaryValues();
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
        }
        public void AddDictionaryValues()
        {
            // Zoning
            ZoningStatuses.Add(0, "Stop");
            ZoningStatuses.Add(1, "Waiting");
            ZoningStatuses.Add(2, "Requesting");
            ZoningStatuses.Add(3, "Canceling");
            ZoningStatuses.Add(4, "Permit");
            CurrentStep.Add(0, "Wait");
            CurrentStep.Add(1, "Timer On");
            CurrentStep.Add(2, "Timer Out");
            CurrentStep.Add(3, "Cell Execution OK");
            // Bit-wise operations 
            SingleBitInWordValues.Add(0, 0b_0000_0000_0000_0001); //bit 0
            SingleBitInWordValues.Add(1, 0b_0000_0000_0000_0010); //bit 1
            SingleBitInWordValues.Add(2, 0b_0000_0000_0000_0100); //bit 2
            SingleBitInWordValues.Add(3, 0b_0000_0000_0000_1000); //bit 3
            SingleBitInWordValues.Add(4, 0b_0000_0000_0001_0000); //bit 4
            SingleBitInWordValues.Add(5, 0b_0000_0000_0010_0000); //bit 5
            SingleBitInWordValues.Add(6, 0b_0000_0000_0100_0000); //bit 6
            SingleBitInWordValues.Add(7, 0b_0000_0000_1000_0000); //bit 7
            SingleBitInWordValues.Add(8, 0b_0000_0001_0000_0000); //bit 8
            SingleBitInWordValues.Add(9, 0b_0000_0010_0000_0000); //bit 9
            SingleBitInWordValues.Add(10, 0b_0000_0100_0000_0000); //bit 10
            SingleBitInWordValues.Add(11, 0b_0000_1000_0000_0000); //bit 11
            SingleBitInWordValues.Add(12, 0b_0001_0000_0000_0000); //bit 12
            SingleBitInWordValues.Add(13, 0b_0010_0000_0000_0000); //bit 13
            SingleBitInWordValues.Add(14, 0b_0100_0000_0000_0000); //bit 14
            SingleBitInWordValues.Add(15, 0b_1000_0000_0000_0000); //bit 15
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
            // DWS
            CoSimulationInstance.AlphaBotSystem.DynamicWorkStations.ForEach(x =>
            {
                ComboBox_DWS.Items.Add(x.Label);
            });
            ComboBox_DWS.SelectedIndex = 0;
            // Stoppers
            CoSimulationInstance.AlphaBotSystem.Stoppers.ForEach(x =>
            {
                ComboBox_Stoppers.Items.Add(x.Label);
            });
            ComboBox_Stoppers.SelectedIndex = 0;
            // Shutters
            // Shutters are an option
            if(CoSimulationInstance.AlphaBotSystem.FirePreventionShuttersSpecified)
            {
                CoSimulationInstance.AlphaBotSystem.FirePreventionShutters.ForEach(x =>
                {
                    ComboBox_Shutters.Items.Add(x.Label);
                });
                ComboBox_Shutters.SelectedIndex = 0;
            }
        }
        private void InitializeControls()
        {
            // Set text boxes as read only
            TextBox_ZoningStatus_Aisle.ReadOnly = true;
            TextBox_ZoningStatus_Deck.ReadOnly = true;
            TextBox_ZoningStatus_DWS.ReadOnly = true;
            // Shutter cylinders check box
            CheckBox_CylinderPressure.Checked = true;
        }
        private void InitializeFields()
        {
            currentAisle = CoSimulationInstance.AlphaBotSystem.Aisles[ComboBox_Aisles.SelectedIndex];
            currentDeck = CoSimulationInstance.AlphaBotSystem.Decks[ComboBox_Decks.SelectedIndex];
            currentDws = CoSimulationInstance.AlphaBotSystem.DynamicWorkStations[ComboBox_DWS.SelectedIndex];
            currentStopper = CoSimulationInstance.AlphaBotSystem.Stoppers[ComboBox_Stoppers.SelectedIndex];
            if (CoSimulationInstance.AlphaBotSystem.FirePreventionShuttersSpecified)
            {
                currentShutter = CoSimulationInstance.AlphaBotSystem.FirePreventionShutters[ComboBox_Shutters.SelectedIndex];
            }
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintAreaSpecified)
            {
                InitializeEvacMaintArea();
            }
        }
        private void InitializeEvacMaintArea()
        {
            RadioButton_DoorClosed_EvacMaintArea.Checked = 
                CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorOpen_EvacMaintArea.Checked = 
                !CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorLocked_EvacMaintArea.Checked = 
                CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorLockedKeySwitch.Value;
            RadioButton_DoorUnlocked_EvacMaintArea.Checked = 
                !CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorLockedKeySwitch.Value;
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorReadyInputSpecified)
            {
                RadioButton_DoorNotReady_MaintArea.Checked =
                    !CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorReadyInput.Value;
                RadioButton_DoorReady_MaintArea.Checked =
                    CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorReadyInput.Value;
            }
        }
        /// <summary>
        /// Hides controls that are not used for the current configuration
        /// </summary>
        private void HideControls(bool isCellOnlySim)
        {
            // Assume the configuration of all decks in a given system is the same, so we only need to check for one of them
            if (!currentDeck.ScaffoldSpecified)
            {
                GroupBox_Scaffold_Deck.Hide();
            }
            // Hide evacuation/maintenance area controls
            if (!CoSimulationInstance.AlphaBotSystem.EvacAndMaintAreaSpecified)
            {
                GroupBox_EvacAndMaintArea.Hide();
            }
            if (!CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.ScaffoldSpecified)
            {
                GroupBox_Scaffold_EvacAndMaintArea.Hide();
            }
            // Hide Fire prevention shutter controls
            if (!CoSimulationInstance.AlphaBotSystem.FirePreventionShuttersSpecified)
            {
                Group_FireShutter.Hide();
            }
            // Hide Fire alarm
            if (!CoSimulationInstance.AlphaBotSystem.FireAlarmSpecified)
            {
                CheckBox_FireAlarm.Hide();
            }
            // Hide Cyl pressure
            if (!CoSimulationInstance.AlphaBotSystem.ShutterCylindersSpecified)
            {
                CheckBox_CylinderPressure.Hide();
            }
            // Hide DoorIsReady input
            if (!currentDeck.Door.IsDoorReadyInputSpecified)
            {
                groupBox_DoorReady_Deck.Hide();
            }
            if (!currentAisle.Door.IsDoorReadyInputSpecified)
            {
                groupBox_DoorReady_Aisle.Hide();
            }
            if (!CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorReadyInputSpecified)
            {
                groupBox_DoorReady_EvacMaintArea.Hide();
            }
            // Hide covers input
            if (!currentDws.CoversSpecified)
            {
                CheckBox_DWSCovers.Hide();
            }
            // Hide IO controls when "CELL Only" option is checked
            if (isCellOnlySim)
            {
                // Aisle
                GroupBox_OpBox_Aisle.Hide();
                GroupBox_Door_Aisle.Hide();
                GroupBox_Scaffold_Aisle.Hide();
                Label_ContactorPlcOut_AisleNorth.Hide();
                Label_ContactorPlcIn_AisleNorth.Hide();
                CheckBox_ContactorPlcIn_AisleNorth.Hide();
                Label_ContactorPlcOut_AisleSouth.Hide();
                Label_ContactorPlcIn_AisleSouth.Hide();
                CheckBox_ContactorPlcIn_AisleSouth.Hide();
                // Deck
                GroupBox_OpBox_Deck.Hide();
                GroupBox_Door_Deck.Hide();
                GroupBox_Scaffold_Deck.Hide();
                // DWS
                CheckBox_EstopBtn_DWS.Hide();
                CheckBox_DWSCovers.Hide();
                Label_ContactorPlcOut_DWS.Hide();
                Label_ContactorPlcIn_DWS.Hide();
                CheckBox_ContactorPlcIn_DWS.Hide();
                // Other areas
                GroupBox_Panels.Hide();
                GroupBox_SWS.Hide();
                GroupBox_Door_EvacAndMaintArea.Hide();
                GroupBox_Scaffold_EvacAndMaintArea.Hide();
                GroupBox_Sensor_Shutter.Hide();
                GroupBox_Q_Shutter.Hide();
                GroupBox_Sensor_Stopper.Hide();
                GroupBox_Q_Stopper.Hide();
                CheckBox_EstopBtn_EvacMaintArea.Hide();
                Label_ContactorPlcOut_EvacMaintArea.Hide();
                Label_ContactorPlcIn_EvacMaintArea.Hide();
                CheckBox_ContactorPlcIn_EvacMaintArea.Hide();
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
            SimulateIsCellConnectedPulse();
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
            if (MainInterface.PlcInstance.OperatingState().Equals("Run") || isCellOnlySim)
            {
                UpdateAisleOutputs();
                UpdateDeckOutputs();
                UpdateDwsOutputs();
                UpdateStopperOutputs();
                UpdateShutterOutputs();
                UpdateEvacAndMaintAreaOutputs();
                // Unique controls
                Update_Label_CELLcomm_PlcStatus();
                Update_ColorLabel_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.DwsPanel);
                Update_Label_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.NorthPanel, Label_LedTower_NorthPanel);
                Update_Label_LedTower(CoSimulationInstance.AlphaBotSystem.PanelSection.SouthPanel, Label_LedTower_SouthPanel);
                Update_Label_Scaffold_MaintArea();
                // Cuurrently unhandled IO
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
            // TODO - Need to change to ushort type
            switch (currentAisle.Zoning.CellCommand.Value)
            {
                case (byte)CellCommandValues.None:
                    RadioButton_None_Aisle.Checked = true;
                    break;
                case (byte)CellCommandValues.Run:
                    RadioButton_Run_Aisle.Checked = true;
                    break;
                case (byte)CellCommandValues.Permit:
                    RadioButton_Permit_Aisle.Checked = true;
                    break;
                case (byte)CellCommandValues.Cancel:
                    RadioButton_Cancel_Aisle.Checked = true;
                    break;
                default:
                    Console.WriteLine("Cell command value not recognized Aisle.");
                    break;
            }

            // Door
            RadioButton_DoorClosed_Aisle.Checked = currentAisle.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorOpen_Aisle.Checked = !currentAisle.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorLocked_Aisle.Checked = currentAisle.Door.IsDoorLockedKeySwitch.Value;
            RadioButton_DoorUnlocked_Aisle.Checked = !currentAisle.Door.IsDoorLockedKeySwitch.Value;
            if (currentAisle.Door.IsDoorReadyInputSpecified)
            {
                RadioButton_DoorReady_Aisle.Checked = currentAisle.Door.IsDoorReadyInput.Value;
                RadioButton_DoorNotReady_Aisle.Checked = !currentAisle.Door.IsDoorReadyInput.Value;
            }

            // Emergency stop
            // bool flag = currentAisle.EmergencyStopZone.CellIsCompleteFlag.Value == (byte)BooleanSignal.True;
            bool flag = ReadRegisterBit(currentAisle.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_CellIsCompleteFlag_Aisle.Checked = flag;

            // Scaffolds
            CheckBox_Scaffold_AisleNorth.Checked = currentAisle.Scaffolds[0].Value;
            CheckBox_Scaffold_AisleSouth.Checked = currentAisle.Scaffolds[1].Value;

            // Contactors
            // flagOnOff = currentAisle.Contactors[1].ContactorOnOffCommand.Value == (byte)BooleanSignal.True;
            bool flagOnOff = ReadRegisterBit(currentAisle.Contactors[0].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_AisleNorth.Checked = flagOnOff;
            flagOnOff = ReadRegisterBit(currentAisle.Contactors[1].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_AisleSouth.Checked = flagOnOff;
            CheckBox_ContactorPlcIn_AisleNorth.Checked = currentAisle.Contactors[0].ContactorFeedback.Value;
            CheckBox_ContactorPlcIn_AisleSouth.Checked = currentAisle.Contactors[1].ContactorFeedback.Value;

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

        #region Request btn
        private void Btn_Request_Aisle_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.RequestBtn,
                true,
                currentAisle.Label + " Request");
        }

        private void Btn_Request_Aisle_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentAisle.OperationBox.RequestBtn,
                false,
                currentAisle.Label + " Request");
        }
        #endregion // Request btn

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_Aisle.Checked)
            {
                if (CheckBox_AllAisles.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                        aisle.Zoning.CellCommand.Value = (byte)CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)CellCommandValues.None;
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
                        aisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit;
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
                        aisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Run;
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
                        aisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All Aisles updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentAisle.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel;
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
                    aisle.Door.IsDoorClosedSensor.Value = RadioButton_DoorClosed_Aisle.Checked;
                });
                string isClosed = RadioButton_DoorClosed_Aisle.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add("All Aisle Doors are " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                //The door sensor is Normally Closed, ie True when closed.
                currentAisle.Door.IsDoorClosedSensor.Value = RadioButton_DoorClosed_Aisle.Checked;
                string isClosed = RadioButton_DoorClosed_Aisle.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add(currentAisle.Label + " Door is " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void RadioButton_DoorLocked_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.Door.IsDoorLockedKeySwitch.Value = RadioButton_DoorLocked_Aisle.Checked;
                });
                string isLocked = RadioButton_DoorLocked_Aisle.Checked ? "Locked" : "Unlocked";
                ListBox_Log.Items.Add("All Aisle Doors are " + isLocked);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                //The key lock is NC, ie True when locked.
                currentAisle.Door.IsDoorLockedKeySwitch.Value = RadioButton_DoorLocked_Aisle.Checked;
                string isLocked = RadioButton_DoorLocked_Aisle.Checked ? "Locked" : "Unlocked";
                ListBox_Log.Items.Add(currentAisle.Label + " Door is " + isLocked);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void RadioButton_DoorReady_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.Door.IsDoorReadyInput.Value = RadioButton_DoorReady_Aisle.Checked;
                });
                string isReady = RadioButton_DoorReady_Aisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All Aisle Doors are " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.Door.IsDoorReadyInput.Value = RadioButton_DoorReady_Aisle.Checked;
                string isReady = RadioButton_DoorReady_Aisle.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentAisle.Label + " Door is " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Door

        #region Emergency stop
        private void CheckBox_CellIsCompleteFlag_Aisle_CheckedChanged(object sender, EventArgs e)
        {
            // Write byte
            RegisterToPlc currentRegister = currentAisle.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                UpdateRegister(currentRegister, CheckBox_CellIsCompleteFlag_Aisle.Checked);
            // Log action
            string isComplete = CheckBox_CellIsCompleteFlag_Aisle.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentAisle.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #region Scaffolds
        private void CheckBox_Scaffold_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            // The scaffold sensor is True for normal operation
            // Assume Northern scaffold has index 0 and Southern scaffold has index 1.
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.Scaffolds[0].Value = CheckBox_Scaffold_AisleNorth.Checked;
                });
                // Log action
                string isOn = CheckBox_Scaffold_AisleNorth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("All North scaffolds " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.Scaffolds[0].Value = CheckBox_Scaffold_AisleNorth.Checked;
                // Log action
                string isOn = CheckBox_Scaffold_AisleNorth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add(currentAisle.Label + " North scaffold " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void CheckBox_Scaffold_AisleSouth_CheckedChanged(object sender, EventArgs e)
        {
            // The scaffold sensor is True for normal operation
            // Assume Northern scaffold has index 0 and Southern scaffold has index 1.
            if (CheckBox_AllAisles.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Aisles.ForEach(aisle =>
                {
                    aisle.Scaffolds[1].Value = CheckBox_Scaffold_AisleSouth.Checked;
                });
                // Log action
                string isOn = CheckBox_Scaffold_AisleSouth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("All South scaffolds " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentAisle.Scaffolds[1].Value = CheckBox_Scaffold_AisleSouth.Checked;
                // Log action
                string isOn = CheckBox_Scaffold_AisleSouth.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add(currentAisle.Label + " South scaffold " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Scaffolds

        #region Contactors
        private void CheckBox_ContactorOnOff_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            // Assume Northern contactor has index 0 and Southern contactor has index 1.
            RegisterToPlc currentRegister = currentAisle.Contactors[0].ContactorOnOffCommand;
            currentRegister.Value =
                UpdateRegister(currentRegister, CheckBox_ContactorOnOff_AisleNorth.Checked);
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
                UpdateRegister(currentRegister, CheckBox_ContactorOnOff_AisleSouth.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_AisleSouth.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentAisle.Label + " South contactor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        private void CheckBox_ContactorPlcIn_AisleNorth_CheckedChanged(object sender, EventArgs e)
        {
            currentAisle.Contactors[0].ContactorFeedback.Value = CheckBox_ContactorPlcIn_AisleNorth.Checked;
            if (CheckBox_ContactorPlcIn_AisleNorth.Checked)
            {
                Label_ContactorPlcIn_AisleNorth.ForeColor = activeLabelColor;
                Label_ContactorPlcIn_AisleNorth.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcIn_AisleNorth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcIn_AisleNorth.Font = inactiveLabelFont;
            }
        }
        private void CheckBox_ContactorPlcIn_AisleSouth_CheckedChanged(object sender, EventArgs e)
        {
            currentAisle.Contactors[1].ContactorFeedback.Value = CheckBox_ContactorPlcIn_AisleSouth.Checked;
            if (CheckBox_ContactorPlcIn_AisleSouth.Checked)
            {
                Label_ContactorPlcIn_AisleSouth.ForeColor = activeLabelColor;
                Label_ContactorPlcIn_AisleSouth.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcIn_AisleSouth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcIn_AisleSouth.Font = inactiveLabelFont;
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
            Update_Label_Scaffold_AisleNorth();
            Update_Label_Scaffold_AisleSouth();
            Update_Label_ContactorPlcOut_AisleNorth();
            Update_Label_ContactorPlcOut_AisleSouth();
        }
        private void Update_Label_OpBoxLed_Aisle()
        {
            string ledStatus;
            // Read Plc output
            if (currentAisle.OperationBox.ZoningStatusLed.Value == true)
            {
                Label_OpBoxLed_Aisle.ForeColor= activeLabelColor;
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
            // TODO - mysterious bug appeared here. Fix
            byte status = GetLowerByte(currentAisle.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_Aisle.Text = ZoningStatuses[status];
        }
        private void Update_Label_PlcStopRequest_Aisle()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentAisle.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_PlcStopRequest_Aisle.ForeColor = activeLabelColor;
                Label_PlcStopRequest_Aisle.Font = activeLabelFont;
            }
            else
            {
                Label_PlcStopRequest_Aisle.ForeColor = inactiveLabelColor;
                Label_PlcStopRequest_Aisle.Font = inactiveLabelFont;
            }
        }
        private void Update_Label_PlcIsStopStatus_Aisle()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentAisle.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_PlcIsStopStatus_Aisle.ForeColor = activeLabelColor;
                Label_PlcIsStopStatus_Aisle.Font = activeLabelFont;
            }
            else
            {
                Label_PlcIsStopStatus_Aisle.ForeColor = inactiveLabelColor;
                Label_PlcIsStopStatus_Aisle.Font = inactiveLabelFont;
            }
        }

        #region Scaffolds
        private void Update_Label_Scaffold_AisleNorth()
        {
            // Read PLC input
            string status;
            if(currentAisle.Scaffolds[0].Value)
            {
                status = "ON";
                Label_Scaffold_AisleNorth.ForeColor = activeLabelColor;
                Label_Scaffold_AisleNorth.Font = activeLabelFont;
            }
            else
            {
                status = "OFF";
                Label_Scaffold_AisleNorth.ForeColor = inactiveLabelColor;
                Label_Scaffold_AisleNorth.Font = inactiveLabelFont;
            }
            //Update label
            Label_Scaffold_AisleNorth.Text = "is " + status;
        }

        private void Update_Label_Scaffold_AisleSouth()
        {
            // Read PLC input
            string status;
            if (currentAisle.Scaffolds[1].Value)
            {
                status = "ON";
                Label_Scaffold_AisleSouth.ForeColor = activeLabelColor;
                Label_Scaffold_AisleSouth.Font = activeLabelFont;
            }
            else
            {
                status = "OFF";
                Label_Scaffold_AisleSouth.ForeColor = inactiveLabelColor;
                Label_Scaffold_AisleSouth.Font = inactiveLabelFont;
            }
            //Update label
            Label_Scaffold_AisleSouth.Text = "is " + status;
        }
        #endregion // Scaffolds

        #region Contactors
        private void Update_Label_ContactorPlcOut_AisleNorth()
        {
            string status;
            // Read Plc output
            if (currentAisle.Contactors[0].ContactorOutput.Value == true)
            {
                // TODO - make sure this logic is ok with the PLC
                status = "ON";
                Label_ContactorPlcOut_AisleNorth.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_AisleNorth.Font = activeLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_AisleNorth.Checked = false;
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_AisleNorth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_AisleNorth.Font = inactiveLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_AisleNorth.Checked = true;
            }
            //Update labels
            Label_ContactorPlcOut_AisleNorth.Text = "Ctor " + status;
        }
        private void Update_Label_ContactorPlcOut_AisleSouth()
        {
            string status;
            // Read PLC output
            if (currentAisle.Contactors[1].ContactorOutput.Value == true) 
            {
                // TODO - make sure this logic is ok with the PLC
                status = "ON";
                Label_ContactorPlcOut_AisleSouth.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_AisleSouth.Font = activeLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_AisleSouth.Checked = false;
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_AisleSouth.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_AisleSouth.Font = inactiveLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_AisleSouth.Checked = true;
            }
            //Update labels
            Label_ContactorPlcOut_AisleSouth.Text = "Ctor " + status;
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
            switch (currentDeck.Zoning.CellCommand.Value)
            {
                case (byte)CellCommandValues.None:
                    RadioButton_None_Deck.Checked = true;
                    break;
                case (byte)CellCommandValues.Run:
                    RadioButton_Run_Deck.Checked = true;
                    break;
                case (byte)CellCommandValues.Permit:
                    RadioButton_Permit_Deck.Checked = true;
                    break;
                case (byte)CellCommandValues.Cancel:
                    RadioButton_Cancel_Deck.Checked = true;
                    break;
                default:
                    Console.WriteLine("Cell command value not recognized Deck.");
                    break;
            }

            // Door
            RadioButton_DoorClosed_Deck.Checked = currentDeck.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorOpen_Deck.Checked = !currentDeck.Door.IsDoorClosedSensor.Value;
            RadioButton_DoorLocked_Deck.Checked = currentDeck.Door.IsDoorLockedKeySwitch.Value;
            RadioButton_DoorUnlocked_Deck.Checked = !currentDeck.Door.IsDoorLockedKeySwitch.Value;
            if (currentDeck.Door.IsDoorReadyInputSpecified)
            {
                RadioButton_DoorReady_Deck.Checked = currentDeck.Door.IsDoorReadyInput.Value;
                RadioButton_DoorNotReady_Deck.Checked = !currentDeck.Door.IsDoorReadyInput.Value;
            }

            // Emergency stop
            bool flag = ReadRegisterBit(currentDeck.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_CellIsCompleteFlag_Deck.Checked = flag;

            // Scaffold
            if (currentDeck.ScaffoldSpecified)
            {
                CheckBox_Scaffold_Deck.Checked = currentDeck.Scaffold.Value;
            }

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
                currentDeck.OperationBox.RequestBtn,
                true,
                currentDeck.Label + " Request");
        }
        private void Btn_Request_Deck_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonChanged(
                currentDeck.OperationBox.RequestBtn,
                false,
                currentDeck.Label + " Request");
        }
        #endregion // Request btn

        #endregion // Opbox

        #region Zoning
        private void RadioButton_None_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_Deck.Checked)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Zoning.CellCommand.Value = (byte)CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)CellCommandValues.None;
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
                        deck.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit;
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
                        deck.Zoning.CellCommand.Value = (byte)CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)CellCommandValues.Run;
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
                        deck.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All Decks updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel;
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
                    deck.Door.IsDoorClosedSensor.Value = RadioButton_DoorClosed_Deck.Checked);
                // Log
                string isClosed = RadioButton_DoorClosed_Deck.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add("All Deck Doors are " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentDeck.Door.IsDoorClosedSensor.Value = RadioButton_DoorClosed_Deck.Checked;
                // Log
                string isClosed = RadioButton_DoorClosed_Deck.Checked ? "Closed" : "Open";
                ListBox_Log.Items.Add(currentDeck.Label + " Door is " + isClosed);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_DoorLocked_Deck_CheckedChanged(object sender, EventArgs e)
        {
            // The key lock is NC, ie True when locked.
            if (CheckBox_AllDecks.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                    deck.Door.IsDoorLockedKeySwitch.Value = RadioButton_DoorLocked_Deck.Checked);
                // Log
                string isLocked = RadioButton_DoorLocked_Deck.Checked ? "Locked" : "Unlocked";
                ListBox_Log.Items.Add("All Deck Doors are " + isLocked);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentDeck.Door.IsDoorLockedKeySwitch.Value = RadioButton_DoorLocked_Deck.Checked;
                // Log
                string isLocked = RadioButton_DoorLocked_Deck.Checked ? "Locked" : "Unlocked";
                ListBox_Log.Items.Add(currentDeck.Label + " Door is " + isLocked);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }

        private void RadioButton_DoorReady_Deck_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllDecks.Checked)
            {
                CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                    deck.Door.IsDoorReadyInput.Value = RadioButton_DoorReady_Deck.Checked);
                // Log
                string isReady = RadioButton_DoorReady_Deck.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add("All Deck Doors are " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
            else
            {
                currentDeck.Door.IsDoorReadyInput.Value = RadioButton_DoorReady_Deck.Checked;
                string isReady = RadioButton_DoorReady_Deck.Checked ? "Ready" : "Not Ready";
                ListBox_Log.Items.Add(currentDeck.Label + " Door is " + isReady);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Door

        #region Scaffold
        private void CheckBox_Scaffold_Deck_CheckedChanged(object sender, EventArgs e)
        {
            // The scaffold sensor is True for normal operation
            // Prevent Null exceptions when Scaffold is not present.
            if (currentDeck.Scaffold != null)
            {
                if (CheckBox_AllDecks.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.Decks.ForEach(deck =>
                        deck.Scaffold.Value = CheckBox_Scaffold_Deck.Checked);
                    // Log action
                    string isOn = CheckBox_Scaffold_Deck.Checked ? "detected." : "not detected.";
                    ListBox_Log.Items.Add("All Deck scaffolds " + isOn);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDeck.Scaffold.Value = CheckBox_Scaffold_Deck.Checked;
                    // Log action
                    string isOn = CheckBox_Scaffold_Deck.Checked ? "detected." : "not detected.";
                    ListBox_Log.Items.Add(currentDeck.Label + " scaffold " + isOn);
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Scaffold

        #region Emergency stop
        private void CheckBox_CellIsCompleteFlag_Deck_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = currentDeck.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                UpdateRegister(currentRegister, CheckBox_CellIsCompleteFlag_Deck.Checked);
            // Log action
            string isComplete = CheckBox_CellIsCompleteFlag_Deck.Checked ? "complete" : " incomplete";
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
            Update_Label_Scaffold_Deck();
            Update_Label_PlcStopRequest_Deck();
            Update_Label_PlcIsStopStatus_Deck();
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
            byte status = GetLowerByte(currentDeck.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_Deck.Text = ZoningStatuses[status];
        }
        private void Update_Label_Scaffold_Deck()
        {
            if (currentDeck.Scaffold != null)
            {
                // Read PLC input
                string status;
                if (currentDeck.Scaffold.Value)
                {
                    status = "ON";
                    Label_Scaffold_Deck.ForeColor = activeLabelColor;
                    Label_Scaffold_Deck.Font = activeLabelFont;
                    Label_Scaffold_Deck.ForeColor = activeLabelColor;
                    Label_Scaffold_Deck.Font = activeLabelFont;
                }
                else
                {
                    status = "OFF";
                    Label_Scaffold_Deck.ForeColor = inactiveLabelColor;
                    Label_Scaffold_Deck.Font = inactiveLabelFont;
                    Label_Scaffold_Deck.ForeColor = inactiveLabelColor;
                    Label_Scaffold_Deck.Font = inactiveLabelFont;
                }
                //Update label
                Label_Scaffold_Deck.Text = "is " + status;
            }
        }
        private void Update_Label_PlcStopRequest_Deck()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentDeck.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_PlcStopRequest_Deck.ForeColor = activeLabelColor;
                Label_PlcStopRequest_Deck.Font = activeLabelFont;
            }
            else
            {
                Label_PlcStopRequest_Deck.ForeColor = inactiveLabelColor;
                Label_PlcStopRequest_Deck.Font = inactiveLabelFont;
            }
        }
        private void Update_Label_PlcIsStopStatus_Deck()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentDeck.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_PlcIsStopStatus_Deck.ForeColor = activeLabelColor;
                Label_PlcIsStopStatus_Deck.Font = activeLabelFont;
            }
            else
            {
                Label_PlcIsStopStatus_Deck.ForeColor = inactiveLabelColor;
                Label_PlcIsStopStatus_Deck.Font = inactiveLabelFont;
            }
        }

        #endregion // Output

        #endregion // Deck

        #region DWS
        /// <summary>
        /// Updates the interface with the values of the current DWS.
        /// </summary>
        private void UpdateDwsInteface()
        {
            #region Inputs
            // Estop button
            // Checkbox value = NOT(Emergency btn value)
            CheckBox_EstopBtn_DWS.Checked = !currentDws.EmergencyBtn.Value;

            // Covers
            // Pick an arbitrary cover to assign to the checkbox (All covers are updated equally)
            if (currentDws.CoversSpecified)
            {
                CheckBox_DWSCovers.Checked = currentDws.Covers[0].Value;
            }

            // Zoning
            switch (currentDws.Zoning.CellCommand.Value)
            {
                case (byte)CellCommandValues.None:
                    RadioButton_None_DWS.Checked = true;
                    break;
                case (byte)CellCommandValues.Run:
                    RadioButton_Run_DWS.Checked = true;
                    break;
                case (byte)CellCommandValues.Permit:
                    RadioButton_Permit_DWS.Checked = true;
                    break;
                case (byte)CellCommandValues.Cancel:
                    RadioButton_Cancel_DWS.Checked = true;
                    break;
                default:
                    Console.WriteLine("Cell command value not recognized DWS.");
                    break;
            }

            // Emergency stop
            bool flag = ReadRegisterBit(currentDws.EmergencyStopZone.CellIsCompleteFlag);
            CheckBox_CellIsCompleteFlag_DWS.Checked = flag;

            // Contactor
            bool flagOnOff = ReadRegisterBit(currentAisle.Contactors[0].ContactorOnOffCommand);
            CheckBox_ContactorOnOff_DWS.Checked = flagOnOff;
            CheckBox_ContactorPlcIn_DWS.Checked = currentDws.Contactor.ContactorFeedback.Value;

            #endregion // Inputs

            #region Outputs
            // Update outputs
            UpdateDwsOutputs();
            #endregion// Outputs

            // Log
            ListBox_Log.Items.Add("Interface updated. Now displaying " + currentDws.Label + " data.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #region Input
        private void ComboBox_DWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the DWS List.
            currentDws = CoSimulationInstance.AlphaBotSystem.DynamicWorkStations[ComboBox_DWS.SelectedIndex];
            // When the selected dws changes, update aisle interface with the new dws data
            UpdateDwsInteface();
        }
        private void CheckBox_EstopBtn_DWS_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                currentDws.EmergencyBtn,
                CheckBox_EstopBtn_DWS,
                currentDws.Label);
        }
        private void CheckBox_DWSCovers_CheckedChanged(object sender, EventArgs e)
        {
            if(currentDws.Covers != null)
            {
                currentDws.Covers.ForEach(cover =>
                {
                    cover.Value = CheckBox_DWSCovers.Checked;
                });
                // Log action
                string isOn = CheckBox_DWSCovers.Checked ? "ON." : "OFF.";
                ListBox_Log.Items.Add( " covers are " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void CheckBox_AllDWS_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AllDWS.Checked)
                CheckBox_AllDWS.ForeColor = Color.Red;
            else
                CheckBox_AllDWS.ForeColor = Color.Black;
        }

        #region Zoning
        private void RadioButton_None_DWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_None_DWS.Checked)
            {
                if (CheckBox_AllDWS.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.DynamicWorkStations.ForEach(dws =>
                        dws.Zoning.CellCommand.Value = (byte)CellCommandValues.None);
                    // Log
                    ListBox_Log.Items.Add("All DWS updated. None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDws.Zoning.CellCommand.Value = (byte)CellCommandValues.None;
                    // Log
                    ListBox_Log.Items.Add(currentDws.Label + " None is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Permit_DWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Permit_DWS.Checked)
            {
                if (CheckBox_AllDWS.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.DynamicWorkStations.ForEach(dws =>
                        dws.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit);
                    // Log
                    ListBox_Log.Items.Add("All DWS updated. Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDws.Zoning.CellCommand.Value = (byte)CellCommandValues.Permit;
                    // Log
                    ListBox_Log.Items.Add(currentDws.Label + " Permit is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Run_DWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Run_DWS.Checked)
            {
                if (CheckBox_AllDWS.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.DynamicWorkStations.ForEach(dws =>
                        dws.Zoning.CellCommand.Value = (byte)CellCommandValues.Run);
                    // Log
                    ListBox_Log.Items.Add("All DWS updated. Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDws.Zoning.CellCommand.Value = (byte)CellCommandValues.Run;
                    // Log
                    ListBox_Log.Items.Add(currentDws.Label + " Run is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        private void RadioButton_Cancel_DWS_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cancel_DWS.Checked)
            {
                if (CheckBox_AllDWS.Checked)
                {
                    CoSimulationInstance.AlphaBotSystem.DynamicWorkStations.ForEach(dws =>
                        dws.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel);
                    // Log
                    ListBox_Log.Items.Add("All DWS updated. Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
                else
                {
                    currentDws.Zoning.CellCommand.Value = (byte)CellCommandValues.Cancel;
                    // Log
                    ListBox_Log.Items.Add(currentDws.Label + " Cancel is Checked.");
                    ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
                }
            }
        }
        #endregion // Zoning

        #region Emergency stop
        private void CheckBox_CellIsCompleteFlag_DWS_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = currentDws.EmergencyStopZone.CellIsCompleteFlag;
            currentRegister.Value =
                UpdateRegister(currentRegister, CheckBox_CellIsCompleteFlag_DWS.Checked);
            // Log action
            string isComplete = CheckBox_CellIsCompleteFlag_DWS.Checked ? "complete" : " incomplete";
            ListBox_Log.Items.Add(currentDws.Label + " Cell flag is marked as " + isComplete);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        #endregion // Emergency stop

        #region Contactor
        private void CheckBox_ContactorOnOff_DWS_CheckedChanged(object sender, EventArgs e)
        {
            RegisterToPlc currentRegister = currentDws.Contactor.ContactorOnOffCommand;
            currentRegister.Value =
                UpdateRegister(currentRegister, CheckBox_ContactorOnOff_DWS.Checked);
            // Log action
            string isOn = CheckBox_ContactorOnOff_DWS.Checked ? "ON." : "OFF.";
            ListBox_Log.Items.Add(currentDws.Label + " contactor " + isOn);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }
        private void CheckBox_ContactorPlcIn_DWS_CheckedChanged(object sender, EventArgs e)
        {
            currentDws.Contactor.ContactorFeedback.Value = CheckBox_ContactorPlcIn_DWS.Checked;
            if (CheckBox_ContactorPlcIn_DWS.Checked)
            {
                Label_ContactorPlcIn_DWS.ForeColor = activeLabelColor;
                Label_ContactorPlcIn_DWS.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcIn_DWS.ForeColor = inactiveLabelColor;
                Label_ContactorPlcIn_DWS.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactor

        #endregion // Input

        #region Output
        private void UpdateDwsOutputs()
        {
            Update_TextBox_ZoningStatus_DWS();
            Update_Label_ContactorPlcOut_DWS();
            Update_Label_PlcStopRequest_DWS();
            Update_Label_PlcIsStopStatus_DWS();
        }

        private void Update_TextBox_ZoningStatus_DWS()
        {
            byte status = GetLowerByte(currentDws.Zoning.ZoningStatus.Value);
            TextBox_ZoningStatus_DWS.Text = ZoningStatuses[status];
        }
        private void Update_Label_ContactorPlcOut_DWS()
        {
            string status;
            // Read Plc output
            if (currentDws.Contactor.ContactorOutput.Value == true)
            {
                // TODO - make sure this logic is ok with the PLC
                status = "ON";
                Label_ContactorPlcOut_DWS.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_DWS.Font = activeLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_DWS.Checked = false;
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_DWS.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_DWS.Font = inactiveLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_DWS.Checked = true;
            }
            //Update labels
            Label_ContactorPlcOut_DWS.Text = "Ctor " + status;
        }
        private void Update_Label_PlcStopRequest_DWS()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentDws.EmergencyStopZone.PlcStopRequest);
            if (flag)
            {
                Label_PlcStopRequest_DWS.ForeColor = activeLabelColor;
                Label_PlcStopRequest_DWS.Font = activeLabelFont;
            }
            else
            {
                Label_PlcStopRequest_DWS.ForeColor = inactiveLabelColor;
                Label_PlcStopRequest_DWS.Font = inactiveLabelFont;
            }
        }
        private void Update_Label_PlcIsStopStatus_DWS()
        {
            // Read Plc output
            bool flag = ReadRegisterBit(currentDws.EmergencyStopZone.PlcIsStopStatus);
            if (flag)
            {
                Label_PlcIsStopStatus_DWS.ForeColor = activeLabelColor;
                Label_PlcIsStopStatus_DWS.Font = activeLabelFont;
            }
            else
            {
                Label_PlcIsStopStatus_DWS.ForeColor = inactiveLabelColor;
                Label_PlcIsStopStatus_DWS.Font = inactiveLabelFont;
            }
        }
        #endregion // Output
        #endregion // DWS

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
        private void SimulateIsCellConnectedPulse()
        {
            if (CheckBox_IsCellConnectedPulse.Checked)
            {
                if (counter == byte.MaxValue)
                    counter = byte.MinValue;
                else
                    counter += 1;
                // Console.WriteLine("Cell pulse: " + counter);
                CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.IsCellConnectedPulse.Value = counter;
            }
        }
        #region Reset btn
        private void Btn_ResetFromCell_MouseDown(object sender, MouseEventArgs e)
        {
            ushort bitPos = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.ResetFromCell.BitPosition;
            CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.ResetFromCell.Value = SingleBitInWordValues[bitPos];
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
                (ushort)(RadioButton_CanSystemStartUp.Checked ? SingleBitInWordValues[bitPos] : 0);
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
                (ushort)(RadioButton_SystemIsStartingUp.Checked ? SingleBitInWordValues[bitPos] : 0);
        }
        #endregion // Radio buttons
        #endregion // CELL side

        #region PLC side

        private void Update_Label_CELLcomm_PlcStatus()
        {
            string plcStatus;
            RegisterFromPlc currentErrorRegister = CoSimulationInstance.AlphaBotSystem.CellCommunicationInstance.PlcHasError;
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
            if ((currentErrorStatus & SingleBitInWordValues[errorBitPos]) != 0)
            {
                plcStatus = "Error";
                Label_CELLcomm_PlcStatus.ForeColor = errorLabelColor;
                Label_CELLcomm_PlcStatus.Font = errorLabelFont;
            }
            else if ((currentMode & SingleBitInWordValues[modeBitPos]) != 0)
            {
                plcStatus = "Warning";
                Label_CELLcomm_PlcStatus.ForeColor = emergencyLabelColor;
                Label_CELLcomm_PlcStatus.Font = emergencyLabelFont;
            }
            else if ((currentMode & SingleBitInWordValues[autoModeBitPos]) != 0)
            {
                plcStatus = "Auto";
                Label_CELLcomm_PlcStatus.ForeColor = activeLabelColor;
                Label_CELLcomm_PlcStatus.Font = activeLabelFont;
            }
            else if ((currentMode & SingleBitInWordValues[autoModeBitPos]) == 0)
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
            if (panel.RedLed.Value)
            {
                Label_LedTowerRed_DwsPanel.Font = activeLabelFont;
                Label_LedTowerRed_DwsPanel.ForeColor = Color.Red;
            }
            else
            {
                Label_LedTowerRed_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerRed_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.BlueLed.Value)
            {
                Label_LedTowerBlue_DwsPanel.Font = activeLabelFont;
                Label_LedTowerBlue_DwsPanel.ForeColor = Color.Blue;
            }
            else
            {
                Label_LedTowerBlue_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerBlue_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.YellowLed.Value)
            {
                Label_LedTowerYellow_DwsPanel.Font = activeLabelFont;
                Label_LedTowerYellow_DwsPanel.ForeColor = Color.Orange;
            }
            else
            {
                Label_LedTowerYellow_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerYellow_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.GreenLed.Value)
            {
                Label_LedTowerGreen_DwsPanel.Font = activeLabelFont;
                Label_LedTowerGreen_DwsPanel.ForeColor = Color.Green;
            }
            else
            {
                Label_LedTowerGreen_DwsPanel.Font = inactiveLabelFont;
                Label_LedTowerGreen_DwsPanel.ForeColor = inactiveLabelColor;
            }
            if (panel.WhiteLed.Value)
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
            if (panel.RedLed.Value)
            {
                ledString = ledString + "Rd ";
            }
            if (panel.BlueLed.Value)
            {
                ledString = ledString + "Bl ";
            }
            if (panel.YellowLed.Value)
            {
                ledString = ledString + "Yl ";
            }
            if (panel.GreenLed.Value)
            {
                ledString = ledString + "Gn ";
            }
            if (panel.WhiteLed.Value)
            {
                ledString = ledString + "Wh";
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
            bool flag = ReadRegisterBit(currentStopper.OpenCommandFromCell);
            CheckBox_OpenCommandFromCell_Stopper.Checked = flag;
            flag = ReadRegisterBit(currentStopper.CloseCommandFromCell);
            CheckBox_CloseCommandFromCell_Stopper.Checked = flag;

            // Sensors
            CheckBox_InvAlarm_Stopper.Checked = currentStopper.InvAlarm.Value;
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
                UpdateRegister(currentRegister, CheckBox_OpenCommandFromCell_Stopper.Checked);
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
                UpdateRegister(currentRegister, CheckBox_CloseCommandFromCell_Stopper.Checked);
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
            currentStopper.InvAlarm.Value = CheckBox_InvAlarm_Stopper.Checked;
            string sensorStatus = CheckBox_InvAlarm_Stopper.Checked ? "OK." : "Error.";
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

        #region Stopper operation simulation
        // TODO - This section need to be tested.
        private void Update_Label_PlcOpenOut_Stopper()
        {
            //Auto mode. Check if the auto check box is checked
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

        #region FirePreventionShutter
        /// <summary>
        /// Updates the interface with the values of the current Shutter.
        /// </summary>
        private void UpdateShutterInterface()
        {
            #region Inputs
            // Sensors
            CheckBox_IsOpenSensor_Shutter.Checked = currentShutter.IsOpenSensor.Value;
            CheckBox_IsClosedSensor_Shutter.Checked = currentShutter.IsClosedSensor.Value;
            #endregion // Inputs

            UpdateShutterOutputs();
        }

        #region inputs
        private void ComboBox_Shutters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assume the index of the Combo Box is the same as the one of the Stoppers List.
            // TODO - 
            currentShutter = CoSimulationInstance.AlphaBotSystem.FirePreventionShutters[ComboBox_Shutters.SelectedIndex];
            // When the selected shutter changes, update shutter interface with the new shutter data
            UpdateShutterInterface();
        }

        private void CheckBox_OpenShutterCellCommand_CheckedChanged(object sender, EventArgs e)
        {
            // If the open command is active, disable the close command and vice versa.
            CheckBox_CloseShutterCellCommand.Enabled = !CheckBox_OpenShutterCellCommand.Checked;
            // Update value
            // No value to be updated
            // Log action
            string btnStatus = CheckBox_OpenShutterCellCommand.Checked ? "pressed." : "released.";
            ListBox_Log.Items.Add(currentShutter.Label + " Open command " + btnStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_CloseShutterCellCommand_CheckedChanged(object sender, EventArgs e)
        {
            // If the close command is active, disable the open command and vice versa.
            CheckBox_OpenShutterCellCommand.Enabled = !CheckBox_CloseShutterCellCommand.Checked;
            // Update value
            // No value to be updated
            // Log action
            string btnStatus = CheckBox_CloseShutterCellCommand.Checked ? "pressed." : "released.";
            ListBox_Log.Items.Add(currentShutter.Label + " Close command " + btnStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_IsOpenSensor_Shutter_CheckedChanged(object sender, EventArgs e)
        {
            // If this is checked, diable the other checkbox
            CheckBox_IsClosedSensor_Shutter.Enabled = !CheckBox_IsOpenSensor_Shutter.Checked;
            currentShutter.IsOpenSensor.Value = CheckBox_IsOpenSensor_Shutter.Checked;
            string sensorStatus = CheckBox_IsClosedSensor_Shutter.Checked ? " open." : " closing.";
            ListBox_Log.Items.Add(currentShutter.Label + sensorStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_IsClosedSensor_Shutter_CheckedChanged(object sender, EventArgs e)
        {
            // If this is checked, diable the other checkbox
            CheckBox_IsOpenSensor_Shutter.Enabled = !CheckBox_IsClosedSensor_Shutter.Checked;
            currentShutter.IsClosedSensor.Value = CheckBox_IsClosedSensor_Shutter.Checked;
            string sensorStatus = CheckBox_IsClosedSensor_Shutter.Checked ? " closed." : " opening.";
            ListBox_Log.Items.Add(currentShutter.Label + sensorStatus);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #endregion // inputs

        #region outputs
        private void UpdateShutterOutputs()
        {
            if (currentShutter != null)
            {
                Update_Label_IsRailUpToCell_Shutter();
                Update_Label_IsShutterOpenToCell_Shutter();
                Update_Label_PlcOpenOut_Shutter();
                Update_Label_PlcCloseOut_Shutter();
                Update_Label_IsOpenSensor_Shutter();
                Update_Label_IsClosedSensor_Shutter();
            }
        }

        private void Update_Label_IsOpenSensor_Shutter()
        {
            // TODO - update
            //currentShutter.IsOpenSensor.Value = ShutterOpenSensorSignal;
            UpdateSignalLabel(currentShutter.IsOpenSensor, Label_IsOpenSensor_Shutter);
        }

        private void Update_Label_IsClosedSensor_Shutter()
        {
            // TODO - update
            //currentShutter.IsClosedSensor.Value = ShutterCloseSensorSignal;
            UpdateSignalLabel(currentShutter.IsClosedSensor, Label_IsClosedSensor_Shutter);
        }

        private void Update_Label_IsRailUpToCell_Shutter()
        {
            UpdateSignalLabel(currentShutter.IsRailOpenToCell, Label_IsRailUpToCell_Shutter);
        }

        private void Update_Label_IsShutterOpenToCell_Shutter()
        {
            UpdateSignalLabel(currentShutter.IsShutterOpenToCell, Label_IsShutterOpenToCell_Shutter);
        }


        #region Shutter operation simulation
        // TODO - This section need to be tested.
        private void Update_Label_PlcOpenOut_Shutter()
        {
            // Check if the value of the PLC output has changed from false to true since the last reading
            // ie Current flag is false and current PLC output is true
            if (!ShutterOpenOutputIsOn & currentShutter.PlcOpenOut.Value)
            {
                ShutterCloseSensorSignal = false;
                ActuateShutter();
            }
            // Save current value for next comparison
            ShutterOpenOutputIsOn = currentShutter.PlcOpenOut.Value;
            UpdateSignalLabel(currentShutter.PlcOpenOut, Label_PlcOpenOut_Shutter);
        }

        private void Update_Label_PlcCloseOut_Shutter()
        {
            // Check if the value of the PLC output has changed from false to true since the last reading
            // ie Current flag is false and current PLC output is true
            if (!ShutterCloseOutputIsOn & currentShutter.PlcCloseOut.Value)
            {
                ShutterOpenSensorSignal = false;
                ActuateShutter();
            }
            // Save current value for next comparison
            ShutterCloseOutputIsOn = currentShutter.PlcCloseOut.Value;
            UpdateSignalLabel(currentShutter.PlcCloseOut, Label_PlcCloseOut_Shutter);
        }

        private void ActuateShutter()
        {
            // Initialize timer
            shutterTimer.Tick += new EventHandler(ShutterTimerProcessor);
            shutterTimer.Interval = shutterActuationWaitTime;
            shutterTimer.Start();
        }

        private void ShutterTimerProcessor(Object myObject, EventArgs myEventArgs)
        {
            shutterTimer.Stop();
            // Activate sensor
            //Check if the close signal is active
            if (currentShutter.PlcCloseOut.Value)
            {
                ShutterCloseSensorSignal = true;
            }
            // Check if the open signal is active
            else if (currentShutter.PlcOpenOut.Value)
            {
                ShutterOpenSensorSignal = true;
            }
        }

        #endregion // shutter operation simulation

        #endregion // outputs

        #endregion // FirePreventionShutter

        #region Fire Alarm
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
        #endregion // Fire Alarm

        #region Shutter cylinders
        private void CheckBox_CylinderPressure_CheckedChanged(object sender, EventArgs e)
        {
            if (CoSimulationInstance.AlphaBotSystem.ShutterCylinders != null)
            {
                CoSimulationInstance.AlphaBotSystem.ShutterCylinders.ForEach(cyl =>
                {
                    cyl.Value = CheckBox_CylinderPressure.Checked;
                });
                // Log action
                string isOn = CheckBox_CylinderPressure.Checked ? "OK." : "not OK.";
                ListBox_Log.Items.Add("Cylinder pressure " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        #endregion // Shutter Cylinders

        #region Evacuation and Maintenance area

        #region Input
        private void CheckBox_EstopBtn_EvacuationArea_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.EmergencyBtn,
                CheckBox_EstopBtn_EvacMaintArea,
                "Evac. Area");
        }

        #region Scaffold
        private void CheckBox_Scaffold_MaintArea_CheckedChanged(object sender, EventArgs e)
        {
            // The scaffold sensor is True for normal operation
            // Prevent Null exceptions when Maintenance area is not present.
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea != null 
                & CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold != null)
            {
                CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold.Value = CheckBox_Scaffold_EvacMaintArea.Checked;
                // Log action
                string isOn = CheckBox_Scaffold_EvacMaintArea.Checked ? "detected." : "not detected.";
                ListBox_Log.Items.Add("Maintenance area scaffold " + isOn);
                ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
            }
        }
        private void Update_Label_Scaffold_MaintArea()
        {
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea != null 
                & CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold != null)
            {
                // Read PLC input
                string status;
                if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold.Value)
                {
                    status = "ON";
                    Label_Scaffold_EvacMaintArea.ForeColor = activeLabelColor;
                    Label_Scaffold_EvacMaintArea.Font = activeLabelFont;
                }
                else
                {
                    status = "OFF";
                    Label_Scaffold_EvacMaintArea.ForeColor = inactiveLabelColor;
                    Label_Scaffold_EvacMaintArea.Font = inactiveLabelFont;
                }
                //Update label
                Label_Scaffold_EvacMaintArea.Text = "is " + status;
            }
        }

        #endregion // Scaffold

        #region Door
        private void RadioButton_DoorClosed_EvacuationArea_CheckedChanged(object sender, EventArgs e)
        {
            // The door sensor is Normally Closed, ie True when closed.
            CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorClosedSensor.Value = 
                RadioButton_DoorClosed_EvacMaintArea.Checked;
            string isClosed = RadioButton_DoorClosed_EvacMaintArea.Checked ? "Closed" : "Open";
            ListBox_Log.Items.Add("Evac. area Door is " + isClosed);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void RadioButton_DoorLocked_EvacuationArea_CheckedChanged(object sender, EventArgs e)
        {
            // The key lock is NC, ie True when locked.
            CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorLockedKeySwitch.Value =
                RadioButton_DoorLocked_EvacMaintArea.Checked;
            string isLocked = RadioButton_DoorLocked_EvacMaintArea.Checked ? "Locked" : "Unlocked";
            ListBox_Log.Items.Add("Evac. area Door is " + isLocked);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void RadioButton_DoorReady_MaintArea_CheckedChanged(object sender, EventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Door.IsDoorReadyInput.Value =
                RadioButton_DoorReady_MaintArea.Checked;
            string isLocked = RadioButton_DoorReady_MaintArea.Checked ? "Ready" : "Not Ready";
            ListBox_Log.Items.Add("Maint. area Door is " + isLocked);
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        #endregion // Door

        #region Contactor
        private void CheckBox_ContactorOnOff_EvacMaintArea_CheckedChanged(object sender, EventArgs e)
        {
            // No actual command from Cell for this contactor
            // Log action
            ListBox_Log.Items.Add("Command ignored for Evac/Maint area contactor.");
            ListBox_Log.SetSelected(ListBox_Log.Items.Count - 1, true);
        }

        private void CheckBox_ContactorPlcIn_EvacMaintArea_CheckedChanged(object sender, EventArgs e)
        {
            CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Contactor.ContactorFeedback.Value = 
                CheckBox_ContactorPlcIn_EvacMaintArea.Checked;
            if (CheckBox_ContactorPlcIn_EvacMaintArea.Checked)
            {
                Label_ContactorPlcIn_EvacMaintArea.ForeColor = activeLabelColor;
                Label_ContactorPlcIn_EvacMaintArea.Font = activeLabelFont;
            }
            else
            {
                Label_ContactorPlcIn_EvacMaintArea.ForeColor = inactiveLabelColor;
                Label_ContactorPlcIn_EvacMaintArea.Font = inactiveLabelFont;
            }
        }
        #endregion // Contactor

        #endregion // Input

        #region Output

        private void UpdateEvacAndMaintAreaOutputs()
        {
            Update_Label_ContactorPlcOut_EvacMaintArea();
            Update_Label_Scaffold_EvacMaintArea();
        }

        #region Contactor
        private void Update_Label_ContactorPlcOut_EvacMaintArea()
        {
            string status;
            // Read Plc output
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Contactor.ContactorOutput.Value == true)
            {
                // TODO - make sure this logic is ok with the PLC
                status = "ON";
                Label_ContactorPlcOut_EvacMaintArea.ForeColor = activeLabelColor;
                Label_ContactorPlcOut_EvacMaintArea.Font = activeLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_EvacMaintArea.Checked = false;
            }
            else
            {
                status = "OFF";
                Label_ContactorPlcOut_EvacMaintArea.ForeColor = inactiveLabelColor;
                Label_ContactorPlcOut_EvacMaintArea.Font = inactiveLabelFont;
                //Update Feedback control too!
                CheckBox_ContactorPlcIn_EvacMaintArea.Checked = true;
            }
            //Update labels
            Label_ContactorPlcOut_EvacMaintArea.Text = "Ctor " + status;
        }
        #endregion // Contactor

        #region Scaffold
        private void Update_Label_Scaffold_EvacMaintArea()
        {
            if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold != null)
            {
                // Read PLC input
                string status;
                if (CoSimulationInstance.AlphaBotSystem.EvacAndMaintArea.Scaffold.Value)
                {
                    status = "ON";
                    Label_Scaffold_EvacMaintArea.ForeColor = activeLabelColor;
                    Label_Scaffold_EvacMaintArea.Font = activeLabelFont;
                }
                else
                {
                    status = "OFF";
                    Label_Scaffold_EvacMaintArea.ForeColor = inactiveLabelColor;
                    Label_Scaffold_EvacMaintArea.Font = inactiveLabelFont;
                }
                //Update label
                Label_Scaffold_EvacMaintArea.Text = "is " + status;
            }
        }
        #endregion // Scaffold

        #endregion // Output

        #endregion // Evacuation and Maintenance area

        #region SWS
        private void CheckBox_EstopBtn_SWS1_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                CoSimulationInstance.AlphaBotSystem.StaticWorkStations[0].EmergencyBtn,
                CheckBox_EstopBtn_SWS1,
                "SWS 1");
        }

        private void CheckBox_EstopBtn_SWS2_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                CoSimulationInstance.AlphaBotSystem.StaticWorkStations[1].EmergencyBtn,
                CheckBox_EstopBtn_SWS2,
                "SWS 2");
        }

        private void CheckBox_EstopBtn_SWS3_CheckedChanged(object sender, EventArgs e)
        {
            EstopButtonChanged(
                CoSimulationInstance.AlphaBotSystem.StaticWorkStations[2].EmergencyBtn,
                CheckBox_EstopBtn_SWS2,
                "SWS 3");
        }

        #endregion // SWS

        #region Common methods
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

        #region Stopper and Shutter Common methods
        private void UpdateSignalLabel(RegisterFromPlc register, Label label, bool isError = false)
        {
            // Read Plc output and update label
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            // Check if the bit is ON.
            if ((currentValue & SingleBitInWordValues[bitPos]) == SingleBitInWordValues[bitPos])
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

        /// <summary>
        /// Sets the text for the tool tip
        /// </summary>
        private void CheckBox_EstopBtn_EvacuationArea_MouseHover(object sender, EventArgs e)
        {
            EstopBtnToolTip.SetToolTip(CheckBox_EstopBtn_EvacMaintArea, "This is the Estop on the Maintenance Area for the Miyano configuration. Escape are for Alpen");
        }

        private void EstopBtnToolTip_Popup(object sender, PopupEventArgs e)
        {
            // nothing to do here.
        }

        #region Registers and Bit-wise operations
        /// <summary>
        /// If isTrue, the relevant bit in the the provided register is changed to 1, else it is 0.
        /// </summary>
        /// <param name="register">Modbus register address of the signal to update</param>
        /// <param name="isTrue">Boolean control associated with the signal to update</param>
        /// <returns></returns>
        private ushort UpdateRegister(RegisterToPlc register, bool isTrue)
        {
            // Save current values
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            if (isTrue) // If the current interface control is true
            {
                // Bitwise OR makes sure the signal is true, independent of the previous state.
                currentValue = (ushort)(currentValue | SingleBitInWordValues[bitPos]);
            }
            else // If the current interface control is false
            {
                // If the boolean signal to be modified was true
                if ((currentValue & SingleBitInWordValues[bitPos]) == SingleBitInWordValues[bitPos])
                {
                    // Use an XOR to make it false
                    currentValue = (ushort)(currentValue ^ SingleBitInWordValues[bitPos]);
                }
                // If the signal is false, there is no need to modify the variable.
            }
            return currentValue;
        }

        /// <summary>
        /// Returns the bit (boolean) value associated to the current signal.
        /// </summary>
        /// <param name="register">Relevant Modbus register</param>
        /// <returns>Bit's boolean value</returns>
        private bool ReadRegisterBit(RegisterToPlc register)
        {
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            // Check if the bit is ON.
            if ((currentValue & SingleBitInWordValues[bitPos]) == SingleBitInWordValues[bitPos])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Overload method for "RegisterFromPlc" objects
        private bool ReadRegisterBit(RegisterFromPlc register)
        {
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            // Check if the bit is ON.
            if ((currentValue & SingleBitInWordValues[bitPos]) == SingleBitInWordValues[bitPos])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private byte GetLowerByte(ushort registerValue)
        {
            // Get only the least significant byte
            //byte upper = (byte)(number >> 8);
            return (byte)(registerValue & 0xff);
        }

        #endregion // Registers and Bit-wise operations

        #endregion // Common methods

        #region Unhandled IO
        // TODO - take care of these inputs in their respective place
        private void UpdateUnhandledIO()
        {
            MainInterface.PlcInstance.WriteBool("ELB_Trip_DWS1_L", true);
            MainInterface.PlcInstance.WriteBool("ELB_Trip_DWS1_R", true);
            MainInterface.PlcInstance.WriteBool("ELB_Trip_DWS2_L", true);
            MainInterface.PlcInstance.WriteBool("ELB_Trip_DWS2_R", true);
        }

        #endregion // Unhandled IO

        // TODO - update the rest of the buttons to use the common method
        // TODO - refactor/abstract the rest of the interface (radio buttons, etc)

    }
}
