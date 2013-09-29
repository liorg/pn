using ManageEvacuees.NSMefonimGovService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageEvacuees.Moduls
{
    public class ManageSearch
    {
        public static SearchMitkanimResponse SearchEquipment(int mehozId,int mitkanNum, int rashutID) 
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            SearchMitkanimRequest request = new SearchMitkanimRequest()
            {
                CurrentPage = 1,
                MaxRowsPerPage = 10,
                MahozNum = mehozId,
                MitkanNum = mitkanNum,
                RashutID = rashutID,
                SortingName = SortingMitkanimField.MahozName,
                SortingOrder = SortingOrder.ASC
            };
            return client.SearchMitkanim(request);
        }

        public static SearchResponse SearchEvacuees(string firstName,
                                                     string lastName, 
                                                     string fatherName, 
                                                     string gender, 
                                                     long? IdNumber, 
                                                     DateTime? DateIncomeBegin, 
                                                     DateTime? DateIncomeEnd, 
                                                     int? AreaId, 
                                                     int? CityId, 
                                                     int? streetId, 
                                                     int? EqMahozId, 
                                                     int? equipId)
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            SearchRequest request = new SearchRequest()
            {
                CurrentPage = 1,
                MaxRowsPerPage = 10,
                SortingName = SortingField.MfLastName,
                SortingOrder = SortingOrder.ASC,
                MfFirstName = firstName,
                MfLastName = lastName, 
                MfFather = fatherName, 
                MefuneID = IdNumber, 
                MfGender = gender, 
                MfDateIncomeBegin = DateIncomeBegin, 
                MfDateIncomeEnd = DateIncomeEnd, 
                RashutID = AreaId, 
                YeshuvNum = CityId, 
                StNum = streetId, 
                MehozId = EqMahozId, 
                MitkanNum = equipId
            };
            return client.Search(request);
        }
    }
}