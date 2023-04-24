using PLCSIM_Adv_CoSimulation.Models;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation
{
    public partial class TestingInterface : Form
    {
        #region Fields
        private readonly CoSimulation CoSimulationInstance;

        #endregion // Fields

        #region Initialization

        public TestingInterface(CoSimulation coSimulationInstance)
        {
            InitializeComponent();
            CoSimulationInstance = coSimulationInstance;
            
        }

        #endregion // Initialization

        #region Configuration

        private void TextBox_ProgramVersion_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion // Configuration

        #region Methods

        #region Update input

        #region CELL

        #endregion // CELL

        #region Subsystems

        #region Aisles

        private void PressAisleEstopButton(int aisleNum) 
        {
            bool isPressSuccess = TurnInputOn(CoSimulationInstance.AlphaBotSystem.Aisles[aisleNum].OperationBox.EmergencyBtn);
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
                if (BitWiseOperations.ReadRegisterBit(register) == expectedValue) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion // Check output

        #endregion // Common methods

        #endregion // Methods
    }
}
