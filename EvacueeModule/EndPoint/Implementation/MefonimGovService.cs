using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Guardian.Moin.EvacueeModule.Bll;
using Guardian.Moin.EvacueeModule.DataContract;
namespace Guardian.Moin.EvacueeModule
{
   
    public class MefonimGovService : IMefonimGovService
    {
        public string Ping(string s)
        {
            return "you send " + s + "...";
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
 	          LoginService s = new LoginService(GetConnectionString(), null, null);
              var r = s.Login(request.UserName, request.Password);
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.IsValid = r.Return;
            return response;
        }
       
        public AddressResponse GetAddress()
        {
            var response = new AddressResponse();
            var s = new AddressService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.GetAddresses();
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.Address = r.Return;
            return response;
        }

        public SearchResponse Search(DataContract.SearchRequest request)
        {
            var response = new SearchResponse();
            var s = new SearchService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.Search(request);
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.ShiltonMekomi = r.Return;
            response.CurrentPage = request.CurrentPage;
            response.MaxRowsPerPage = request.MaxRowsPerPage;
            response.SortingName = request.SortingName;
            response.SortingOrder = request.SortingOrder;
            response.TotalPages = r.TotalRows;
            return response;
        }

        public SearchMitkanimResponse SearchMitkanim(DataContract.SearchMitkanimRequest request)
        {
            var response = new SearchMitkanimResponse();
            var s = new MitkanimService(GetConnectionString(), TraceFile, WriteToLogFile);
            var result=s.Search(request);
            response.CurrentPage = request.CurrentPage;
            response.MaxRowsPerPage = request.MaxRowsPerPage;
            response.SortingName = request.SortingName;
            response.SortingOrder = request.SortingOrder;
            response.IsError = result.IsError;
            response.ErrorDesc = result.ErrorDesc;
            response.Data = result.Return;
            response.TotalPages = result.TotalRows;
            return response;
        }

        public UpdateMefuneResponse UpdateMefune(UpdateMefuneRequest request)
        {
            var response = new UpdateMefuneResponse();
            var s = new SearchService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.UpdateMefune(request);
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.ShiltonMekomi = r.Return;
            return response;
        }

        public AgesTypeResponse GetAgesType()
        {
            var response = new AgesTypeResponse();
            var s = new AgeTypeService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.GetAgeType();
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.AgesTypes = r.Return;
            return response;
        }

        public RashuyotResponse GetRashuyot()
        {
            var response = new RashuyotResponse();
            var s = new AddressService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.GetRashuyot();
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.Rashuyot = r.Return.Any() ? r.Return.ToList() : null;
            return response;
        }

        public YeshuvimResponse GetYeshuvim()
        {
            var response = new YeshuvimResponse();
            var s = new AddressService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.GetYeshuvim();
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.Yeshuvim = r.Return.Any() ? r.Return.ToList() : null;
            return response;
        }

        public MitkanimResponse GetMitkanim()
        {
            var response = new MitkanimResponse();
            var s = new MitkanimService(GetConnectionString(), TraceFile, WriteToLogFile);
            var r = s.GetMitkanim();
            response.IsError = r.IsError;
            response.ErrorDesc = r.ErrorDesc;
            response.Mitkanim = r.Return.Any() ? r.Return.ToList() : null;
            return response;
        }

        string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MEDAMConnectionString"].ConnectionString;
        }

        void TraceFile(string NewComment)
        {
            if (ConfigurationManager.AppSettings["AllowTrace"] != "1")
                return;
            try
            {
                DateTime dt;
                dt = DateTime.Now;
                string LogFileName = "TRACE_" + dt.Day + dt.Month + dt.Year + ".txt";
                // TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath("ExceptionLogs/"+LogFileName), true);     
                //ConfigurationManager.AppSettings["CachePeriodMin"]
                TextWriter tw = new StreamWriter(ConfigurationManager.AppSettings["PathToLog"] + LogFileName, true);
                string logStatement = dt.ToShortTimeString() + " : " + NewComment;
                tw.WriteLine(logStatement);
                tw.Flush();
                tw.Close();
            }
            catch (Exception)
            {

                return;

            }
        }
     
        void WriteToLogFile(string NewComment)
        {
            try
            {
                DateTime dt;
                dt = DateTime.Now;
                string LogFileName = "Log_" + dt.Day + dt.Month + dt.Year + ".txt";
                // TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath("ExceptionLogs/"+LogFileName), true);     
                //ConfigurationManager.AppSettings["CachePeriodMin"]
                TextWriter tw = new StreamWriter(ConfigurationManager.AppSettings["PathToLog"] + LogFileName, true);
                string logStatement = dt.ToShortTimeString() + " : " + NewComment;
                tw.WriteLine(logStatement);
                tw.Flush();
                tw.Close();
            }
            catch (Exception)
            {

                return;

            }
        }




}
}
