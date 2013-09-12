using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    [DataContract(Namespace = "http://malamteam/LoginResponse")]
    public class LoginResponse
    {
        [DataMember]
        public bool IsValid { get; set; }
         
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public string ErrorDesc { get; set; }
    }

     [DataContract(Namespace = "http://malamteam/LoginRequest")]
    public class LoginRequest
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
