using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/Mehozot")]
    public class Mehozot
    {
        //pk
        [DataMember]
        public int MahozNum { get; set; }

        [DataMember]
        public string MahozName { get; set; }
    }
}
