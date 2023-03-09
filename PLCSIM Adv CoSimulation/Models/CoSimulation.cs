using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using PLCSIM_Adv_CoSimulation.Models.Configuration;
using PLCSIM_Adv_CoSimulation.Models.Debugging;
using System.Reflection;
using System.Collections;

namespace PLCSIM_Adv_CoSimulation.Models
{
    /// <summary>
    /// Class for the Alphabot System simulation. It is modeled after the actual physical layout.
    /// </summary>
    public class CoSimulation
    {
        #region Constants and fields
        #endregion

        #region Properties
        public AlphaBotSystem AlphaBotSystem { get; private set; } = new AlphaBotSystem();
        #endregion //Properties

        #region Ctor
        public CoSimulation(string filepath)
        {
            //Create instance of the simulated system
            AlphaBotSystem = ReadXML(filepath, AlphaBotSystem);
            //InitializeIO(AlphaBotSystem);
            LoopThroughObject(AlphaBotSystem);
        }

        #endregion //Ctor

        #region Destructor
        ~CoSimulation()
        {
            //Saves a copy of the current AlphaBotSystem instance when the CoSimulation instance is destroyed
            //TODO - Change file path
            CreateXML("SerializedSimulationData.xml", AlphaBotSystem);
        }
        #endregion // Destructor

        #region Public Methods

        #endregion // Public Methods

        #region Private Methods
        /// <summary>
        /// Loop through nested object recursively to read and write IO to PLC instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        private void LoopThroughObject<T> (T obj)
        {
            //TODO - Need to validate tag and value before API call
            //TODO - Delete Console prints
            // First, test for unprocessable input
            if (obj == null)
            {
                // Console.WriteLine(obj?.ToString() ?? "obj" + " is null.");
                return;
            }
            Type objType = obj.GetType();
            if (objType.IsValueType) 
            {
                // Console.WriteLine(obj.ToString() + " is a value type.");
                return;
            }
            // Need to add Write and Read instructions
            else if (objType == typeof(PlcInput))
            {
                // TODO - add validation here?
                // Console.WriteLine(obj.ToString() + " is an input.");
                return;
            }
            else if (objType == typeof(PlcOutput)) 
            {
                // TODO - add validation here?
                // Console.WriteLine(obj.ToString() + " is an output.");
                return;
            }
            else if (objType == typeof(RegisterToPlc))
            {
                // TODO - add validation here?
                // Console.WriteLine(obj.ToString() + " is a RegisterToPlc.");
                return;
            }
            else if (objType == typeof(RegisterFromPlc))
            {
                // TODO - add validation here?
                // Console.WriteLine(obj.ToString() + " is a RegisterFromPlc.");
                return;
            }
            // If program gets to this point, it means we can go inside obj
            else
            {
                // Iterate properties of object
                //TODO - Explore a better way to loop through classes
                //For example, make all classes iterable by implementing IEnumerator interface
                foreach (PropertyInfo property in objType.GetProperties()) 
                {
                    Type propType = property.PropertyType;

                    // Test for base cases
                        //TODO - Need to validate tag and value data before API call (write/read)
                    if (propType == typeof(PlcInput))
                    {
                        PlcInput tempInput = (PlcInput)property.GetValue(obj);
                        // TODO - add validation here?
                        // Console.WriteLine(property.Name + " is an input.");
                    }
                    else if (propType == typeof(PlcOutput))
                    {
                        PlcOutput tempOutput = (PlcOutput)property.GetValue(obj);
                        // TODO - add validation here?
                        // Console.WriteLine(property.Name + " is an output.");
                    }
                    else if (propType == typeof(RegisterToPlc))
                    {
                        RegisterToPlc tempSignal = (RegisterToPlc)property.GetValue(obj);
                        // TODO - add validation here?
                        // Console.WriteLine(property.Name + " is a SignalToPlc.");
                    }
                    else if (propType == typeof(RegisterFromPlc))
                    {
                        RegisterFromPlc tempSignal = (RegisterFromPlc)property.GetValue(obj);
                        // TODO - add validation here?
                        // Console.WriteLine(property.Name + " is a SignalFromPlc.");
                    }
                    // Finally, recursion!
                    // If the property is a List
                    else if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Console.WriteLine("To iterate: " + property.Name + " is " + propType);
                        IList tempIList = (IList)property.GetValue(obj);
                        foreach(object item in tempIList)
                        {
                            // Console.WriteLine("Recur: " + item);
                            //Recursive call. Item in list
                            LoopThroughObject(item);
                        }
                    }
                    //Check if the Type name contains "System" in it, if so, ignore. Need to be done after checking for Generic type to prevent ignoring Lists
                    //TODO - Find a better way to distinguish between these 2 cases
                    else if (propType.ToString().Contains("System"))
                    {
                        // Console.WriteLine("Ignore: " + property.Name + " is " + propType);
                    }
                    //This is meant to check if the object is an instance of any class in the ...Models.Configuration namespace, ie a class defined for the Alphabot System
                    else if (propType.ToString().Contains("Configuration"))
                    {
                        // Console.WriteLine("Recur: " + property.Name + " is " + propType);
                        //Another recursive call. Property of Object
                        LoopThroughObject(property.GetValue(obj));
                    }
                    else
                    {
                        Console.WriteLine("Unhandled type: " + property.Name + " is " + propType);
                    }
                }
            }
        }
        /// <summary>
        /// Creates an XML file with the Object's current properties
        /// </summary>
        /// <param name="filepath">File to write to</param>
        /// <param name="obj">Object to be serialized</param>
        private void CreateXML<T>(string filepath, T obj)
        {
            // Create an instance of the XmlSerializer class.
            XmlSerializer serializer =
                new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filepath);

            // Specify the type of object to serialize.
            // --- Object is received as a parameter

            //Serialize the object
            serializer.Serialize(writer, obj);
            writer.Close();
        }
        /// <summary>
        /// Reads and XML file and saves the data to the Object's properties.
        /// </summary>
        /// <param name="filepath">XML configuration file</param>
        /// <param name="AlphaBotSystem">Object variable of the type to be deserialized</param>
        /// <returns> Object created from XML file data</returns>
        /// <T>object</T> parameter is not used inside the function. It is there to allow different method signatures
        private T ReadXML<T>(string filepath, T obj)
        {
            // Create an instance of the XmlSerializer class.
            // Specify the type of object to be deserialized.
            XmlSerializer serializer = 
                new XmlSerializer(typeof(T));
            /* If the XML document has been altered with unknown
             * nodes or attributes, handle them with 
             * UnknownNode and UnknownAttribute events.*/
            serializer.UnknownNode += 
                new XmlNodeEventHandler(Serializer_UnknownNode);
            serializer.UnknownAttribute += 
                new XmlAttributeEventHandler(Serializer_UnknownAttribute);

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filepath, FileMode.Open);
            // Declare an object variable of the type to be deserialized.
            // --- Object is received as a parameter
            /* Use the Deserialize method to restore the object's state with
             * data from the XML document. */
            return (T)serializer.Deserialize(fs);
        }
        private void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node: " + e.Name + "\t" + e.Text + "\t Line: " + e.LinePosition);
        }
        private void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }
        #endregion //Private Methods

        #region Events
        #endregion
    }
}
