using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Mitkanim")]
    public class Mitkanim
    {
          //pk
        [DataMember]
        public int MitkanNum { get; set; }

        [DataMember]
        public string MitkanName { get; set; }

        [DataMember]
        public string MitkanPhone { get; set; }
        //custom
        [DataMember]
        public string MitkanAddress { get; set; }

        //complex
        [DataMember]
        public MitkanType MitkanType { get; set; }

        [DataMember]
        public Rashuyot Rashut { get; set; }
        
    }
}
