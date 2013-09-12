using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.Moin.EvacueeModule.Dal;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.Bll
{
    public class AddressService : BaseService
    {
        public AddressService(string connString, Action<string> log, Action<string> error)
            : base(connString, log, error)
        {
        }

        public Result<IEnumerable<Address>> GetAddresses()
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.GetAddresses();
        }

        public Result<IEnumerable<Yeshuvim>> GetYeshuvim()
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.GetYeshuvim();
        }

        public Result<IEnumerable<Rashuyot>> GetRashuyot()
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.GetRashuyot();
        }

    }
}
