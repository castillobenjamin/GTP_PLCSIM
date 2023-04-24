using PLCSIM_Adv_CoSimulation.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCSIM_Adv_CoSimulation.Utilities
{
    /// <summary>
    /// Contains bitwise operation methods used for updating and reading ModBus registers.
    /// </summary>
    internal static class BitWiseOperations
    {
        #region Fields
        /// <summary>
        /// Dictionary containing the value of all single bit permutations in a ushort/word variable
        /// The key is the bit position. Range [0 - 15]
        /// </summary>
        internal static readonly Dictionary<ushort, ushort> SingleBitInWordValues = new Dictionary<ushort, ushort>
        {
            {0, 0b_0000_0000_0000_0001}, //bit 0
            {1, 0b_0000_0000_0000_0010}, //bit 1
            {2, 0b_0000_0000_0000_0100}, //bit 2
            {3, 0b_0000_0000_0000_1000}, //bit 3
            {4, 0b_0000_0000_0001_0000}, //bit 4
            {5, 0b_0000_0000_0010_0000}, //bit 5
            {6, 0b_0000_0000_0100_0000}, //bit 6
            {7, 0b_0000_0000_1000_0000}, //bit 7
            {8, 0b_0000_0001_0000_0000}, //bit 8
            {9, 0b_0000_0010_0000_0000}, //bit 9
            {10, 0b_0000_0100_0000_0000}, //bit 10
            {11, 0b_0000_1000_0000_0000}, //bit 11
            {12, 0b_0001_0000_0000_0000}, //bit 12
            {13, 0b_0010_0000_0000_0000}, //bit 13
            {14, 0b_0100_0000_0000_0000}, //bit 14
            {15, 0b_1000_0000_0000_0000}, //bit 15
        };
        #endregion // Fields

        #region Methods
        /// <summary>
        /// The input register is updated with the input value.
        /// </summary>
        /// <param name="register">Modbus register address of the signal to update</param>
        /// <param name="isTrue">Boolean control associated with the signal to update</param>
        /// <returns></returns>
        internal static ushort UpdateRegister(RegisterToPlc register, bool value)
        {
            // Save current values
            ushort currentValue = register.Value;
            ushort bitPos = register.BitPosition;
            if (value) // If the new value is true
            {
                // Bitwise OR makes sure the signal is true, independent of the previous state.
                currentValue = (ushort)(currentValue | SingleBitInWordValues[bitPos]);
            }
            else // If the new value is false
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
        /// Returns the boolean value associated to the input signal.
        /// </summary>
        /// <param name="register">Relevant Modbus register</param>
        /// <returns>Bool</returns>
        internal static bool ReadRegisterBit(RegisterToPlc register)
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
        /// <summary>
        /// Returns the boolean value associated to the input signal.
        /// </summary>
        /// <param name="register"></param>
        /// <returns>Bool</returns>
        internal static bool ReadRegisterBit(RegisterFromPlc register)
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
        /// <summary>
        /// Returns the lower byte of a ushort variable.
        /// </summary>
        /// <param name="registerValue"></param>
        /// <returns></returns>
        internal static byte GetLowerByte(ushort registerValue)
        {
            // Get only the least significant byte
            //byte upper = (byte)(number >> 8);
            return (byte)(registerValue & 0xff);
        }
        #endregion // Methods
    }
}
