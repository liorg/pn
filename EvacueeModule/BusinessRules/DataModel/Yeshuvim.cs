using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Yeshuvim")]
    public class Yeshuvim
    {
        //pk
        [DataMember]
        public int YeshuvNum { get; set; }

        [DataMember]
        public string YeshuvName { get; set; }

        [DataMember]
        public Mehozot Mehoz { get; set; }
    }
}
