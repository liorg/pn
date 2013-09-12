using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/ShiltonMekomi")]
    public class ShiltonMekomi
    {
        //pk
        [DataMember]
        public long MefuneSysNum { get; set; }

        //tz
        [DataMember]
        public long? MefuneID { get; set; }

        [DataMember]
        public string MfLastName { get; set; }

        [DataMember]
        public string MfFirstName { get; set; }

        //[DataMember]
        //public string ReshutAddress { get; set; }

        [DataMember]
        public string MfFather { get; set; }

        [DataMember]
        public string MfGender { get; set; }

        [DataMember]
        public int? MfAge { get; set; }

        //נמצא כרגע באתר פינוי
        [DataMember]
        public bool? IsMfDateOutcome { get; set; }

        //[DataMember]
        //public DateTime? MfDateOutcome { get; set; }

        //תאריך קליטה
        [DataMember]
        public DateTime? MfDateIncome { get; set; }

        [DataMember]
        public string ShiltonMekomiAddress { get; set; }

        //complex type
        [DataMember]
        public Mitkanim Mitkan { get; set; }

        //מס' בית
        [DataMember]
        public string MfAddHouseNum { get; set; }

        //ישוב המגורים
        [DataMember]
        public int? YeshuvNum { get; set; }

        //רחוב מגורים
        [DataMember]
        public int? StNum { get; set; }
        //מס' בית


       
    }
}
