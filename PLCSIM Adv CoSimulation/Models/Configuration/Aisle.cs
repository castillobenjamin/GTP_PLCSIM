﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCSIM_Adv_CoSimulation.Models.Configuration
{
    public class Aisle : ZoneWithDoor
    {
        #region Properties  
        //Contactors
        [XmlArray("Contactors")]
        [XmlArrayItem("Contactor")]
        public List<Contactor> Contactors { get; set; }
        
        //Contactor lamp
        public PlcOutput ContactorLamp { get; set; }

        //Safety boards (formerly "scaffolds")
        [XmlArray("SafetyBoards")]
        [XmlArrayItem("SafetyBoard")]
        public List<PlcInput> SafetyBoards { get; set; }
        #endregion // Properties
    }
}