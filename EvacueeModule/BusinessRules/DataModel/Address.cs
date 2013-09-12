using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Address")]
    public class Address
    {
        [DataMember]
        public int YeshuvNum { get; set; }

        [DataMember]
        public int StNum { get; set; }

        [DataMember]
        public string YeshuvName { get; set; }

        [DataMember]
        public string StName { get; set; }

        [DataMember]
        public int? Moaza { get; set; }
    }
}
