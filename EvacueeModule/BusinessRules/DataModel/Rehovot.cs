using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Rehovot")]
    public class Rehovot
    {
        //pk
        [DataMember]
        public int StNum { get; set; }

        [DataMember]
        public string StName { get; set; }

        [DataMember]
        public Yeshuvim StYeshuv { get; set; }
    }
}
