using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Mahoz")]
    public class MitkanType
    {
        //pk
        [DataMember]
        public int MitkanTypeId { get; set; }

        [DataMember]
        public string TypeName { get; set; }
    }
}
