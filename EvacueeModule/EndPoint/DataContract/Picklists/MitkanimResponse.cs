using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    [DataContract(Namespace = "http://malamteam/RashuyotResponse")]
    public class MitkanimResponse
    {
        [DataMember]
        public IEnumerable<Mitkanim> Mitkanim { get; set; }
         
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public string ErrorDesc { get; set; }
    }
}
