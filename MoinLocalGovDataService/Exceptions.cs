using System;
using System.IO;
using System.Configuration;
using System.Web;

namespace MoinLocalGovDataService
{
    public static class Exceptions
    {
        public static void WriteToLogFile(string NewComment)
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
            catch (Exception )
            {             

                return;

            }
        }
    }
}