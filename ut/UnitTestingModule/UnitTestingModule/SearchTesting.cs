using System;
using Guardian.Moin.EvacueeModule.Bll;
using Guardian.Moin.EvacueeModule.DataContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestingModule
{
    [TestClass]
    public class SearchTesting
    {

        string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["MEDAMConnectionString"].ConnectionString;
        }

        [TestMethod]
        public void Search1()
        {
            SearchService s = new SearchService(GetConnectionString(), null, null);
            SearchRequest req = new SearchRequest();
            req.MaxRowsPerPage = 15;
            req.CurrentPage = 1;
            req.SortingOrder = SortingOrder.DESC;
            req.SortingName = SortingField.MfLastName;
            req.MfDateIncomeBegin = DateTime.Parse("2013-8-4");
            var lists = s.Search(req);

            foreach (var item in lists.Return)
            {
                Console.WriteLine(item.MfFirstName);
            }


        }
        [TestMethod]
        public void SearchMFather()
        {
            SearchService s = new SearchService(GetConnectionString(), null, null);
            SearchRequest req = new SearchRequest();
            req.MaxRowsPerPage = 15;
            req.CurrentPage = 1;
            req.SortingOrder = SortingOrder.DESC;
            req.SortingName = SortingField.MfLastName;
            req.MfFather = " אילן";
            var lists = s.Search(req);

            foreach (var item in lists.Return)
            {
                Console.WriteLine(item.MfFirstName);
            }


        }
       
    }
}
