using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    [DataContract(Namespace = "http://malamteam/ReportMitkanim")]
    public class ReportMitkanim
    {
        [DataMember]
        public int? MahozNum { get; set; }
        [DataMember]
        public string MahozName { get; set; }

        [DataMember]
        public int? MitkanNum { get; set; }
        [DataMember]
        public string MitkanName { get; set; }

        [DataMember]
        public int? RashutID { get; set; }
        [DataMember]
        public string RashutName { get; set; }

        [DataMember]
        public string MitkanAddress { get; set; }
        

        //סה"כ קלוטים במתקן
        [DataMember]
        public int? SumAll { get; set; }
        //סהכ קלוטים בטווח גילאים: 0-3
        [DataMember]
        public int? Sum3 { get; set; }

        //סהכ קלוטים בטווח גילאים: 4-6
        [DataMember]
        public int? Sum4To6 { get; set; }

        //סהכ קלוטים בטווח גילאים: 7-18
        [DataMember]
        public int? Sum7To18 { get; set; }

        //סהכ קלוטים בטווח גילאים: 19-65
        [DataMember]
        public int? Sum19To65 { get; set; }

        //סהכ קלוטים בטווח גילאים: 66+
        [DataMember]
        public int? Sum66 { get; set; }
    }
}
