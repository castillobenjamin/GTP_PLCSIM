using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class DynamicWorkStation : Zone
    {
        #region Fields
        private bool coversSerializes;
        #endregion // Fields

        #region Properties
        //Estop button
        public PlcInput EmergencyBtn { get; set; }
        //Contactor
        public Contactor Contactor { get; set; }
        // DWS Covers
        [XmlArray("Covers", IsNullable = true)]
        [XmlArrayItem("Cover", IsNullable = true)]
        public List<PlcInput> Covers { get; set; }
        [XmlIgnore()]
        public bool CoversSpecified { 
            get { return coversSerializes; } 
            set { coversSerializes = value; } }
        #endregion
    }
}