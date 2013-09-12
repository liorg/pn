using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Rashuyot")]
    public class Rashuyot
    {
        //pk
        [DataMember]
        public int RashutID { get; set; }

        [DataMember]
        public string RashutName { get; set; }

        [DataMember]
        public Mehozot Mehoz { get; set; }
    }
}
