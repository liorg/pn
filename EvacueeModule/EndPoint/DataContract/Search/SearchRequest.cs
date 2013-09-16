using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataContract
{
   
    [DataContract(Namespace = "http://malamteam/SearchRequest")]
    public class SearchRequest
    {
        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int MaxRowsPerPage { get; set; }

        [DataMember]
        public SortingField SortingName { get; set; }

        [DataMember]
        public SortingOrder SortingOrder { get; set; }

        //תאריך קליטה מ
        [DataMember]
        public DateTime? MfDateIncomeBegin { get; set; }
        //תאריך קליטה עד
        [DataMember]
        public DateTime? MfDateIncomeEnd { get; set; }

        [DataMember]
        public int? MehozId { get; set; }

        [DataMember]
        public int? MitkanNum { get; set; }

        [DataMember]
        public int? RashutID { get; set; }

        [DataMember]
        public string MfFirstName { get; set; }

        [DataMember]
        public string MfLastName { get; set; }

        [DataMember]
        public string MfGender { get; set; }

        //tz
        [DataMember]
        public long? MefuneID { get; set; }

        [DataMember]
        public string MfFather { get; set; }

        [DataMember]
        public int? MfAge { get; set; }

        //ישוב המגורים
        [DataMember]
        public int? YeshuvNum { get; set; }

        //רחוב מגורים
        [DataMember]
        public int? StNum { get; set; }
        //מס' בית
        [DataMember]
        public string MfAddHouseNum { get; set; }

        //נמצא כרגע באתר פינוי
        [DataMember]
        public bool? IsMfDateOutcome { get; set; }

    }
}
