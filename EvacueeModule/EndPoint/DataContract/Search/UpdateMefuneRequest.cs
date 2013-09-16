using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.DataContract
{

    [DataContract(Namespace = "http://malamteam/UpdateMefuneRequest")]
    public class UpdateMefuneRequest
    {
        [DataMember]
        public ShiltonMekomi ShiltonMekomi { get; set; }


    }
}
