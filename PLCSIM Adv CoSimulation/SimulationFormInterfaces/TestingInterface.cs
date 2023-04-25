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

namespace PLCSIM_Adv_CoSimulation
{
    public partial class TestingInterface : Form
    {
        #region Fields
        private readonly CoSimulation CoSimulationInstance;

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
                if(Utils.GetLowerByte(register.Value) == expectedValue) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion // Check output

        #endregion // Common methods

        #endregion // Methods
    }
}
