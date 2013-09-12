using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Net.Security;
using EntityLayer;

namespace MoinLocalGovDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(ProtectionLevel=ProtectionLevel.Sign)]   
    public interface IMoinLocalGovService
    {

        [OperationContract]
        string GetLawSubjects();

        [OperationContract]
        string GetLaws(int subjectID, int fromRow, int toRow);

        [OperationContract]      
        DocumentContent GetLawContent(int lawID);

        [OperationContract]
        string GetInspectionDocuments(int typeID, int year, int fromRow, int toRow);

        [OperationContract]
        string GetInspactionDocumentTypes();

        [OperationContract]
        DocumentContent GetDocumentContent(int docID);

        [OperationContract]
        string GetElectionDocuments(DateTime fromDate, DateTime toDate, int fromRow, int toRow);

        [OperationContract]
        string GetMeafyen(int NumRashut);

        [OperationContract]
        string GetPortalDocumentsTypes();

        [OperationContract]
        string GetRashuoyt();

        [OperationContract]
        string GetRashutDocuments(int typeID, int numRashut, int fromRow, int toRow);

        [OperationContract]
        string GetRashutLaws(int numRashut, int fromRow, int toRow);

        [OperationContract]
        string GetRelatedEntities(int rashutID, int fromRow, int toRow);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }

      

      
    //}
}
