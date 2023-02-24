using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Debugging
{
    [Serializable]
    [XmlRoot("Test")]
    public class TestClass
    {
        [XmlAttribute]
        public string StringAttribute { get; set; }
        [XmlElement]
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }

        public TestClass() { }

        #region Methods
        /*
        /// Add these methods to CoSimulation Class for testing
        private void CreateXML(string filepath, SimpleClass Test)
        {
            // Create an instance of the XmlSerializer class.
            XmlSerializer serializer =
                new XmlSerializer(typeof(SimpleClass));
            TextWriter writer = new StreamWriter(filepath);

            // Specify the type of object to serialize.
            // --- Object is received as a parameter

            //Serialize the object
            serializer.Serialize(writer, Test);
            writer.Close();
        }
        private SimpleClass ReadXML(string filepath, SimpleClass Test)
        {
            // Create an instance of the XmlSerializer class.
            // Specify the type of object to be deserialized.
            XmlSerializer serializer =
                new XmlSerializer(typeof(SimpleClass));
            serializer.UnknownNode +=
                new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute +=
                new XmlAttributeEventHandler(serializer_UnknownAttribute);

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filepath, FileMode.Open);
            // Declare an object variable of the type to be deserialized.

            return (SimpleClass)serializer.Deserialize(fs);
        }
        */
        #endregion //Methods
    }



}
