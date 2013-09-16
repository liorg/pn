using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    [DataContract(Namespace = "http://malamteam/SearchMitkanimRequest")]
    public class SearchMitkanimRequest
    {
        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int MaxRowsPerPage { get; set; }

        [DataMember]
        public SortingMitkanimField SortingName { get; set; }

        [DataMember]
        public SortingOrder SortingOrder { get; set; }
        [DataMember]
        public int? MahozNum { get; set; }

        [DataMember]
        public int? MitkanNum { get; set; }

        [DataMember]
        public int? RashutID { get; set; }

    }
}
