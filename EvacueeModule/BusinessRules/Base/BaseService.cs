using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Guardian.Moin.EvacueeModule
{
    public abstract class BaseService
    {
        protected string _connString;
        protected Action<string> _log;
        protected Action<string> _error;

        public BaseService(string connString, Action<string> log, Action<string> error)
        {
            _connString = connString;
            _log = log;
            _error = error;
        }

        protected void WriteTrace(string s)
        {
            if (_log != null)
            {
                _log(s);
            }
        }

        protected void WriteError(string s)
        {
            if (_error != null)
            {
                _error(s);
            }
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connString);
        }

    }
}
