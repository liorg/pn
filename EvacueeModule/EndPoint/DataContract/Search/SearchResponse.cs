using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    [DataContract(Namespace = "http://malamteam/SearchResponse")]
    public class SearchResponse
    {
        [DataMember]
        public IEnumerable<ShiltonMekomi> ShiltonMekomi { get; set; }
         
        [DataMember]
        public bool IsError { get; set; }

        [DataMember]
        public string ErrorDesc { get; set; }

        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int MaxRowsPerPage { get; set; }

        [DataMember]
        public SortingField SortingName { get; set; }

        [DataMember]
        public SortingOrder SortingOrder { get; set; }

        [DataMember]
        public int TotalRows { get; set; }
    }
}
