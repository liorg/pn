using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.Moin.EvacueeModule.Dal;
using Guardian.Moin.EvacueeModule.DataContract;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.Bll
{
    public class MitkanimService : BaseService
    {
        public MitkanimService(string connString, Action<string> log, Action<string> error)
            : base(connString, log, error)
        {
        }

        public ResultWithTotalRows<IEnumerable<ReportMitkanim>> Search(SearchMitkanimRequest request)
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.ExcuteReportMitkanim(request);
        }


        public Result<IEnumerable<Mitkanim>> GetMitkanim()
        {
            var dbContext = new MedamContext(_connString, _log, _error);
            return dbContext.GetMitkanim();
        }

    }
}
