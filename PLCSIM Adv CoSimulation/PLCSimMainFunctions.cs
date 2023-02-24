using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Simatic.Simulation.Runtime;

namespace PLCSIM_Adv_CoSimulation
{
    public class PLCSimMainFunctions
    {
        public IInstance currentPlcInstance;
        public static Array currentTagList;
        public static SDataValue tagValue;
        public static string addressValue;

        public static bool isIO, isBitMem, isCTs, isDBs;

        public SInstanceInfo[] FillInstanceInformation()
        {
            return SimulationRuntimeManager.RegisteredInstanceInfo;
        }

        public string createNewPLC(string plcName)
        {
            try
            {
                SimulationRuntimeManager.RegisterInstance(plcName);
                return "PLC " + plcName + " was succesfully created.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string deletePLC(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.UnregisterInstance();
                return "PLC " + plcName + " was succesfully removed.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string powerOnPlc(string plcName, string ipAddress, string subnetMask, string gateway)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                //Power PLC ON
                currentPlcInstance.PowerOn(6000);

                //Set IP suite
                SIPSuite4 instanceIPSuite = new SIPSuite4(ipAddress, subnetMask, gateway);

                return plcName + " ON.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string powerOffPlc(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.PowerOff(6000);

                return plcName + " OFF.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string rebootPlc(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.MemoryReset();

                return plcName + " memory reset.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string setPlcToRunMode(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.Run(6000);

                return plcName + " is in Run mode.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string setPlcToStopMode(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.Stop(6000);

                return plcName + " is in Stop mode.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string getPlcOperatingState(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                return currentPlcInstance.OperatingState.ToString();
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string changeCommToLocal(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.CommunicationInterface = ECommunicationInterface.Softbus;

                return plcName + " communication interface changed to local.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string changeCommToTCPIP(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.CommunicationInterface = ECommunicationInterface.TCPIP;

                return plcName + " communication interface changed to TCP/IP.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string getConnectionType(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                return currentPlcInstance.CommunicationInterface.ToString();
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string setVirtualTimeFactor(string plcName, string scaleFactor)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);
                currentPlcInstance.ScaleFactor = Convert.ToDouble(scaleFactor);
                return plcName + "Time scale changed to " + currentPlcInstance.ScaleFactor;
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string readPLCTags(string plcName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                //Call update func
                updateTagListArea();

                currentTagList = (Array)currentPlcInstance.TagInfos;
                return "Tags were successfully read.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string readPLCTagValue(string plcName, string tagName)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                tagValue = currentPlcInstance.Read(tagName);


                return "Tags were successfully read.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string writePLCTagValue(string plcName, string tagName, string tagValString)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                switch(tagValue.Type.ToString())
                {
                    case "Bool":
                        currentPlcInstance.WriteBool(tagName, Convert.ToBoolean(tagValString));
                        tagValue = currentPlcInstance.Read(tagName);
                        return tagValString + " was succesfully written to " + tagName;
                    case "Int8":
                        currentPlcInstance.WriteInt8(tagName, Convert.ToSByte(tagValString));
                        tagValue = currentPlcInstance.Read(tagName);
                        return tagValString + " was succesfully written to " + tagName;
                    case "Int16":
                        break;
                    case "Int32":
                        break;
                    case "Int64":
                        break;
                    case "UInt8":
                        break;
                    case "UInt16":
                        break;
                    case "UInt32":
                        break;
                    case "UInt64":
                        break;
                    case "float":
                        break;
                    case "Double":
                        break;
                    case "WChar":
                        break;
                    case "Char":
                        break;
                    default:
                        return tagName + "Data type not supported";
                }


                return "Tags were successfully read.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void updateTagListArea()
        {
            if (isIO) currentPlcInstance.UpdateTagList(ETagListDetails.IO, false);
            if (isBitMem) currentPlcInstance.UpdateTagList(ETagListDetails.M, false);
            if (isCTs) currentPlcInstance.UpdateTagList(ETagListDetails.CT, false);
            if (isDBs) currentPlcInstance.UpdateTagList(ETagListDetails.DB, false);
        }

        public string readBitfromPLC(string plcName, string IOaddress, string addressArea, string addressBit)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                switch (addressArea)
                {
                    case "Input":
                        addressValue = currentPlcInstance.InputArea.ReadBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit)).ToString();
                        return "Address " + IOaddress + " with value " + addressValue + " was read successfully.";
                    case "Marker":
                        addressValue = currentPlcInstance.InputArea.ReadBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit)).ToString();
                        return "Address " + IOaddress + " with value " + addressValue + " was read successfully.";
                    case "Output":
                        addressValue = currentPlcInstance.InputArea.ReadBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit)).ToString();
                        return "Address " + IOaddress + " with value " + addressValue + " was read successfully.";
                }


                return "Unable to read specified address.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string readBytefromPLC(string plcName, string IOaddress, string addressArea)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                switch (addressArea)
                {
                    case "Input":
                        addressValue = currentPlcInstance.InputArea.ReadByte(Convert.ToUInt32(IOaddress)).ToString();
                        return "Address " + IOaddress + " with value "+ addressValue + " was read successfully.";
                    case "Marker":
                        addressValue = currentPlcInstance.MarkerArea.ReadByte(Convert.ToUInt32(IOaddress)).ToString();
                        return "Address " + IOaddress + " with value " + addressValue + " was read successfully.";
                    case "Output":
                        addressValue = currentPlcInstance.OutputArea.ReadByte(Convert.ToUInt32(IOaddress)).ToString();
                        return "Address " + IOaddress + " with value " + addressValue + " was read successfully.";
                }


                return "Unable to read specified address.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string writeBitToPLC(string plcName, string IOaddress, string addressArea, string addressBit, string value)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                switch (addressArea)
                {
                    case "Input":
                        currentPlcInstance.InputArea.WriteBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit), Convert.ToBoolean(value));
                        return "Value was written to address: " + IOaddress;
                    case "Marker":
                        currentPlcInstance.InputArea.WriteBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit), Convert.ToBoolean(value));
                        return "Value was written to address: " + IOaddress;
                    case "Output":
                        currentPlcInstance.InputArea.WriteBit(Convert.ToUInt32(IOaddress), Convert.ToByte(addressBit), Convert.ToBoolean(value));
                        return "Value was written to address: " + IOaddress;
                }


                return "Unable to write to specified address.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string writeByteToPLC(string plcName, string IOaddress, string addressArea, string value)
        {
            try
            {
                currentPlcInstance = SimulationRuntimeManager.CreateInterface(plcName);

                switch (addressArea)
                {
                    case "Input":
                        currentPlcInstance.InputArea.WriteByte(Convert.ToUInt32(IOaddress), Convert.ToByte(value));
                        return "Value was written to address: " + IOaddress;
                    case "Marker":
                        currentPlcInstance.InputArea.WriteByte(Convert.ToUInt32(IOaddress), Convert.ToByte(value));
                        return "Value was written to address: " + IOaddress;
                    case "Output":
                        currentPlcInstance.InputArea.WriteByte(Convert.ToUInt32(IOaddress), Convert.ToByte(value));
                        return "Value was written to address: " + IOaddress;
                }


                return "Unable to write to specified address.";
            }
            catch (SimulationInitializationException plcSimException)
            {
                return plcSimException.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
