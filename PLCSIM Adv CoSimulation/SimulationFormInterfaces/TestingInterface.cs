﻿using PLCSIM_Adv_CoSimulation.Models;
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
        // Common for all buttons. Including E-stop, Reset, Request.
        private bool TurnInputOn(PlcInput button) 
        {
            try
            {
                button.Value = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool TurnInputOff(PlcInput button)
        {
            try
            {
                button.Value = false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion // Common methods

        #endregion // Update input

        #region Check output

        #endregion // Check output

        /// <summary>
        /// Returns the value of the PLC output.
        /// </summary>
        /// <param name="output"></param>
        /// <returns>The value of the PLC output. Returns false if the method failed to retrieve the value.</returns>
        private bool CheckOutput(PlcOutput output) 
        { 
            try
            {
                return output.Value;

            }
            catch (Exception) 
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the value of the Modbus register.
        /// </summary>
        /// <param name="register"></param>
        /// <returns>Returns an unsigned 16bit integer. Returns ? if the method failed to retrieve the value.</returns>
        private ushort CheckOutRegister(RegisterFromPlc register)
        {
            try
            {
                return register.Value;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        #endregion // Methods
    }
}