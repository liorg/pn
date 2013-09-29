using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataModel
{
    public class Result
    {
        public bool IsError { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class Result<T> : Result
    {
        public T Return { get; set; }
    }
    public class ResultWithTotalRows<T> : Result<T>
    {
        public int TotalRows { get; set; }
    }
}
