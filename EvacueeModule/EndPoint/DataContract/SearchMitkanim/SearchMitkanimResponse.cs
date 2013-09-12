using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using EvacueeModule.BusinessRules.DataModel;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    [DataContract(Namespace = "http://malamteam/SearchMitkanimResponse")]
    public class SearchMitkanimResponse
    {

        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public string ErrorDesc { get; set; }

        [DataMember]
        public IEnumerable<ReportMitkanim> Data { get; set; }


    }
}
