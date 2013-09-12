using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Net.Security;
using Guardian.Moin.EvacueeModule.DataContract;

namespace Guardian.Moin.EvacueeModule
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  //  [ServiceContract(ProtectionLevel=ProtectionLevel.Sign)]
    [ServiceContract(ProtectionLevel = ProtectionLevel.Sign, Namespace = "http://malamteam/IMefonimGovService")]   
    public interface IMefonimGovService
    {
        [OperationContract]
        string Ping(string s);

        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        AddressResponse GetAddress();

        [OperationContract]
        SearchResponse Search(SearchRequest request);
        
        [OperationContract]
        SearchMitkanimResponse SearchMitkanim(SearchMitkanimRequest request);

        [OperationContract]
        AgesTypeResponse GetAgesType();

        [OperationContract]
        RashuyotResponse GetRashuyot();

        [OperationContract]
        YeshuvimResponse GetYeshuvim();

        [OperationContract]
        MitkanimResponse GetMitkanim();


        
    }

}
