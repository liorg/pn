using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.Moin.EvacueeModule.Dal;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.Bll
{
    public class AgeTypeService : BaseService
    {
        public AgeTypeService(string connString, Action<string> log, Action<string> error)
            : base(connString, log, error)
        {
        }

        public Result<IEnumerable<AgeType>> GetAgeType()
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.GetAgeType();
        }


    }
}
