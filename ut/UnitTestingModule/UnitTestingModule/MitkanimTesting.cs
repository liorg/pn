using System;
using Guardian.Moin.EvacueeModule.Bll;
using Guardian.Moin.EvacueeModule.DataContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestingModule
{
    [TestClass]
    public class MitkanimTesting
    {

        string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["MEDAMConnectionString"].ConnectionString;
        }

        [TestMethod]
        public void GetMitkanimTest()
        {
            MitkanimService s = new MitkanimService(GetConnectionString(), null, null);
            var lists = s.GetMitkanim();
        }

        [TestMethod]
        public void SearchMitkanimTest()
        {
            MitkanimService s = new MitkanimService(GetConnectionString(), null, null);
            var req= new SearchMitkanimRequest();
            req.MaxRowsPerPage = 3;
            req.CurrentPage = 1;
            req.SortingOrder = SortingOrder.DESC;
            req.SortingName = SortingMitkanimField.MahozName;
            var lists = s.Search(req);

            foreach (var item in lists.Return)
            {
                Console.WriteLine(item.MahozName);
            }
        }
    }
}
