using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Guardian.Moin.EvacueeModule.Dal;
using Guardian.Moin.EvacueeModule.DataContract;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.Bll
{
    public class SearchService:BaseService
    {
        public SearchService(string connString, Action<string> log, Action<string> error)
            : base(connString, log, error)
        {
        }

        public Result<IEnumerable<ShiltonMekomi>>  Search(SearchRequest request)
        {
             var dbContext = new MedamContext(_connString, _log, _error);
           return dbContext.GetShiltonMekomiByModelAndPages(request);
        }


    }
}
