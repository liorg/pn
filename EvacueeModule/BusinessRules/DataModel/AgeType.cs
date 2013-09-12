using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/AgeType")]
    public class AgeType
    {
        //AgeId pk
        //pk
        [DataMember]
        public int AgeId { get; set; }

        [DataMember]
        public string AgeName { get; set; }
    }

}
