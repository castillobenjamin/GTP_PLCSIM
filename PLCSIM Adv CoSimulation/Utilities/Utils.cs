using PLCSIM_Adv_CoSimulation.Models.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Utilities
{
    /// <summary>
    /// Contains useful constants and methods.
    /// </summary>
    internal static class Utils
    {
        #region Fields
        internal enum CellCommandValues : byte
        {
            None = 0,
            Run = 1,
            Permit = 2,
            Cancel = 3
        }

        /// <summary>
        /// Dictionary of Cell commands. key = string, value = byte
        /// </summary>
        internal static readonly Dictionary<string, byte> CellCommands = new Dictionary<string, byte>
        {
            {"None", 0},
            {"Run", 1},
            {"Permit", 2},
            {"Cancel", 3},
        };

        /// <summary>
        /// Zoning statuses dictionary.
        /// </summary>
        internal static readonly Dictionary<byte, string> ZoningStatuses = new Dictionary<byte, string>
        {
            {0, "Stop"},
            {1, "Waiting"},
            {2, "Requesting"},
            {3, "Canceling"},
            {4, "Permit"},
        };
        /// <summary>
        /// Zoning statuses reverse dictionary
        /// </summary>
        internal static readonly Dictionary<string, byte> ZoningStatusBytes = new Dictionary<string, byte>
        {
            {"Stop", 0},
            {"Waiting", 1},
            {"Requesting", 2},
            {"Canceling", 3},
            {"Permit", 4},
        };
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
        #region Counter
        /// <summary>
        /// Updates a byte type counter variable.
        /// </summary>
        /// <param name="counter">The current value of the counter</param>
        /// <returns>Updated counter value</returns>
        internal static byte CountByteUp(byte counter)
        {
            if (counter == byte.MaxValue)
                counter = byte.MinValue;
            else
                counter += 1;
            return counter;
        }
        #endregion // Counter
        /// <summary>
        /// Contains bitwise operation methods used for updating and reading ModBus registers.
        /// </summary>
        #region BitWiseOperations
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
        #endregion // BitWiseOperations

        #region File processing
        /// <summary>
        /// XML file processing. 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static List<string> ConvertXml2List(string file)
        {
            // TODO - process XML file and return a list of strings. Each string is one instruction.
            // Return dummy string
            return (new List<string>
            {
                "TurnOnCell",
                "StartCellOperation",
                "StopCellOperation",
                "TurnOffCell"
            });
        }

        /// <summary>
        /// Text file processing.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static string[] ConvertTextFile2List(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        /// <summary>
        /// Converts a string array to a text file.
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="path"></param>
        /// <returns>True if successful.</returns>
        internal static bool ConvertList2File(string[] lines, string path)
        {
            try
            {
                File.WriteAllLines(path, lines);
                return true;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                return false; 
            } 
        }
        #endregion // File processing
        #endregion // Methods
    }
}
