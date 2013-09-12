using System;
using Guardian.Moin.EvacueeModule.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestingModule
{
    [TestClass]
    public class PickListTesting
    {

        string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["MEDAMConnectionString"].ConnectionString;
        }

        [TestMethod]
        public void AddressTest()
        {
            AddressService s = new AddressService(GetConnectionString(), null, null);
            var lists = s.GetAddresses();
        }

        [TestMethod]
        public void LoginServiceTest()
        {
            LoginService s = new LoginService(GetConnectionString(), null, null);
            var r = s.Login("lior", "123");
            Assert.AreEqual(r.Return, true);
            r = s.Login("lior", "123d");
            Assert.AreEqual(r.Return, false);
        }
     
        [TestMethod]
        public void MehozotServiceTest()
        {
            var s = new MitkanimService(GetConnectionString(), null, null);
            var r = s.GetMitkanim();
        }

        [TestMethod]
        public void AgeTypeServiceTest()
        {
            var s = new AgeTypeService(GetConnectionString(), null, null);
            var r = s.GetAgeType();
        }

        [TestMethod]
        public void RashuyotTest()
        {
            AddressService s = new AddressService(GetConnectionString(), null, null);
            var lists = s.GetRashuyot();
        }

        [TestMethod]
        public void GetYeshuvimTest()
        {
            AddressService s = new AddressService(GetConnectionString(), null, null);
            var lists = s.GetYeshuvim();
        }
    }
}
